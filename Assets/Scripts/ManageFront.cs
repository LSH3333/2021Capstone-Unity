﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

public class ManageFront : Manage
{
    public int index = 0;
    GameObject obj;
    List<GameObject> objs = new List<GameObject>();

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
        
        switch (index)
        {
            case 0:
                // 대화박스 생성 
                obj = CreateBox(Vector2.zero, new Vector2(500f, 200f),
                    "In this screen, you have to fill in the text box with whatever contents you like");
                objs.Add(obj);
                break;

            case 1:
                obj = CreateBox(new Vector2(-217f, 105f), new Vector2(500f, 100f),
                    "now let's start filling in the textbox!");
                objs.Add(obj);
                // 화살표 생성 
                obj = CreateOnCanvas("UpArrow" ,new Vector2(-335f, 182f));
                objs.Add(obj);
                break;

            case 2:
                obj = CreateBox(new Vector2(-221f, -203f), new Vector2(500f, 100f),
                    "You can also drag down to see more pages");
                objs.Add(obj);

                obj = CreateOnCanvas("DragDown", new Vector2(57f, -206f));
                objs.Add(obj);
                break;

            case 3:
                obj = CreateBox(new Vector2(45f,-203f), new Vector2(600f, 100f),
                    "Please click this button when you are done with filling boxes!");
                objs.Add(obj);

                obj = CreateOnCanvas("RightArrow", new Vector2(354f, -200f));
                break;
        }
        index++;
    }

    // 이전에 Instantiate한 모든 오브젝트들 제거 
    private void DestroySpawnedObj()
    {
        foreach(GameObject x in objs)
        {
            Destroy(x);
        }
        objs.Clear();
    }
}
