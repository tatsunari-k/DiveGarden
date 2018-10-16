using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class NestClass
{
    // ここに必要なデータを定義
    // indexは例として定義している。
    // data1,2はサンプル。intなのはサンプルだから？stringでも可能？
    //public Block blockdata;
    //public Vector3 saveblockpos = blockdata.SetPosition(int x, int y, int z);

    //必要なデータ。indexに対するゲームオブジェクトの情報
    //セル上の座標データ
    //座標に対するオブジェクトデータ
    //セル上に存在するオブジェクトデータの方向
    //つまり変化する情報
    //
    //public Block block;
    //public Block JsonyPos;
    //public Block JsonzPos;
    //public Block blockName = "Prefabname";

    public int JsonxPos;
    public int JsonyPos;
    public int JsonzPos;
    public string blockName;
    public bool putableUP = true;
    //    JsonxPos = Block.SetPosition;
    //    JsonyPos = Block.yPos;
    //    JsonzPos = Block.zPos;



    //


}

//ここの処理内容は何をしている？

[Serializable]
public class Item
{

    ////このあと、配列を使用して、indexで100×100×100の三次元配列を一次元配列に変換した1000000の列を作成
    ////Itemクラスの中にNesrClassのインスタンスが格納されている。
    ////これで実行されていることになるの？
    public int index;
    public NestClass nestClassTest;
}

//
//

public class AxControllers : MonoBehaviour
{
    void Start()
    {
        // 100 × 100 × 100 の3次元配列を定義
        //クラスItemでindex変数・NestClassクラスnestClassTest変数を獲得。
        //itemArray変数によりインスタンス化
        //Item[,,]これは何を示している？Itemはクラスなのに配列を使用できるの？
        Item[,,] itemArray = new Item[100, 100, 100];

        //GetLength(0)は何を示している？多分配列の100を獲得していると予想。
        //条件分岐で100×100×100の箱の中でItemクラスのitem変数を定義。itemArray変数内でitemArray変数利用できるの？
        for (int i = 0, index = 0; i < itemArray.GetLength(0); i++)
        {
            for (int j = 0; j < itemArray.GetLength(1); j++)
            {
                for (int k = 0; k < itemArray.GetLength(2); k++)
                {
                    //
                    //index変数にあくせす。indexを格納。これはどういう処理？AxController内のindex変数をItem itemクラス内のindexに格納しているという意味？
                    //最終的にはitemArrayにitemを格納して、index=0に＋1していく
                    Item item = new Item();
                    item.index = index;
                    itemArray[i, j, k] = item;
                    index++;
                }
            }
        }

        // 3次元配列を1列の配列に格納するための配列を定義 x軸 × y軸 × z軸
        // 1列の配列に格納するのは、
        // クラス内で定義している変数ijkはitemArray内のijkとは別物という認識？
        //
        Item[] itemArray2 = new Item[1000000];

        for (int i = 0, index = 0; i < itemArray.GetLength(0); i++)
        {
            for (int j = 0; j < itemArray.GetLength(1); j++)
            {
                for (int k = 0; k < itemArray.GetLength(2); k++)
                {
                    itemArray2[index] = itemArray[i, j, k];
                    index++;
                }
            }
        }

        // jsonに変更
        ////ここでJsonHelperにアクセス
        ////UsonUtility内の関数ToJsonを利用。JsonHelperはstatic変数なので、読み込む必要及び、オブジェクトへのアタッチの必要なし。
        string json = JsonHelper.ToJson<Item>(itemArray2, true);
        ////こちらの方が先に実行処理されている。
        ////こちらのxPosには加算が適用されていない…

        Debug.Log(json);

        // jsonをクラスの配列にしている
        Item[] itemArray3 = JsonHelper.FromJson<Item>(json);

        Debug.Log(itemArray3[100]);
    }
}