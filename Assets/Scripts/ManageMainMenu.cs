using UnityEngine;
using Management;
using System.IO;

public class ManageMainMenu : Manage
{
    private CreateNewHtml _createNewHtml;

    protected override void Awake()
    {
        // fade 
        base.Awake();
    }

    private void Start()
    {
/*        _createNewHtml = GetComponent<CreateNewHtml>();

        ResetTxtFiles("AboutPage");
        _createNewHtml.CreateEditedHtmlFile("about", "AboutPage");
        ResetTxtFiles("BlogPage");
        _createNewHtml.CreateEditedHtmlFile("blog", "BlogPage");
        ResetTxtFiles("CoursePage");
        _createNewHtml.CreateEditedHtmlFile("course", "CoursePage");
        ResetTxtFiles("TextOutput");
        _createNewHtml.CreateEditedHtmlFile("index", "TextOutput");
*/

    }

    // 이전에 만들어진 텍스트 파일있다면 내용 초기화 
    public void ResetTxtFiles(string txtFileName)
    {
        // 만들 txt file의 이름 
        string txtDocumentName = Application.streamingAssetsPath + "/Created_Text/" + txtFileName + ".txt";

        // 시작 전 text 파일 초기화         
        File.WriteAllText(txtDocumentName, "");
    }

}
