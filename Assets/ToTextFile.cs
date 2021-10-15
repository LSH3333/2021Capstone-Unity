using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ToTextFile : MonoBehaviour
{
    public InputField inputFieldChat;

    private void Start()
    {
        // create folder 
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Chat_Logs/");


    }

    public void CreateTextFile()
    {
        if (inputFieldChat.text == "") return;

        // 만들 txt file의 이름 
        string txtDocumentName = Application.streamingAssetsPath + "/Chat_Logs/" + "Chat" + ".txt";

        // 해당 이름의 txt file이 존재 하지 않는다면 
        if(!File.Exists(txtDocumentName))
        {            
            File.WriteAllText(txtDocumentName, "TITLE OF MY CHAT LOG \n\n");
        }

        // txt파일에 input field에 있는 문자열들 추가 (개행 포함) 
        File.AppendAllText(txtDocumentName, inputFieldChat.text + "\n");
        // input field 비워줌 
        inputFieldChat.text = "";
    }

}
