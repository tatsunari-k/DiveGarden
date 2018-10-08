using UnityEngine;

//不明
//https://www.urablog.xyz/entry/2017/04/28/213010

public class MouseDrag : MonoBehaviour
{
	void OnMouseDrag()
	{
		Vector3 objectPointInScreen
		= Camera.main.WorldToScreenPoint(this.transform.position);

		Vector3 mousePointInScreen
		= new Vector3(Input.mousePosition.x,
			Input.mousePosition.y,
			objectPointInScreen.z);

		Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
		mousePointInWorld.z = this.transform.position.z;
		this.transform.position = mousePointInWorld;
	}
}