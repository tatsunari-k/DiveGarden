using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//この中にボタンと連動させて、ゲームオブジェクトを切り替えていくスクリプトを作成したい。

//クリックしてRayを飛ばし、衝突したオブジェクトの座標を取得。その上にオブジェクトを設置するスクリプト

public class ObjectBuild : MonoBehaviour
{

    public FieldSell fieldsell;

    //GroundsPrefabを入れる
    //public Button Select;
    //testButton.onClick.AddListener(OnClickButton);
    public GameObject CreateObject = null;
    public GameObject Stonecell1;
    public GameObject Stonecell2;
    public GameObject Stonecell3;
    public GameObject Stonecell4;
    public GameObject Stonecell5;
    public GameObject test;
    public ObjectBuild test2;   //クラスを変数にしてインスタンス化。この変数にゲームオブジェクトを渡す関数を設定する。

    //いつの間にかできていたスクリプト
    //public object JsonUptadaObj { get; private set; }
    //public object JsonUpdata { get; private set; }

    public void CreateObjectSelect(int num)
    {
        Debug.Log("クリックされた");
        if (num == 1)
        {
            CreateObject = Stonecell1;
        }
        else if (num == 2)
        {
            CreateObject = Stonecell2;
        }
        else if (num == 3)
        {
            CreateObject = Stonecell3;
        }
        else if (num == 4)
        {
            CreateObject = Stonecell4;
        }

    }

    private void OnClick()
    {

    }


    //クリックしたオブジェクトを取得する関数(3D)
    //クリックしたオブジェクトを戻り値として返す処理が行われている。
    public GameObject getClickObject()
    {
        GameObject result = null;
        // 左クリックされた場所のオブジェクトを取得

        if (Input.GetMouseButtonDown(0))
        {
            //ray変数の定義　mainカメラScreenPointToRayからray発射。mousePisitionを返り値としてバック。
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHitクラスのインスタンス作成。変数hit
            RaycastHit hit = new RaycastHit();
            //もし、物理挙動にアクセス。Raycast(ray, out hit)
            //ここよくわからん
            if (Physics.Raycast(ray, out hit))
            {
                //result変数にhitしたオブジェクトのcolliderにアクセス。gameObjectを格納。
                result = hit.collider.gameObject;
            }
        }
        //戻り値としてhitしたgameObjectを戻す。
        return result;
    }


    // Use this for initialization
    void Start()
    {
        //FieldSellスクッリプ内 FieldSellクラスよりblockData1変数の取得
        //GameObject UptadaObjname = CreateObjectSelect;
    }

    void Update()
    {
        //GameObjectクラス　obj変数定義。　getClickObject();関数を格納。
        //つまり、クリックしたオブジェクトを格納している。
        GameObject obj = getClickObject();
        //obj変数は空っぽと異なるか？　空っぽならfalse.何か格納されていたらtrue
        if (obj != null)
        {

            // 以下オブジェクトがクリックされた時の処理
            Debug.Log(obj.name);
            Debug.Log(obj.transform.position);
            //public int x = obj.transform.position.x;
            //public int x = 1
            //int x = 2; これは動く
            float x = obj.transform.position.x;
            float y = obj.transform.position.y;
            float z = obj.transform.position.z;
            //セットするオブジェクトのy座標分を定義posで座標を指定する際に、
            //Rayで取得した座標＋オブジェクトの高さで適切な位置にオブジェクトを設置する。
            float hight = obj.transform.localScale.y;
            Vector3 pos = new Vector3(x, y += hight, z);
            Instantiate(CreateObject, pos, Quaternion.identity);


            //Jsonの更新
            // FieldSellクラスのblockData1にアクセス
            GameObject UpdadaObj = CreateObject;//作成オブジェクトを格納。
            string UpdataObjName = UpdadaObj.name;//なぜオブジェクトの名前を取得できない？
            //FieldSellクラスのblockData1内のデータにアクセス。
            //アクセス先はオブジェクトを生成する座標を元に、同様の配列部を指定。JsonUpdataにアクセスしblockData1内の座標及びオブジェクト名を更新。
            fieldsell.blockData1[x, y += hight, z].Block.JsonUpdata(x, y += hight , z , UpdataObjName);

            //三次元配列を一次元配列に変換する必要有。
            itemArray2[index] = blockData1[x, y, z];

            // jsonに変換
            string json = JsonHelper.ToJson<Block>(fieldsell.itemArray2, true);

            Debug.Log(json);

        }
    }
}
