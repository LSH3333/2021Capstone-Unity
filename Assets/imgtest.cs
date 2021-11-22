using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imgtest : MonoBehaviour
{
	// Use this for initialization
	IEnumerator Start()
	{
		WWW www = new WWW("file:///D://SampleImage.png");
		while (!www.isDone)
			yield return null;
		GameObject image = GameObject.Find("RawImage");
		image.GetComponent<RawImage>().texture = www.texture;
	}
}
