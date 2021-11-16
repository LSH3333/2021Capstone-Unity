using UnityEngine;
using UnityEngine.UI;

public class AreYouSureBoxButtonManager : MonoBehaviour
{
    public AudioSource onSound;


    public void OnClickYes()
    {
        // 모든 씬에는 ManageScene 게임오브젝트가 있고 그 내부에 씬을 컨트롤하는 클래스가 있고 ,
        // 해당 클래스안에는 DoBeforeMovingToNextScene 함수가 존재한다 
        GameObject.Find("ManageScene").SendMessage("DoBeforeMovingToNextScene");
        ClickSnd();

    }

    public void OnClickNo()
    {                
        GameObject.Find("NextBtn").GetComponent<Button>().interactable = true;

        // click sound
        ClickSnd();

        Destroy(gameObject);
    }

    public void MouseEnterButton()
    {
        onSound.Play();
    }

    private void ClickSnd()
    {
        // click sound 
        GameObject clickSnd = Resources.Load("clickSnd") as GameObject;
        GameObject spawnedSnd = Instantiate(clickSnd, Vector2.zero, Quaternion.identity);
        spawnedSnd.GetComponent<AudioSource>().Play();
        Destroy(spawnedSnd, 1f);
    }

    
}
