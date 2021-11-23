using System.Collections;
using System.Collections.Generic;
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

    // AreYouSureBoxButtonManager.cs 에서 참조 
    public void DoBeforeMovingToNextScene()
    {
        // txt file 생성
        gameObject.GetComponent<InputToText>().CreateTextFile("AboutPage");
        // html file 생성 
        GameObject.Find("ManageScene").GetComponent<CreateNewHtml>().CreateEditedHtmlFile("about", "AboutPage");
        _changeFileName.CopyDirectory();

        // move to next scene 
        SetFadeout(nextSceneName);
    }
}
