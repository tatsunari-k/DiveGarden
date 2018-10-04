using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//uGUIをキャラクターの頭上に表示（HUD）して、オブジェクトの移動に追従させる方法
//http://tech.pjin.jp/blog/2017/07/14/unity_ugui_sync_rendermode/
//CS0649：変数が未割り当てで初期値はxxx

//下記スクリプトはは下記メモに準ずるもの。
//別々のスクリプトを用意するのが面倒だったので、列挙型のRenderModeを使って一つのスクリプトにまとめてみました。
//RenderModeが切り替わっても自動で対応できます。


//CS0649は以下のコードで発生します。
//以下のコードではint配列numsを宣言だけして、Lengthプロパティを参照しています。
//numsに値が入っていないのに参照するとnumsの初期値を参照します。
//警告ではこの場合の初期値がnullだと言っています。
//当然このままだとnull参照エラーになりますので直せというわけです。
//要するに「このままだと初期値を使うけどいいの？」みたいな意味のようです。
//http://shirakamisauto.hatenablog.com/entry/2015/08/25/124205

//


public class ObjectTopUIController : MonoBehaviour
{




    //変数定義
    //定義した変数には一旦からっぽだよとnullを入れとく。
    //インスペクター上で紐付け

    [SerializeField]
    //canvasはインスペクター上で中身を入れる。orスクリプト上で入れるか…
    private Canvas canvas = null;
    [SerializeField]
    //targetTfmも一旦から。canvas同様インスペクター上で中身を入れる。orスクリプト上で入れるか…
    private Transform targetTfm = null;

    private RectTransform canvasRectTfm;
    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    void Start()
    {
        canvasRectTfm = canvas.GetComponent<RectTransform>();
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 pos;

        switch (canvas.renderMode)
        {
            //RenderModeがScreenSpaceOverlayのときの変換方法
            //メインカメラにアクセスして
            case RenderMode.ScreenSpaceOverlay:
                myRectTfm.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
                //不明
                break;
            //RenderModeがScreenSpaceCameraの場合の変換方法
                //

            case RenderMode.ScreenSpaceCamera:
                Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTfm, screenPos, Camera.main, out pos);
                myRectTfm.localPosition = pos;
                //不明。破壊している？
                break;

            //RenderMode.WorldSpaceのときの処理方法

            case RenderMode.WorldSpace:
                myRectTfm.LookAt(Camera.main.transform);

                break;
        }
    }
}