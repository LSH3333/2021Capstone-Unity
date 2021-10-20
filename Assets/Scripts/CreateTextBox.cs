using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTextBox : MonoBehaviour
{
    public void CreateBox(Vector2 imgPos, Vector2 imgSize, Vector2 textboxSize, string content)
    {
        GameObject resource = (GameObject)Resources.Load("TextBox");
        GameObject obj = Instantiate(resource, imgPos, Quaternion.identity);
        obj.transform.SetParent(GameObject.Find("Canvas").transform);


    }
}
