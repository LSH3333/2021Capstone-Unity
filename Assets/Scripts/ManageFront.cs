﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

public class ManageFront : Manage
{
    

    protected override void Awake()
    {
        // fade 
        base.Awake();
    }


    // button에 연결 
    public void Front1Func()
    {
        // Instaniate한 모든 오브젝트들 제거 
        if (objs.Count != 0) DestroySpawnedObj();
        Debug.Log(index);
        switch (index)
        {
            case 0:
                // 대화박스 생성 
                obj = CreateBox(Vector2.zero, new Vector2(800f, 200f),
                    "In this screen, you have to fill in the text box with whatever contents you like");
                // 오브젝트 제거 위해서 objs 리스트에 추가. 다음 버튼 클릭 시 objs에 등록된 모든 객체들 제거됨 
                objs.Add(obj);
                break;

            case 1:
                obj = CreateBox(new Vector2(-250f, 130f), new Vector2(700f, 100f),
                    "Now let's start filling in the textbox!");
                objs.Add(obj);
                // 화살표 생성 
                obj = CreateOnCanvas("UpArrow" ,new Vector2(-335f, 182f));
                objs.Add(obj);
                break;

            case 2:
                obj = CreateBox(new Vector2(-180f, -200f), new Vector2(1000f, 100f),
                    "You can also drag down to see more pages");
                objs.Add(obj);

                obj = CreateOnCanvas("DragDown", new Vector2(127f, -211f));
                objs.Add(obj);
                break;

            case 3:
                obj = CreateBox(new Vector2(45f,-203f), new Vector2(800f, 200f),
                    "Please click this button when you are done with filling boxes!");
                objs.Add(obj);

                obj = CreateOnCanvas("RightArrow", new Vector2(290f, -200f));
                objs.Add(obj);
                break;

            case 4:
                // txt file 생성
                gameObject.GetComponent<InputToText>().CreateTextFile();
                // html file 생성 
                GameObject.Find("ManageScene").GetComponent<CreateNewHtml>().CreateEditedHtmlFile();

                // move to next scene 
                SetFadeout("Front1-2");
                break;
        }
        index++;
    }


}
