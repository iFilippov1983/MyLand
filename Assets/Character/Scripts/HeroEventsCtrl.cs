using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class HeroEventsCtrl : MonoBehaviour
{
    [SerializeField] private bool ikActive = false;
    private Animator animatorGO = null;

    //Steps correction
    [SerializeField] private List<AudioClip> stepSoundsRoad = null;
    [SerializeField] private float weightStepRight= 1;
    [SerializeField] private float weightStepLeft = 1;
    [SerializeField] private Transform leftFootRayStart;
    [SerializeField] private Transform rightFootRayStart;
    private Vector3 rightFootPosition;
    private Vector3 leftFootPosition;
    private RaycastHit hitStep;
    private bool rayCastStep = false;
    private int rightHash;
    private int leftHash;

    //Interaction
    [SerializeField] private float weightHold = 1;
    [SerializeField] private float weightLookAt = 1;
    [SerializeField] private List<Transform> targetsToInteract = null;
    private Vector3 seekVector;
    private RaycastHit hitSeek;
    private bool rayCastSeek = false;

    
 

    

    private void Start()
    {
        animatorGO = GetComponent<Animator>();

        rightHash = Animator.StringToHash("stepRight");
        leftHash = Animator.StringToHash("stepLeft");
    }

    private void OnAnimatorIK(int layerIndex)
    {

        RaycastMoving();

        if (ikActive)
        {
            if (hitSeek.collider) Interact(hitSeek, seekVector, hitSeek.collider.gameObject.tag);
        }
        else
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetLookAtWeight(0);
        }
    }

    //private void Update()
    //{
        
    //    //if (animatorGO.GetFloat(stepLeft))
    //    //StepSound();

    //}

    private void FixedUpdate()
    {
        RaycastInteractionSeek();
    }

    private void RaycastMoving()
    {
        rayCastStep = Physics.Raycast(rightFootRayStart.position, Vector3.down, out hitStep, 2f);
        if (rayCastStep) StepsCorrection("right");

        rayCastStep = Physics.Raycast(leftFootRayStart.position, Vector3.down, out hitStep, 2f);
        if (rayCastStep) StepsCorrection("left");
    }

    private void RaycastInteractionSeek()
    {
        if (targetsToInteract != null)
        {
            Vector3 startPosition = transform.position;
            startPosition.y += 1f;

            for (int i = 0; i < targetsToInteract.Count; i++)
            {
                seekVector = targetsToInteract[i].position - startPosition;
                rayCastSeek = Physics.Raycast(startPosition, seekVector, out hitSeek, 3f);

                if (rayCastSeek)
                {
                    ikActive = true;
                }
                else
                {
                    ikActive = false;
                }
            }
        }
        else
        {
            ikActive = false;
        }
    }

    private void StepsCorrection(string foot)
    {

        weightStepLeft = animatorGO.GetFloat(leftHash);
        weightStepRight = animatorGO.GetFloat(rightHash);

        animatorGO.SetIKPositionWeight(AvatarIKGoal.RightFoot, weightStepRight);
        animatorGO.SetIKRotationWeight(AvatarIKGoal.RightFoot, weightStepRight);

        animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftFoot, weightStepLeft);
        animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftFoot, weightStepLeft);


        
        if (foot == "right")
        {
            rightFootPosition = hitStep.point;
            animatorGO.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPosition);
        }

        if (foot == "left")
        {
            leftFootPosition = hitStep.point;
            animatorGO.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPosition);
        }
 
        
        
    }

    private void Interact(RaycastHit raycastHit, Vector3 vector, string tag)
    {
        if (tag == "HandleOneHand") HoldOneHand(raycastHit.transform, vector);
        if (tag == "LookAtObject") LookAt(raycastHit.transform, vector);
        if (tag == "HandleTwoHands") TwoHandsHold(raycastHit.transform, vector);
    }

    private void HoldOneHand(Transform target, Vector3 vector)
    {
        animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, weightHold);
        animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, weightHold);

        animatorGO.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        animatorGO.SetIKRotation(AvatarIKGoal.RightHand, target.rotation);
    }

    private void TwoHandsHold(Transform target, Vector3 vector)
    {
        animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, weightHold);
        animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, weightHold);

        animatorGO.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        animatorGO.SetIKRotation(AvatarIKGoal.RightHand, target.rotation);

        animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, weightHold);
        animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, weightHold);

        animatorGO.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        animatorGO.SetIKRotation(AvatarIKGoal.LeftHand, target.rotation);
    }

    private void LookAt(Transform target, Vector3 vector)
    {
        animatorGO.SetLookAtWeight(weightLookAt);
        animatorGO.SetLookAtPosition(target.position);
    }

    public void StepSound()
    {
        animatorGO.gameObject.GetComponent<AudioSource>().clip = stepSoundsRoad[Random.Range(0, stepSoundsRoad.Capacity)];
        animatorGO.gameObject.GetComponent<AudioSource>().Play();
    }
}
