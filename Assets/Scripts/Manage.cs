﻿using UnityEngine;

namespace Management
{
    public abstract class Manage : MonoBehaviour
    {
        private GameObject _fadeobj; // Fade 프리팹 인스턴스 개체 참조할 변수 
        private int _fadeSiblingIndex; // Fade 인스턴스를 최상위 위치로 유지할 목적 

        // 자식 클래스 override 사용할 목적 
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
        public void SetFadeout(int nextScene)
        {
            _fadeobj.GetComponent<Fade>().setNextScene(nextScene);
            _fadeobj.SetActive(true);
            _fadeobj.GetComponent<Fade>().setFadeOut();            
        }


    }
}


