using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画面上でクリックしたオブジェクトを取得し、名前を表示する関数。
//参考スクリプトなので、ゲームには不要
//動作確認用にアタッチして使用している。

public class TouchObject : MonoBehaviour {

	// 左クリックしたオブジェクトを取得する関数(3D)
	public GameObject getClickObject() {
        //result変数を定義。最初は空っぽ。null
		GameObject result = null;
		// 左クリックされた場所のオブジェクトを取得
		if(Input.GetMouseButtonDown(0)) {
            //Rayクラス　rayの定義。メインカメラにアクセス。ScreenPointToRay関数呼び出し。
            //マウスのポジションを引数。場所の情報を戻り値として取得。
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //hit変数の定義。
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit)){
				result = hit.collider.gameObject;
			}
		}
		return result;
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject obj = getClickObject ();
		if (obj != null) {
		// 以下オブジェクトがクリックされた時の処理
			Debug.Log( obj.name );
		}
	}
}
	

