using UnityEngine;


public class MyGUI : MonoBehaviour
{
    [SerializeField] private GUISkin skin = null;

    public bool on;
    int menuCount = 0;
    private float framesCounter = 0;
    private float fPS = 0;
    private float showTick = 0;
    private float showTimer = 3f;

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
        showTick++;
        if (showTick >= showTimer)
        {
            fPS = framesCounter / Time.deltaTime;
            showTick = 0;
        }
    }
    private void FixedUpdate()
    {
        if (on)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            //GetComponent<myGUI>().on = true;
            menuCount = 1;
        }

        if (!on)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //GetComponent<myGUI>().on = false;
            menuCount = 0;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 50), fPS.ToString());
        if (on)
        {
            GUI.skin = skin;

        //    // отрисовка панели с текстом
        //    GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 70, 200, 140), "Main Menu");

        //    // Отрисовка кнопок с выводом сообщений
        //    if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 35, 180, 30), "Open"))
        //        _message = "Open";
        //    if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 0, 180, 30), "Save"))
        //        _message = "Save";
        //    if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 35, 180, 30), "Load"))
        //        _message = "Load";

        //    GUI.Label(new Rect(220, 10, 100, 30), _message);

        //    //Угловые панели
        //    GUI.Box(new Rect(0, 0, 100, 50), "Top-left");
        //    GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Top-right");
        //    GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-left");
        //    GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");

        //    // Иконка в панели
        //    GUI.Box(new Rect(10, Screen.height / 2 - 125, 100, 100), _icon);

        //    // Иконка в панели с текстом
        //    GUI.Box(new Rect(10, Screen.height / 2, 100, 100), new GUIContent("Text", _icon));

        //    // Группа GUI
        //    GUI.BeginGroup(new Rect(Screen.width / 2 - 25, 10, 200, 200));
        //    GUI.Label(new Rect(0, 0, 50, 20), "Hello");
        //    GUI.Label(new Rect(0, 25, 50, 20), "World!");
        //    GUI.EndGroup();
        }
    }
}
