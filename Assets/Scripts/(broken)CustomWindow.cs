using System.Collections;
using UnityEditor;
using UnityEngine;

public class CustomWindow : EditorWindow
{ 
    ////public Color myColor;         // �������� �����
    //[SerializeField] private GameObject Player; 
    //[SerializeField] private GameObject Weapon
    ////public Material newMaterial;
    ////[SerializeField] private Transform mainCam = null;

    //private Rect AreaRect = new Rect(10, 30, 100, 20);
    

    //[MenuItem("Custom Tools/Player Customisation")]
    //public static void ShowWindow()
    //{
    //    GetWindow(typeof(CustomWindow), false, "Player");
    //}


    //void OnGUI()
    //{
        
    //    EditorGUILayout.Separator();
    //    Player = EditorGUILayout.ObjectField("Object Mesh", Player, typeof(GameObject), true) as GameObject;
    //    //newMaterial = EditorGUILayout.ObjectField("Object Material", newMaterial, typeof(Material), true) as Material;
    //    EditorGUILayout.Separator();

    //    //if (GO)
    //    //{
    //    //    //myColor = EditorGUI.ColorField(new Rect(AreaRect.x+10, AreaRect.y + 30, AreaRect.width, AreaRect.height), myColor);
    //    //    //myColor = RGBSlider(new Rect(AreaRect.x+10, AreaRect.y + 50, AreaRect.width, AreaRect.height), myColor);  
    //    //    //GO.sharedMaterial.color = myColor; // �������� �������
    //    //}
    //    //else
    //    //{
    //    //    if (GUILayout.Button("Create"))
    //    //    {
                
    //    //        GameObject main = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    //        MeshRenderer GoRenderer = main.GetComponent<MeshRenderer>();
    //    //        GoRenderer.sharedMaterial = newMaterial;
    //    //        main.transform.position = new Vector3(mainCam.position.x, mainCam.position.y, mainCam.position.z + 10);

    //    //        //GO = GoRenderer;
    //    //    }
    //    }
    //}

    ////// ��������� ����������������� ��������
    ////float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // �� �������� MinValue
    ////{
    ////    // ������ ������������� � ������������ � ������������ � ������� ������� � ������� 
    ////    Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

    ////    GUI.Label(labelRect, labelText);   // ������ Label �� ������

    ////    Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // ����� ������� ��������
    ////    sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); // ������������ ������� � ��������� ��� ��������
    ////    return sliderValue; // ���������� �������� ��������
    ////}

    ////// ��������� ������� ������� ������, ������ ������� �������� �� ���� ����
    ////Color RGBSlider(Rect screenRect, Color rgb)
    ////{
    ////    // ��������� ���������������� �������, ������ ���
    ////    rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

    ////    // ������ ����������
    ////    screenRect.y += 20;
    ////    rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

    ////    screenRect.y += 20;
    ////    rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

    ////    screenRect.y += 20;
    ////    rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

    ////    return rgb; // ���������� ����
    ////}

}


