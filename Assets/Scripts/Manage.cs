using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Management
{
    public abstract class Manage : MonoBehaviour
    {
        private GameObject _fadeobj; // Fade 프리팹 인스턴스 개체 참조할 변수 
        private int _fadeSiblingIndex; // Fade 인스턴스를 최상위 위치로 유지할 목적

        // 각 씬들 오브젝트 관리 
        public int index = 0;
        protected GameObject obj;
        protected List<GameObject> objs = new List<GameObject>();

        // 자식 클래스 override 사용할 목적
        // 모든 씬들은 Fade 해야하므로 virtual
        protected virtual void Awake()
        {
            // 시작하면서 Fade 프리팹 소환 
            _fadeobj = InstantiateUI("Fade", "Canvas", true);
            _fadeSiblingIndex = _fadeobj.transform.GetSiblingIndex();
        }

        // pn: prefab name, cn : canvas name
        // isfull ? canvas 가득 채우도록 배치 : 캔버스 중앙으로 배치 
        public GameObject InstantiateUI(string pn, string cn, bool isfull)
        {
            GameObject resource = (GameObject)Resources.Load(pn);
            GameObject obj = Instantiate(resource, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find(cn).transform);

            if (isfull)
                ((RectTransform)obj.transform).offsetMax = new Vector2(0, 0);
            else
                ((RectTransform)obj.transform).anchoredPosition = new Vector2(0, 0);

            if (!pn.Equals("Fade")) obj.transform.SetSiblingIndex(_fadeSiblingIndex);

            return obj;
        }

        // fade out 작동시키고, 다음 씬으로 넘어가도록함 
        public void SetFadeout(string nextScene)
        {
            _fadeobj.GetComponent<Fade>().setNextScene(nextScene);
            _fadeobj.SetActive(true);
            _fadeobj.GetComponent<Fade>().setFadeOut();            
        }

        // 이미지 좌표, 이미지 크기, 텍스트박스의 내용 
        public GameObject CreateBox(Vector2 imgPos, Vector2 imgSize, string content)
        {
            GameObject resource = (GameObject)Resources.Load("TextBox");
            GameObject obj = Instantiate(resource, imgPos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Canvas").transform);

            // imgPos로 set 
            ((RectTransform)obj.transform).anchoredPosition = imgPos;
            // imgSize로 set 
            ((RectTransform)obj.transform).sizeDelta = imgSize;
            // text box size는 이미지보다 조금 작도록 수정함 
            Vector2 textboxSize = new Vector2(imgSize.x - 50f, imgSize.y - 50f);            
            obj.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = textboxSize;
            // 내용 변경  
            obj.GetComponentInChildren<Text>().text = content;

            return obj;
        }

        // 화살표 소환 
        public GameObject CreateOnCanvas(string arrowName, Vector2 pos)
        {
            GameObject resource = (GameObject)Resources.Load(arrowName);
            GameObject obj = Instantiate(resource, pos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Canvas").transform);

            ((RectTransform)obj.transform).anchoredPosition = pos;

            return obj;
        }


        // 이전에 Instantiate한 모든 오브젝트들 제거 
        public void DestroySpawnedObj()
        {
            // objs에 등록된 모든 객체들 제거 
            foreach (GameObject x in objs)
            {
                Destroy(x);
            }
            objs.Clear();
        }


    }
}


