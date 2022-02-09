using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public GameObject _PlayerGams = null;

	// Use this for initialization
	void Start () {
		_PlayerGams = GameObject.Find ("PlayerParent");
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.localPosition = _PlayerGams.transform.localPosition;
	}

	public void ShiledAniEnd()
	{
		Destroy (gameObject);
	}

}
