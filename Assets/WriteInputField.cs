using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Front1 scene에서 input field에 사용자가 입력한 텍스트들 그대로 삽입
public class WriteInputField : MonoBehaviour
{
    //private GameObject[] inputFieldObjs;
    private List<GameObject> inputFieldObjs = new List<GameObject>();
    private List<string> readedFromCreatedTextFile;

    private void Awake()
    {
        // Find all Input Field gameobjects
        OrderInputFieldsObj();

        string createdTextPath = Application.streamingAssetsPath + "/Created_Text/" + "TextOutput" + ".txt";
        readedFromCreatedTextFile = File.ReadAllLines(createdTextPath).ToList();

        Debug.Log(inputFieldObjs.Count);
        for(int i = 0; i < inputFieldObjs.Count; i++)
        {
            inputFieldObjs[i].transform.GetChild(0).GetComponent<Text>().text = readedFromCreatedTextFile[i];
            //inputFieldObjs[i].GetComponent<InputField>().text = readedFromCreatedTextFile[i];
        }
    }

    // InputField 오브젝트들을 이름 순으로 가져와 리스트에 삽입 
    public void OrderInputFieldsObj()
    {
        int idx = 1;

        while (idx < 1000)
        {

            string s = "InputField" + idx.ToString();
            if (GameObject.Find(s) == null) { break; }

            inputFieldObjs.Add(GameObject.Find(s));
            idx++;
        }
    }

}
