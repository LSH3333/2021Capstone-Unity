using UnityEngine;
using UnityEngine.UI;
using System;
//using UnityEngine.Windows;
//using UnityEditor;
using System.IO;
using SFB;
using System.Collections;

public class ChangeFileName : MonoBehaviour
{
    // 절대경로 
    string[] path;
    // 절대경로 path에서 상대경로가 시작되는 지점 ("Assets/" 의 'A' 지점) 
    private int flagIdx;

    // string name형식 : "Course_", "Blog_", "About_"
    // index.html은 "" 공백으로 
    public bool OpenExplorer(int number, string name)
    {
        // open explorer 
        //path = EditorUtility.OpenFilePanel("Overwrite with png", Application.dataPath + "/IMAGES", "png,jpg,jpeg");
        var extensions = new[]
        {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg")
        };
        // path[0] : explorer에서 오픈한 이미지의 경로 
        path = StandaloneFileBrowser.OpenFilePanel("Open Image", "", extensions, false);
        Debug.Log("path!! : " + path[0]);
        // explorer창 닫았을시 return false 
        if (path[0] == "") return false;

        string objName = "transparent" + Convert.ToString(number);        
        StartCoroutine(RenderImg(path[0], objName));
        
        MakePathRelative();                

        // 프로젝트 폴더에서의 상대경로 
        string relativePath = path[0].Substring(flagIdx);
        Debug.Log("RelativePath: " + relativePath);

        // 이름 변경
        string changeTo = ReturnPathExceptFileName(relativePath) + name + "Image" + Convert.ToString(number) + ReturnFormat(path[0]);
        //AssetDatabase.RenameAsset(relativePath, changeTo);

        Debug.Log("chageTo: " + changeTo);
        if (!File.Exists(changeTo))
            File.Move(relativePath, changeTo);

        return true;
    }
    
    // 유저가 선택한 이미지 캔버스에 렌더링 
    IEnumerator RenderImg(string path, string objName)
    {
        WWW www = new WWW(path);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find(objName);
        image.GetComponent<RawImage>().texture = www.texture;

        var img = image.GetComponent<RawImage>();
        var tempColor = img.color;
        tempColor.a = 255f;
        img.color = tempColor;
    }

    public string ReturnPathExceptFileName(string path)
    {
        int idx = 0;
        for(int i = path.Length-1; i >= 0; i--)
        {
            if (path[i] == '/') break;
            idx++;
        }
        return path.Substring(0, path.Length - idx);
    }

    public string ReturnFormat(string path)
    {
        int idx = 0;
        for(int i = path.Length-1; i >= 0; i--)
        {
            if (path[i] == '.') break;
            idx++;
        }
        return path.Substring(path.Length - idx - 1);
    }

    // OpenFilePanel()로 경로를 갖고오면 절대경로를 리턴 받는다.
    // RenameAsset()으로 파일명을 변경하려면 현재 프로젝트 기준 Explorer로 선택한 이미지의 상대경로가 필요하기 때문에
    // 절대경로를 -> 상대경로로 바꿔주는 작업이 필요하다
    // 모든 경로에는 "Assets/"이 포함되기 때문에 경로명에서 "Assets"을 찾는다 
    private void MakePathRelative()
    {
        string str = "";

        for(int i = 0; i < path[0].Length; i++)
        {
            if (path[0][i] == '/')
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

            str += path[0][i];            
        }
    }

    // 폴더 복사 
    public void CopyDirectory()
    {
        // IMAGES folder path 
        string imgPath;
        //imgPath = Application.dataPath;
        imgPath = Directory.GetCurrentDirectory() + "/Assets/IMAGES";

        // web folder path 
        string webPath;
        webPath = Application.dataPath;
        // path/Assets 에서 Assets를 뺀 문자열 
        webPath = webPath.Substring(0, webPath.Length-6);
        webPath += "2021Capstone-Web";

        webPath = Directory.GetCurrentDirectory() + "/2021Capstone-Web";

        //FileUtil.CopyFileOrDirectory("Assets/TempFolder", "/Users/lsh/Desktop/TempFolder");

        // 이전에 만들어진 COPIED_IMAGES 폴더 삭제 
        //FileUtil.DeleteFileOrDirectory(webPath + "/COPIED_IMAGES");
        //File.Delete(webPath + "/COPIED_IMAGES");
        if(Directory.Exists(webPath + "/COPIED_IMAGES"))
            Directory.Delete(webPath + "/COPIED_IMAGES", true);
        
        // /Assets 의 IMAGES 폴더를 ../2021Capstone-Web 폴더로 복사
        //FileUtil.CopyFileOrDirectory(imgPath + "/IMAGES", webPath + "/COPIED_IMAGES");
        //File.Copy(imgPath + "/IMAGES", webPath + "/COPIED_IMAGES");
        DirectoryCopy(imgPath, webPath + "/COPIED_IMAGES", false);
    }

    // 폴더 복사 
    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();

        // If the destination directory doesn't exist, create it.       
        Directory.CreateDirectory(destDirName);

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string tempPath = Path.Combine(destDirName, file.Name);
            file.CopyTo(tempPath, false);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
            }
        }
    }
}
