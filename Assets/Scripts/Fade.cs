using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private int _nextScene = 0;


    public void endFadeIn()
    {
        gameObject.SetActive(false);
    }

    public void endFadeOut()
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void setFadeOut()
    {
        GetComponent<Animator>().SetTrigger("SetFadeout");
    }

    public void setNextScene(int _idx)
    {
        _nextScene = _idx;
    }
}
