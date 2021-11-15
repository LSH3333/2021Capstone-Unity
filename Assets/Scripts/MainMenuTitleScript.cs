using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTitleScript : MonoBehaviour
{
    public GameObject tb;

    public void AfterAnimation()
    {        
        tb.SetActive(true);
    }
}
