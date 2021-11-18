using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class InputToText : MonoBehaviour
{
    private List<GameObject> inputFieldsObj = new List<GameObject>();

    private void Awake()
    {
        // create folder 
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Created_Text/");
        OrderInputFieldsObj();
    }

    // InputField 오브젝트들을 이름 순으로 가져와 리스트에 삽입 
    public void OrderInputFieldsObj()
    {
        int idx = 1;

        while (idx < 1000)
        {

            string s = "InputField" + idx.ToString();
            if (GameObject.Find(s) == null) { break; }

            inputFieldsObj.Add(GameObject.Find(s));
            idx++;
        }
    }

    // 버튼 누르면 모든 input field들에 있는 text에 따라 텍스트파일 생성하도록 
    public void CreateTextFile()
    {
        // 만들 txt file의 이름 
        string txtDocumentName = Application.streamingAssetsPath + "/Created_Text/" + "TextOutput" + ".txt";

        // 시작 전 text 파일 초기화         
        File.WriteAllText(txtDocumentName, "");

        foreach (var x in inputFieldsObj)
        {            
            CreateText(x, txtDocumentName);            
        }
    }

    public void CreateText(GameObject obj, string txtDocumentName)
    {
        InputField _input = obj.GetComponent<InputField>();
        if(_input.text == "") _input.text = "_"; // 비어있다면
        // txt파일에 input field에 있는 문자열들 추가 (개행 포함) 
        File.AppendAllText(txtDocumentName, _input.text + "\n");
    }

}
