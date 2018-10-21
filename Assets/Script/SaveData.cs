using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jsonデータをセーブするクラス
//他のクラス内でセーブデータを管理するのに使用
//管理用の変数を複数持つ
[SerializeField]
public class SaveData
{
    //filePathでUnity内で取得可能なパスへアクセス。
    //https://qiita.com/consolesoup/items/19fed212d4ef2bd1e1dd
    private static string filePath = Application.dataPath + "/savedata.json";//セーブデータのファイルパス
    //上記の変数にアクセスするための関数？変数？プロパティを調べる。
    public static string FilePath
    {//ファイルパスのプロパティ
        get { return filePath; }
    }

    //long型？調べる
    public long ld;
    //
    public string name;
    //List型？調べる
    public List<int> list;
    public int[] array;
}