using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
//using UnityEditor;
//using UnityEngine.Windows;


// readFromFilePath의 html 파일 읽어와서
// 라인별로 "FixFlag"가 존재하면 다음 라인에 createdTextPath의 유저가 지정한 문자열들을 차례대로 삽입하고
// wrtieFilePath에 html 파일을 만든다 
public class CreateNewHtml : MonoBehaviour
{
    //public Transform contentWindow;
    //public GameObject recallTextObject;

    // 읽어서 "FixFlag" 체크할 html 파일 경로 
    private string readFromFilePath;
    // 생성할 html 파일의 경로 
    private string writeFilePath;
    // front1 scene에서 생성된 text file 경로 
    private string createdTextPath;
    private string add = "";

    private int createdTextFileLineIdx = 0;
    private List<string> readedFromCreatedTextFile;

    void Start()
    {

    }

    public void CreateEditedHtmlFile()
    {
        // html file path 
        readFromFilePath = Application.streamingAssetsPath + "/Read_Text/" + "index" + ".html";
        // created text file path
        createdTextPath = Application.streamingAssetsPath + "/Created_Text/" + "TextOutput" + ".txt";

        // 만들어질 html file path
        //writeFilePath = Application.streamingAssetsPath + "/Read_Text/" + "index2" + ".html";
        writeFilePath = FindWebPath() + "/index" + ".html";
        // 기존에 만들어진 html 파일이 있다면 제거해둠 
        File.Delete(writeFilePath);

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        readedFromCreatedTextFile = File.ReadAllLines(createdTextPath).ToList();

        // string add에 html 파일의 문자열들 불러와서 저장 (개행 포함)        
        foreach (string line in fileLines)
        {
            CheckLine(line);
            add += '\n' + line;
            
        }

        // 유니티 텍스트박스 상에서 보이도록 
        //recallTextObject.GetComponent<Text>().text = add;

        // writeFilePath의 html 파일에 내용 복사         
        File.AppendAllText(writeFilePath, add);        
    }

    private void CheckLine(string line)
    {
        // 해당 라인에 "FixFlag" 존재하면 다음 행에 문자열 추가 
        if (line.Contains("FixFlag"))
        {
            if (createdTextFileLineIdx >= readedFromCreatedTextFile.Count) return;           
            // front1 scene에서 생성한 텍스트 파일을 라인별로 읽어서 string add에 추가 
            add += '\n' + readedFromCreatedTextFile[createdTextFileLineIdx++];
        }

    }

    private string FindWebPath()
    {
        // web folder path 
        string webPath;
        webPath = Directory.GetCurrentDirectory() + "/2021Capstone-Web";

        Debug.LogError("getcurDir: " + System.IO.Directory.GetCurrentDirectory());
        Debug.LogError("webpath: " + webPath);
        
        // path/Assets 에서 Assets를 뺀 문자열 
        //webPath = webPath.Substring(0, webPath.Length - 6);
        //webPath += "2021Capstone-Web";


        return webPath;
    }
}
