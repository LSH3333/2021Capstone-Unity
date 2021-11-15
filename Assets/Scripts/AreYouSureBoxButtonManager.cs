using UnityEngine;
using UnityEngine.UI;

public class AreYouSureBoxButtonManager : MonoBehaviour
{

    public void OnClickYes()
    {
        // 모든 씬에는 ManageScene 게임오브젝트가 있고 그 내부에 씬을 컨트롤하는 클래스가 있고 ,
        // 해당 클래스안에는 DoBeforeMovingToNextScene 함수가 존재한다 
        GameObject.Find("ManageScene").SendMessage("DoBeforeMovingToNextScene");        
    }

    public void OnClickNo()
    {
        Destroy(GameObject.Find("AreYouSureBox(Clone)"));
        GameObject.Find("NextBtn").GetComponent<Button>().interactable = true;
    }
}
