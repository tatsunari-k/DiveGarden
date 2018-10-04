using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//配列を利用して、床面を作成するスクリプト。

public class GroundController : MonoBehaviour {
    private float y = 0.5f;

    //GroundsPrefabを入れる
    public GameObject GroundPrefab;

//下記スクリプトは失敗
//	int[,] blockData0 = new Block[100, 100, 100];
//	int[] points = {30, 20, 50, 10, 80, 15, 60, 100};
//
//	// 配列の要素数のぶんだけ処理を繰り返す
//	for (int i = 0; i < points.Length; i++) {
//		// 配列の要素が50以上の場合
//		if( points[i] >= 50 ){
//			// 配列の要素を表示する
//			Debug.Log (points [i]);
//		}
//	}

	// Use this for initialization
	void Start () {
		//この時点ではただの入れ物
		for (int x = 0; x < 20; x++) {
			//x=0~99までの時下記処理が何度も実行される
            for (int z = 0; z < 20; z++) {
                //float y = 0.5f;
				//ここでVector3に実体を与える
				Vector3 pos = new Vector3 (x, y, z);
				//this.gameObject.transform.position = new Vector3 (x, 0, z);
				Instantiate(GroundPrefab,pos,Quaternion.identity);

			}
		}
	}

//	void Start () {
//		//配置する座標を設定
//		Vector3 placePosition = new Vector3(-4,0,9);
//		//配置する回転角を設定
//		Quaternion q = new Quaternion();
//		q= Quaternion.identity;
//		//配置
//		for (int i = 0; i < 5; i++)
//		{
//			Instantiate(blockPrefab, placePosition, q);
//			placePosition.x += blockPrefab.transform.localScale.x;
//		}
//	}
		//移動させるスクリプト↓
		//this.gameObject.transform.position = new Vector3 (pos.x + 0.05f, pos.y, pos.z);


		//		this.gameObject.Find ("Ground");
//		Vector3 pos = transform.position;
//		pos.y += 2;
//		transform.position = pos;

	// Update is called once per frame
	void Update () {
	}
}
