using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

public class ManageFront1_2 : Manage
{
    protected override void Awake()
    {
        base.Awake();
    }

    // button에 연결 
    public void Front1_1Func()
    {
        Debug.Log("BUTTON CLICKED");
        // Instaniate한 모든 오브젝트들 제거 
        if (objs.Count != 0) DestroySpawnedObj();

        switch (index)
        {
            case 0:
                // 대화박스 생성 
                obj = CreateBox(Vector2.zero, new Vector2(500f, 200f),
                    "Now lets change image of your web");
                // 오브젝트 제거 위해서 objs 리스트에 추가. 다음 버튼 클릭 시 objs에 등록된 모든 객체들 제거됨 
                objs.Add(obj);
                break;

        }
        index++;
    }


}
