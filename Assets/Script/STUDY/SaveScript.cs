using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//データ保存について学ぶ際に利用
//文字入力UIを作成し、そこにテキストを表示させるというスクリプト
//http://hiyotama.hatenablog.com/entry/2015/05/22/173402
//ボタンを押した時にSaveTextメソッドが実行され、
//InputFieldオブジェクトに入力されたテキストをstring型変数strへ保存.
//その後それをTextオブジェクトのtextに代入して表示しているという形〜最後にInputFieldのテキストは初期化

//文字を保存するスクリプトを追記
//

public class SaveScript : MonoBehaviour {

    //********** 開始 **********// 
    string key = "SavedText";
    //********** 終了 **********// 

    string str;
    public InputField inputField;
    public Text Testtext;

    //********** 開始 **********// 
    void Start()
    {
        //保存キー「SavedText」で保存されたstring型のデータがあればそれを、
        //無ければブランクを取得
        //Testtext変数にアクセス。ヒエラルキー上でTesttext変数にアタッチしたオブジェクトのアクセス
        //Testtextオブジェクト内のtextコンポーネントにアクセス。その中に何を入れるかを指示。
        Testtext.text = PlayerPrefs.GetString(key, "");
        //********** 終了 **********// 
    }

        public void SaveText () {
        str = inputField.text;
            //********** 開始 **********//
            //保存キー「SavedText」で入力文字を保存
            PlayerPrefs.SetString(key, str);
            PlayerPrefs.Save();
            //********** 終了 **********// 
            Testtext.text = str;
        inputField.text = "";


    }
}