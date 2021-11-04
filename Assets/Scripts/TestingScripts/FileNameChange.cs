using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FileNameChange : MonoBehaviour
{
    private void Start()
    {
        AssetDatabase.RenameAsset("Assets/img1.png", "changed.png");
    }
}
