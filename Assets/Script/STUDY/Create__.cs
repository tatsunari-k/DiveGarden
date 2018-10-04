using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//【Unity入門】動的生成の基本!Resources.Loadを覚えよう!
//https://www.sejuku.net/blog/55260
//Resourceクラスを使用して、動的にオブジェクトを発生させる。ゲーム中に登場させるイメージ


public class CreateManager : MonoBehaviour
{

    // 初期化
    void Start()
    {
        GameObject obj = (GameObject)Resources.Load("Cube");

        // プレハブを元にオブジェクトを生成する
        GameObject instance = (GameObject)Instantiate(obj,
                                                      new Vector3(0.0f, 0.0f, 0.0f),
                                                      Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
