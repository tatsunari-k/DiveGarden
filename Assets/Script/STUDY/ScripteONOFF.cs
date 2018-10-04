using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スクリプトをON OFFするスクリプト
//なんかエラー
//http://mam2apo.xsrv.jp/unity-script-on-off/


public class ScripteONOFF : MonoBehaviour
{

    private ObjectBuild objectbuild;


    void Start()
    {
        objectbuild = GetComponent<ObjectBuild>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            objectbuild.enabled = !objectbuild.enabled;
        }
    }
}

//bool function = false;


//// ボタンの設定
//private void function OnGUI()
//{
//    // バッググラウンドと名前設定
//    GUI.Box(Rect(10, 10, 100, 90), "メニュー");
//    // ボタンの位置と名前設定
//    if (GUI.Button(Rect(20, 40, 80, 20), "Script ON"))
//    {
//        // ボタン押した時に実行したいもの
//        GetComponent(スクリプト名).enabled = true;
//    }
//    if (GUI.Button(Rect(20, 70, 80, 20), "Script OFF"))
//    {
//        GetComponent(スクリプト名).enabled = false;
//    }
//}
