using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        Debug.Log("Start: " + Time.deltaTime);
        yield return new WaitForSeconds(2f);
        Debug.Log("End: " + Time.deltaTime);
    }
}
