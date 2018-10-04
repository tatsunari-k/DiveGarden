using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//多次元配列を利用して座標

public enum BlockType {
	INVALID = -1,
	GROUND,
	STONE,
	CORAL,
	SEEWEED,
    SPECIAL,
}

public class Block {

	//BlockTypeの多次元配列へアクセス
	//blockTypeの変数定義　INNVALIDを格納
	//これ何をしている？INNVALIDを格納して何に使用するつもり？
    //ここでINVALIDスタートのenumの配列を格納しているという意味?

	public BlockType blockType = BlockType.INVALID;

	//上にオブジェクトを置けるか？
    //置けるなら
	public bool putableUP = true;


    // ブロックのタイプを設定する
    //関するの定義。引数型を受け取る。　
    //ブロックのタイプが何かを戻り値で返す。
    //block.SetBlockType (BlockType.GROUND)で関数にアクセス。
    //引数としてBlockType.Groundにアクセスし、GROUNDを引数として渡している。
    //blockType = GROUNDとして引数を返している。

    public void SetBlockType(BlockType type) {
		this.blockType = type;
	}
}


public class FieldSell: MonoBehaviour {
	

	//3次元配列
	//100×100×100の空間座標を定義
	Block[, ,] blockData1 = new Block[100, 100, 100];


	// Use this for initialization
	void Start () {
	//for文を利用して100×0×100の空間座標内に何を格納するかを定義
		for (int x = 0; x < 100; x++) {
			//x=0~99までの時下記処理が何度も実行される
			for (int z = 0; z < 100; z++) {
				//ここでBlockクラスを利用してblockと言う変数を定義
				//新しいインスタンスBlockを作成 → blockへ格納
				Block block = new Block ();
				//block変数（Blockクラスへアクセス） → ブロックタイプの設定　
				//GROUNDの呼び出し
				block.SetBlockType (BlockType.GROUND);
				//定義した三次元配列内にblockを格納
				//ここだとGROUND
				blockData1 [x, 0, z] = block;
			}
		}


        //分割した空間座標内[0,0,0]に存在するblockTypeをログとして出す。
		Debug.Log (blockData1 [0, 0, 0].blockType);

//		//for文を利用して100×1~20×100の空間座標内に何を格納するかを定義
//		for (int y = 1; y < 100; y++) {
//
//			for (int x = 0; x < 100; x++) {
//
//				for (int z = 0; z < 100; z++) {
//					//ここでBlockクラスを利用してblockと言う変数を定義
//					//新しいインスタンスBlockを作成 → blockへ格納
//					Block block = new Block ();
//					//block変数（Blockクラスへアクセス） → ブロックタイプの設定　
//					//GROUNDの呼び出し
//					block.SetBlockType (BlockType.GROUND);
//					//定義した三次元配列内にblockを格納
//					//ここだとGROUN
//					blockData2 [x, y, z] = block;
//				}


	}

	// Update is called once per frame
	void Update () {

	}
}