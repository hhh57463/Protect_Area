using UnityEngine;
using System.Collections;

public class ShotGunBulletParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (ShotGunBulletDestroy ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ShotGunBulletDestroy(){
		yield return new WaitForSeconds (5f);
		Destroy (gameObject);
	}

}
