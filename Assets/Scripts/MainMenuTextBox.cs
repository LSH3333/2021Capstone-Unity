using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTextBox : MonoBehaviour
{
    public GameObject txtObj;
    public GameObject nextObj;

    public void NextObjEnable()
    {
        nextObj.SetActive(true);
    }

    public void txtObjEnable()
    {
        txtObj.SetActive(true);
        if (nextObj != null)
            NextObjEnable();
    }
}
