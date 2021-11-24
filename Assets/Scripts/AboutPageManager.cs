using UnityEngine.UI;
using UnityEngine;
using Management;

public class AboutPageManager : Manage
{
    private string nextSceneName;
    private ChangeFileName _changeFileName;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _changeFileName = GetComponent<ChangeFileName>();
    }

    public void OnClickImg(int number)
    {
        _changeFileName.OpenExplorer(number, "About_");
    }

    // Menu button click시 AreYouSureBox 소환 
    public void OnClickMenuButton(string _nextSceneName)
    {
        nextSceneName = _nextSceneName;           
        obj = CreateOnCanvas("AreYouSureBox", Vector2.zero);
    }

    public void OnClickNextBtn()
    {
        obj = CreateOnCanvas("AreYouSureBox", Vector2.zero);
        // "AreYouSureBox" 팝업시 NextBtn은 클릭 못하도록 
        GameObject.Find("NextBtn").GetComponent<Button>().interactable = false;
        nextSceneName = "fin";
    }


    // AreYouSureBoxButtonManager.cs 에서 참조 
    public void DoBeforeMovingToNextScene()
    {
        // txt file 생성
        gameObject.GetComponent<InputToText>().CreateTextFile("AboutPage");
        // html file 생성 
        GameObject.Find("ManageScene").GetComponent<CreateNewHtml>().CreateEditedHtmlFile("about", "AboutPage");
        // Assets/IMAGES 폴더 내부의 이미지명이 바뀌었으므로 IMAGES 폴더를 2021Capstone-Web/COPIED_IMAGES 폴더로 복사         
        _changeFileName.CopyDirectory();

        // move to next scene 
        SetFadeout(nextSceneName);
    }
}
