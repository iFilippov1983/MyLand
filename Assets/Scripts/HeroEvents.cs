using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEvents : MonoBehaviour
{
    private Animator _animator = null;
    
    [SerializeField] private List<AudioClip> stepSoundsRoad = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }
    

    private void Update()
    {
        if (_animator)
        {
            if (_animator.GetComponent<AnimationEvent>().functionName == "StepRight")
                StepRight();

            if (_animator.GetComponent<AnimationEvent>().functionName == "StepLeft")
                StepLeft();

        }
    }

    public void StepRight()
    {
            _animator.gameObject.GetComponent<AudioSource>().clip = stepSoundsRoad[Random.Range(0, stepSoundsRoad.Capacity)];
            _animator.gameObject.GetComponent<AudioSource>().Play();
    }
    public void StepLeft()
    {
        _animator.gameObject.GetComponent<AudioSource>().clip = stepSoundsRoad[Random.Range(0, stepSoundsRoad.Capacity)];
        _animator.gameObject.GetComponent<AudioSource>().Play();
    }
}
