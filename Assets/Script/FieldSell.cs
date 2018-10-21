using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//100×100×100の座標上の名前
//座標をFieldSell暮らすより受け取っている。
//これをベースにAxControllerにデータを保存すれば良い。
//Jsonデータ格納専用クラス
//https://creive.me/archives/14311/

[Serializable]
public class Block {
    public int xPos;
    public int yPos;
    public int zPos;
    public string blockName = "";
    public bool putableUP = true;

    //関数SetPositionを作成。
    //三つの引数を受け取り、Blockクラス内の座標に格納。
    //座標データではないので要注意
    public void SetPosition (int x, int y, int z) {
        this.xPos = x;      //配列データと同じ数字がxPosに入る
        this.yPos = y;      //配列データと同じ数字がyPosに入る
        this.zPos = z;      //配列データと同じ数字がzPosに入る
    }


    // Prefabの名前を設定する
    // nameを因数として受け取り、blockNameに格納
    public void SetBlockName(string name) {
        this.blockName = name;
    }

    ////  ここでは何をしている？  ///
    public static implicit operator Block(string v)
    {
        throw new NotImplementedException();
    }


    public void JsonUpdata(int x, int y, int z, string blockname, bool putablecheck)
    {
        //地形変更を検知
        //作成　or 移動 or 削除
        //作成:作成したオブジェクト座標情報などが獲得できれば良い。
        //移動:移動前のオブジェクトの情報から移動後の情報と作成と同じ情報が必要
        //削除:削除したオブジェクトの座標と削除=nullという情報
        //とりあえず、座標情報、名前、
        //どのタイミングで呼び出す?オブジェクトを生成・移動・削除した際に呼び出す関数とする。その際に作成・移動・削除に関する情報を引数として渡す
        //ではどのスクリプトでその呼出宣言をする？
        //ObjextBuildでオブジェクトの座標及び名前は手に入る
        //JsonUtility.FromJsonOverwrite(JSONデータ, クラス); //　取得したJSONデータをクラスのプロパティに上書き
        //https://gametukurikata.com/program/savedata

        this.xPos = x;      //配列データと同じ数字がxPosに入る
        this.yPos = y;      //配列データと同じ数字がyPosに入る
        this.zPos = z;      //配列データと同じ数字がzPosに入る
        this.blockName = blockname;
        putableUP = putablecheck;


        //Block block = new Block();
        //block.SetPosition(x, y, z);
        //block.SetBlockName(blockname);
        //block.putableUP = putablecheck;
        //JsonUtility.FromJsonOverwrite(jsonString, this);
        //Jsonデータの更新
        //ここでブロッククラスを配列化
        //再度1000000の列に変換
        //index番号に対する処理をかけている。
        //Debug.Log(block[99, 0, 0].xPos);
        //Debug.Log([99, 0, 0].yPos);
        //Debug.Log(blockData4[99, 0, 0].zPos);
        //Debug.Log(blockData4[99, 0, 0].blockName);

    }

}

/// <summary>
/// アプリケーション終了時に呼ばれる
/// </summary>
//private void OnApplicationQuit()
//{
//    SaveToJson(SaveData.FilePath, _data);
//}


public class FieldSell : MonoBehaviour
{
    //保存するファイル
    //const string SAVE_FILE_PATH = "save.txt";
    //3次元配列
    //100×100×100の空間座標を定義
    //Blockクラスを配列を使用して一つのデータの塊にしている。
    //publicにして他のスクリプトからアクセス可能にする。
    public Block[,,] blockData1 = new Block[100, 100, 100];
    //public SaveData _data;

    //セーブ用の変数
    const string SAVE_FILE_PATH = "save.txt";

    void Start()
    {
        // GetLength(0)はx軸の配列の長さ、GetLength(1)はY軸の配列の長さ、GetLength(2)はz軸の配列の長さ
        // ここでデータを作っている
        // 多次元配列の場合、配列(変数)名.Lengthで要素の数を判定、各次元の配列数を求める場合は配列(変数)名.GetLength(次元数)
        //string json = null;ここで新しく宣言して初期化を行ったら、データが常にnullになる。
        //必要なのは、更新しているデータ


        //if文を使用してJsonデータのない場合は読み込み処理をかける
        //if (_data == null)
        //{  //それか!=nullか？
        //}
        //if else(){  この中にJsonの読み込み処理を記入}
        //何があれば、更新処理をするしないを定義できるのか
        //if (){

            for (int y = 0; y < blockData1.GetLength(1); y++)
            {
                for (int z = 0; z < blockData1.GetLength(2); z++)
                {
                    for (int x = 0; x < blockData1.GetLength(0); x++)
                    {

                        //ここでBlockの座標を定義するため、Blockクラスをインスタンス化
                        Block block = new Block();
                        //SetPosition関数に上記のfor文を利用した0〜100までの配列を1000000回渡す
                        //ここで配列上のxyz変数をxPos,yPos,zPos変数に対応するようにしている。
                        //つまりxyzは条件分岐用の変数。xPos,yPos,zPosはJson格納用の変数という認識。
                        block.SetPosition(x, y, z);
                        //配列をもつ変数blockData1にBlockクラスのインスタンスを格納。このインスタンスに
                        //blockData1[x,y,z]で配列情報にアクセスしている
                        //最終的にはBlock変数に配列指示[,,]と同時に格納する情報xPosなど更新を行っている。
                        blockData1[x, y, z] = block;

                        // 一番下を地面に設定している。
                        if (y == 0)
                        {
                            //ここでPrefabの名前を獲得できれば良い
                            blockData1[x, y, z].SetBlockName("GroundPrefab");
                        }
                    }
                }
            }

            // 3次元配列を1列の配列に格納するための配列を定義 x軸 × y軸 × z軸
            Block[] itemArray2 = new Block[1000000];

            for (int y = 0, index = 0; y < blockData1.GetLength(1); y++)
            {
                for (int z = 0; z < blockData1.GetLength(2); z++)
                {
                    for (int x = 0; x < blockData1.GetLength(0); x++)
                    {
                        //itemArray2配列にindex=0の時には[1,1,1]を格納している？
                        itemArray2[index] = blockData1[x, y, z];
                        index++;
                    }
                }
            }


            // jsonに変換
            string json = JsonHelper.ToJson<Block>(itemArray2, true);
            ////こちらのjsonデバッグだとxposに更新がかかっている。
            ////なぜ？また、zが途中で途切れる…これもな
            Debug.Log(json);

            // Assetsフォルダに保存する
            var path = Application.dataPath + "/" + SAVE_FILE_PATH;
            var writer = new StreamWriter(path, false); // 上書き
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();


            //ここからデータの呼び出しコードを記述
        //}
        //if else (){

           // var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
            //var reader = new StreamReader(info.OpenRead());

            //var json = reader.ReadToEnd();
            //var data = JsonUtility.FromJson<SaveData>(json);
            //data.Dump();

            //ここからはJsonからのデータ復元方法を記述している。
            // まずはJsonから2次元配列にする
            Block[] blockData3 = JsonHelper.FromJson<Block>(json);

            // jsonから戻した3次元配列を格納するための変数
            Block[,,] blockData4 = new Block[100, 100, 100];

            // 2次元配列から3次元配列にもどす
            for (int y = 0, index = 0; y < blockData4.GetLength(1); y++)
            {
                for (int z = 0; z < blockData4.GetLength(2); z++)
                {
                    for (int x = 0; x < blockData4.GetLength(0); x++)
                    {
                        blockData4[x, y, z] = blockData3[index];
                        index++;
                    }
                }
            }

        // 戻したデータを表示させている
        // ここは何？配列内に格納されている変数にアクセスしている？
        Debug.Log(blockData4[99, 0, 0].xPos);
        Debug.Log(blockData4[99, 0, 0].yPos);
        Debug.Log(blockData4[99, 0, 0].zPos);
        Debug.Log(blockData4[99, 0, 0].blockName);
    }

    void Updata(){

        if (Input.GetKeyDown(KeyCode.L))
        {
            // Lキーでロード実行
            // Assetsフォルダからロード
            Debug.Log("クリック");
            var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
            var reader = new StreamReader(info.OpenRead());
            var json = reader.ReadToEnd();
            var data = JsonUtility.FromJson<SaveData>(json);
           
        }
    }

}


//必要なのはゲームオブジェクトを生成すると同時に
//オブジェクトの情報を格納する変数などを配列のxPos,yPos,zPosと対応させる。
//例えば、①オブジェクト生成　同時に②オブジェクト名、③オブジェクト座標を格納　④