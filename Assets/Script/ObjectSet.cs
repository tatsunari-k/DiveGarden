using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画面上でポインターで指した場所に指定のオブジェクトをセットするスクリプト。
//追随する
//https://www.urablog.xyz/entry/2017/04/28/213010

public class ObjectSet : MonoBehaviour {

	[SerializeField]
	//m_objectって何？　my objectの略。
    //プログラミングでは自身で作成したオブジェクトやマテリアルをよくm_◯◯と変数定義する。
	private GameObject  Object    = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame

	private void Update()  {
		//touchScreenPosition変数を定義。mouseの位置を格納
		Vector2 touchScreenPosition = Input.mousePosition;
		//スクリーン上の位置xyそれぞれのclampすることで、画面の端以上にポインターが行かないように指定
		touchScreenPosition.x   = Mathf.Clamp( touchScreenPosition.x, 0.0f, Screen.width );
		touchScreenPosition.y   = Mathf.Clamp( touchScreenPosition.y, 0.0f, Screen.height );
		//gameCamera変数を定義mainカメラのを格納
		Camera  gameCamera      = Camera.main;
		//touchPointToRay変数を定義。mainカメラからRayを発射。上記で定義したマウスで指し示している座標に発射。
		Ray     touchPointToRay = gameCamera.ScreenPointToRay( touchScreenPosition );
		//hitInfo変数を定義。RaycastHitのインスタンスを格納
		RaycastHit hitInfo = new RaycastHit();
        //touchPointToRay  ここの処理が不明？
        //Physics.Raycast()はレイ、つまり直線がオブジェクトにヒットしたときにtrueを返します。
        //オブジェクトと直線の交差判定ですね。
        //out hitInfoとなっているのは、hitInfoに戻り値を格納する、という意味
        //outは引数を必要を指定しない処理
        //つまりhitInfoにはRaycastで当たった(gameCameraからスクリーンに向けて出したRayに当たった場所)オブジェクトが格納されている。
        if ( Physics.Raycast( touchPointToRay, out hitInfo ) )
		{
            //オブジェクトRaycastHitの情報を指定
            //touchPointToRayを引数とし、マウスの座標上のオブジェクト
            Object.transform.position = hitInfo.point;
		}

		// デバッグ機能を利用して、スクリーンビューでレイが出ているか確認
		Debug.DrawRay( touchPointToRay.origin, touchPointToRay.direction * 1000.0f );

	}
}
