using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StoneスクロールUIにおいて、選択したボタンに応じて
//ObjextBuildの設置する変数を選択する変数CreateObjectに選択したオブジェクトを格納する。

public class StoneCreator : MonoBehaviour {

    public GameObject cell1;
    public GameObject cell2;
    public GameObject cell3;
    public GameObject cell4;
    public GameObject cell5;
    public GameObject test;
    public ObjectBuild test2;   //クラスを変数にしてインスタンス化。この変数にゲームオブジェクトを渡す関数を設定する。

    //public class ObjectBuild : MonoBehaviour
    //{

    ////GroundsPrefabを入れる
    //public GameObject CreateObject;

    ////クリックしたオブジェクトを取得する関数(3D)
    ////クリックしたオブジェクトを戻り値として返す処理が行われている。
    //public GameObject getClickObject()
    //{
    //GameObject result = null;
    //// Use this for initialization

    void Start()
    {
        //test変数の中にGameScene1を格納
        test = GameObject.Find("GameScene1");
        //test2の中にGameScene1にアタッチしているObjectBuildスクリプトを格納
        test2 = GetComponent<ObjectBuild>();
    }
         //public GameObject CreateObject = null;

    public void StoneSelect() {
    //ボタンとリンクさせて、どのゲームオブジェクトをクリエイトする

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
