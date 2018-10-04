using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


//

public class TileBase : MonoBehaviour {

	private Color default_color;  // 初期化カラー
	private Color select_color;    // 選択時カラー

	protected Material material;

	public bool bColorState;

	// Use this for initialization
	void Start () {
		// このクラスが付属しているマテリアルを取得
		//Renderer内のmaterialを取得
		material = GetComponent<Renderer>().material;

		// 選択時と非選択時のカラーを保持 
		//default_colorにa_materiのcolorを代入
		//クラスの中で定義した変数は緑。
		//関数の中で定義したら白

		default_color = material.color;
		select_color = Color.magenta;
		bColorState = false;
	}

	// Update is called once per frame
	void Update () {
		//
		material.color = default_color;

		// StageBaseからbColorStateの値がtrueにされていれば色をかえる 
		if(bColorState) {
			bColorState = false;
			material.color = select_color;
			//Debug.Log(a_material.name);
		}
	}
}