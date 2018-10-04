using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableComponents : MonoBehaviour
{
    private Light myLight;
    //TransformScan transformscan;


    void Start()
    {
        myLight = GetComponent<Light>();
        //transformscan = GetComponent<TransformScan>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //transformscan.enabled = !transformscan.enabled;
            myLight.enabled = !myLight.enabled;
        }
    }
}


//public class EnableComponents : MonoBehaviour
//{
//    private Light myLight;


//    void Start()
//    {
//        myLight = GetComponent<Light> ();
//    }


//    void Update()
//    {
//        if (Input.GetKeyUp(KeyCode.Space))
//        {
//            GetComponent(スクリプト名).enabled = true;
//            myLight.enabled = !myLight.enabled;
//        }
//    }
//}

