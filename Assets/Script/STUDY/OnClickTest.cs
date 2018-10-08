using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnClick(){

        transform.Rotate(new Vector3(0, 0, 90));
        Debug.Log("クリックされた");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
