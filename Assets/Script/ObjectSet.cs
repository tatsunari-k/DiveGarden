﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
    //画面上でポインターで指した場所に指定のオブジェクトをセットするスクリプト。
    //追随する

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
		if( Physics.Raycast( touchPointToRay, out hitInfo ) )
		{   //オブジェクトRaycastHitの情報を
			Object.transform.position = hitInfo.point;
		}

		// デバッグ機能を利用して、スクリーンビューでレイが出ているか確認
		Debug.DrawRay( touchPointToRay.origin, touchPointToRay.direction * 1000.0f );

	}
}