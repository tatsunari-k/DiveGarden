using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//http://tsubakit1.hateblo.jp/entry/2016/03/01/020510


public class UIFollowTargetSUB: MonoBehaviour
{

    //private ObjectBuild testobjecttmp = null;

    public GameObject TestObject;
    RectTransform rectTransform = null;
    [SerializeField] Transform target = null;
 

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        //target = testobjecttransform;
        //Vector3 testobjecttmp = GameObject.Find("TestObject").transform.position;
        //GameObject.Find("TestObject").transform.position = new Vector3 (TestObject.transform.2,);
 
        //rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);


        //Vector3 tmp = GameObject.Find("hogehoge").transform.position;
        //GameObject.Find("hogehoge").transform.position = new Vector3(tmp.x + 100, tmp.y, tmp.z);
    }
}
