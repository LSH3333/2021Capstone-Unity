using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InputToText : MonoBehaviour
{    
    private GameObject[] inputFieldsObj;

    private void Awake()
    {
        // create folder 
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Created_Text/");

        // Find all Input Fields gameobject 
        inputFieldsObj = GameObject.FindGameObjectsWithTag("InputField");
    }

    // 버튼 누르면 모든 input field들에 있는 text에 따라 텍스트파일 생성하도록 
    public void CreateTextFile()
    {
        foreach(var x in inputFieldsObj)
        {
            string str = x.GetComponent<InputField>().text;
            Debug.Log(str);
        }
    }

    

}
