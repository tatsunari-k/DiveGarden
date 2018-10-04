using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuild : MonoBehaviour {

    //GroundsPrefabを入れる
    public GameObject CreateObject;

    //クリックしたオブジェクトを取得する関数(3D)
    //クリックしたオブジェクトを戻り値として返す処理が行われている。
    public GameObject getClickObject() {
           GameObject result = null;
        // 左クリックされた場所のオブジェクトを取得
   
        if (Input.GetMouseButtonDown(0)) {
            //ray変数の定義　mainカメラScreenPointToRayからray発射。mousePisitionを返り値としてバック。
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHitクラスのインスタンス作成。変数hit
            RaycastHit hit = new RaycastHit();
            //もし、物理挙動にアクセス。Raycast(ray, out hit)
            //ここよくわからん
            if (Physics.Raycast(ray, out hit)){
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
            float hight = obj.transform.localScale.y;
            Vector3 pos = new Vector3(x, y += hight, z);
            Instantiate(CreateObject, pos, Quaternion.identity);
        }
    }
}

//TouchScreenPosition変数を定義。mouseの位置を格納

//Vector2 touchScreenPosition = Input.mousePosition;
    //スクリーン上の位置xyそれぞれのclampすることで、画面の端以上にポインターが行かないように指定
    //touchScreenPosition.x  = Mathf.Clamp(touchScreenPosition.x, 0.0f, Screen.width );
    //touchScreenPosition.y  = Mathf.Clamp(touchScreenPosition.y, 0.0f, Screen.height );
    //gameCamera変数を定義mainカメラのを格納
    //Camera gameCamera = Camera.main;
    //touchPointToRay変数を定義。mainカメラからRayを発射。上記で定義したマウスで指し示している座標に発射。
    //Ray touchPointToRay = gameCamera.ScreenPointToRay(touchScreenPosition);
    //hitInfo変数を定義。RaycastHitのインスタンスを格納
    //RaycastHit hitInfo = new RaycastHit();
        //touchPointToRay  ここの処理が不明？
        //if(Physics.Raycast(touchPointToRay, out hitInfo ) )
        //{   //オブジェクトRaycastHitの情報を
        //    Object.transform.position = hitInfo.point;
        //}



