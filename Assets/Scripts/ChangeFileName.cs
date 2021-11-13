using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class ChangeFileName : MonoBehaviour
{
    // 절대경로 
    string path;
    // 절대경로 path에서 상대경로가 시작되는 지점 ("Assets/" 의 'A' 지점) 
    private int flagIdx;
        
    public void OpenExplorer(int number)
    {
        // open explorer 
        path = EditorUtility.OpenFilePanel("Overwrite with png", Application.dataPath + "/IMAGES", "png,jpg,jpeg");        
        MakePathRelative();                

        // 프로젝트 폴더에서의 상대경로 
        string relativePath = path.Substring(flagIdx);
        // 이름 변경
        string changeTo = "Image" + Convert.ToString(number);
        AssetDatabase.RenameAsset(relativePath, changeTo);
    }

    // OpenFilePanel()로 경로를 갖고오면 절대경로를 리턴 받는다.
    // RenameAsset()으로 파일명을 변경하려면 프로젝트의 상대경로가 필요하기 때문에
    // 절대경로를 -> 상대경로로 바꿔주는 작업이 필요하다
    // 모든 경로에는 "Assets/"이 포함되기 때문에 경로명에서 "Assets"을 찾는다 
    private void MakePathRelative()
    {
        string str = "";

        for(int i = 0; i < path.Length; i++)
        {
            if (path[i] == '/')
            {
                //Debug.Log(str);
                if(str == "Assets")
                {
                    flagIdx = i - str.Length;
                    break;
                }

                str = "";

                continue;
            }

            str += path[i];            
        }
    }

    // 폴더 복사 
    public void CopyDirectory()
    {
        // IMAGES folder path 
        string imgPath;
        imgPath = Application.dataPath;
        // web folder path 
        string webPath;
        webPath = Application.dataPath;
        // path/Assets 에서 Assets를 뺀 문자열 
        webPath = webPath.Substring(0, webPath.Length-6);
        webPath += "2021Capstone-Web";

        //FileUtil.CopyFileOrDirectory("Assets/TempFolder", "/Users/lsh/Desktop/TempFolder");

        // 이전에 만들어진 COPIED_IMAGES 폴더 삭제 
        FileUtil.DeleteFileOrDirectory(webPath + "/COPIED_IMAGES");
        // /Assets 의 IMAGES 폴더를 ../2021Capstone-Web 폴더로 복사
        FileUtil.CopyFileOrDirectory(imgPath + "/IMAGES", webPath + "/COPIED_IMAGES");
    }    
}
