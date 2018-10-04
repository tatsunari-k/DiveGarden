using UnityEngine;
using System.Collections;

public class rayhitdebug__ : MonoBehaviour
{

    //検知用レイ
    private RaycastHit Hit;

    void Update()
    {
        //Physics.Raycast：シーンにあるすべてのコライダーに対して、 origin の位置から direction の方向に maxDistance の距離だけレイを投じます。
        //戻り値：bool レイが任意のコライダーと交わる場合は true、それ以外は false
        //transform.position：ワールド空間の Transform の位置
        //パラメーター:ワールド座標でのレイの開始地点 , レイの方向 , レイが衝突を検知する最大距離 , 選択的に衝突を無視するために使用 , トリガーに設定されているものも検索対象にするか
        //Vector3.down：Vector3(0, -1, 0) と同じ意味
        //out(出力パラメーター)：メソッドの引数定義にoutを指定することで、その引数を出力用の変数として宣言することができる
        //

        if (Physics.Raycast(transform.position, Vector3.down, out Hit))
        {

            Debug.Log(Hit.point);//デバッグログにヒットした場所を出す

        }

    }

}