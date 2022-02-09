using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Char"))
		Debug.Log ("플레이어가 " + transform.name + "에 들어옴");
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Char"))
		Debug.Log ("플레이어가 " + transform.name + "에 들어와있음");
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Char"))
		Debug.Log ("플레이어가 " + transform.name + "에서 나감");
	}

}
