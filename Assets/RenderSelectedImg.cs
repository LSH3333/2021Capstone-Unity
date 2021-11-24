using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RenderSelectedImg : MonoBehaviour
{
    private void Start()
    {

        
    }

    // 유저가 선택한 이미지 캔버스에 렌더링 
    // path: 이미지 경로, objName: 랜더링할 raw image가 있는 오브젝트 이름 
    IEnumerator RenderImg(string path, string objName)
    {
        WWW www = new WWW(path);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find(objName);
        image.GetComponent<RawImage>().texture = www.texture;

        // alpha값이 0 (투명)이라면 올려서 보이도록함 
        var img = image.GetComponent<RawImage>();
        var tempColor = img.color;
        tempColor.a = 255f;
        img.color = tempColor;
    }
}
