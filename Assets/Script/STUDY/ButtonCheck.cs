using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//背面にあるオブジェクトも一緒に押されるケースの対策
//EventSystems.EventSystem.IsPointerOverGameObjectでボタンを選択中か判定し、選択中なら押さない事にする
//http://tsubakit1.hateblo.jp/entry/2015/04/10/012238
//EventSystems.EventSystem.IsPointerOverGameObjectの引数なしはマウス判定、引数ありはタッチ入力用です
//
public class ButtonCheck : MonoBehaviour
{

    //MaterialPropertyBlock block;

    void Start()
    {
      //  block = new MaterialPropertyBlock();
      //  block.SetColor("_Color", Color.red);
    }

    void OnMouseUp()
    {
        GetComponent<Renderer>().SetPropertyBlock(null);
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        GetComponent<Renderer>().SetPropertyBlock(null);
    }
}