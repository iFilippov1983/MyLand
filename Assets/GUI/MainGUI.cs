using UnityEngine;


public class MainGUI : MonoBehaviour
{
    [SerializeField] private GUISkin skin = null;
    private Rect FrameRect = new Rect(0, 0, 100, 40);


    public bool on;
    int menuCount = 0;
    private float framesCounter = 0;
    private int fPS = 0;
    private float showTick = 0;
    private float showTimer = 200f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuCount == 0)
        {
            on = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menuCount == 1)
        {
            on = false;
        }
        framesCounter++;
    }
    private void FixedUpdate()
    {
        if (on)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            menuCount = 1;
        }

        if (!on)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuCount = 0;
        }
    }

    void OnGUI()
    {
        showTick++;
        if (showTick >= showTimer)
        {
            fPS = (int)(framesCounter / Time.deltaTime / 1000);
            showTick = 0;
        }
        GUI.Box(FrameRect, $"fps: {fPS}");

        if (on)
        {
            GUI.skin = skin;

        }
    }
}
