using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour{

    //Animation anim;

    // Use this for initialization
    //void Start()
    //{
    //    anim = this.gameObject.GetComponent<Animation>();

    //}

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        //anim.Play();
        Debug.Log("押された!");  // ログを出力
    }
}
