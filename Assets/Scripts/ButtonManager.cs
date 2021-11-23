using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public AudioSource buttonClickSound;
    public AudioSource onSound;

    // Button Click 시 사운드 
    public void OnClickButtonSound()
    {
        buttonClickSound.Play();
    }    

    // 버튼에 마우스 올라갈 시 이벤트 트리거 
    public void MouseOnButton()
    {
        // hovering 
        ((RectTransform)gameObject.transform).sizeDelta = new Vector2(300f, 150f);
        ((RectTransform)gameObject.transform.GetChild(0).transform).sizeDelta = new Vector2(300f, 150f);
        gameObject.transform.GetChild(1).GetComponent<Text>().fontSize = 50;
        onSound.Play();
    }

    // 버튼에서 마우스 땔 시 
    public void MouseExitButton()
    {
        ((RectTransform)gameObject.transform).sizeDelta = new Vector2(250f, 100f);
        ((RectTransform)gameObject.transform.GetChild(0).transform).sizeDelta = new Vector2(250f, 100f);
        gameObject.transform.GetChild(1).GetComponent<Text>().fontSize = 40;
    }

   
}
