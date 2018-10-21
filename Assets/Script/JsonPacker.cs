using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonPacker : MonoBehaviour
{
    //SaveDataクラスで作成した_dataがポイント
    //これをStartでLoadFronJsonを利用して保存しているJsonデータのFilePathを呼び出しアクセスする
    public SaveData _data;
    public long id;
    public string  dataname;
    public List<int> list;
    public int[] array;

    private void Start()
    {
        Debug.Log(SaveData.FilePath);
        _data = LoadFromJson(SaveData.FilePath);
        id = _data.ld;
        dataname = _data.name;
        list = _data.list;
        array = _data.array;
    }

    private void Update()
    {
        //とりあえずSaveDataに何もなかったら何もやらない.
        if (_data == null) return;
        //&&はand ||はorを意味する。!=はノットイコールの意味
        //ここだと、data内のldとidが同じ値でない時か _data.nameとdatanameが同じでないときにtrue
        //SaveData内のldとここで定義しているidが同じでないのを確認して実行する処理。
        if (_data.ld != id || _data.name != dataname)
        {//エディタ上でid,nameを変更したらデータを書き換える.
            //この処理でStartで代入処理がうまくいっていないものを処理しなおす？
            //JsonPacker内のデータが最新となるので、下記スクリプトで更新を実行する。

            _data.ld = id;
            _data.name = dataname;
        }
    }

    /// <summary>
    /// アプリケーション終了時に呼ばれる
    /// </summary>
    private void OnApplicationQuit()
    {
        //SaveDataクラスのFilrPath
        SaveToJson(SaveData.FilePath, _data);
    }

    /// <summary>
    /// ファイル書き込み
    /// </summary>
    /// <param name="filePath">ファイルのある場所</param>
    public static void SaveToJson(string filePath, SaveData data)
    {
        //ここの処理も不明。要検索
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(JsonUtility.ToJson(data));
            }
        }
    }

    /// <summary>
    /// ファイル読み込みする
    /// </summary>
    /// <param name="filePath">ファイルのある場所</param>
    /// <returns></returns>
    public static SaveData LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {//ファイルがない場合FALSE.
            Debug.Log("FileEmpty!");
            return new SaveData();//ファイルが無いときは適当に処す.
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                SaveData sd = JsonUtility.FromJson<SaveData>(sr.ReadToEnd());
                if (sd == null) return new SaveData();
                return sd;
            }
        }
    }
}