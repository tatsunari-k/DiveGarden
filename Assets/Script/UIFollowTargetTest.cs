using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//あるオブジェクトに追随して表示されるGUIスクリプト
//SpaceScreen-orverlayのcanvasを持つオブジェクト内の動かしたいオブジェクトにアタッチして使用する。

public class UIFollowTargetTest : MonoBehaviour
{
    //変数定義。
    //Awakeの部分でスクリプト自身がアタッチされているRectTranceformを取得。今回だと、UICanvasのもの
    RectTransform rectTransform = null;
    //変数定義。インスペクター上で対応するオブジェクトをアタッチ。今回だと、TestとしてSphereをアタッチして使用。
    [SerializeField] Transform target = null;

    void Awake()
    {
        //定義した変数にコンポーネントを格納。
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        //UICanvasのpositionへアクセス。world座標からScreen-Overlay座標に変換。
        //第一引数：Cameraはmainカメラ。第二引数：変数target(Sphere)のposition。
        rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);
    }
}

//{
//    RectTransform rectTransform = null;
//    [SerializeField] Transform target = null;

//    [SerializeField]
//    Canvas canvas;

//    void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvas = GetComponent<Graphic>().canvas;
//    }

//    void Update()
//    {
//        var pos = Vector2.zero;
//        var uiCamera = Camera.main;
//        var worldCamera = Camera.main;
//        var canvasRect = canvas.GetComponent<RectTransform>();

//        var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, target.position);
//        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out pos);
//        rectTransform.localPosition = pos;
//    }
//}

