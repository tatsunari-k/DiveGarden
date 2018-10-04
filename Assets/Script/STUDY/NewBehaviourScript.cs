
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//イベントトリガーを利用してオブジェクトを消す方法
//イベントトリガーを利用すると、クリック操作を必要とせず、カーソルを合わせただけで、イベントの実行が可能。
//Event Triggerで呼び出す関数「Touch」はパブリック(public) なものとして宣言します。
//こうすると、スクリプトのクラス外からも呼び出せる。


public class Tomato : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Touch()
    {

        Destroy(this.gameObject);

    }

}