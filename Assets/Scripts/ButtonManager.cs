using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public AudioSource buttonClickSound;

    // Button Click 시 사운드 
    public void OnClickButtonSound()
    {
        buttonClickSound.Play();
    }
}
