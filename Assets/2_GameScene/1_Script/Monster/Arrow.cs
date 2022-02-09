using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public PlayerMove _PlayerSc = null;

	public Transform _CharTr = null;
	public Transform _MapTr = null;

	public float _fArrowSpeed = 0.0f;

	// Use this for initialization
	void Start () {
		_PlayerSc = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		_MapTr = GameObject.Find ("Map").transform;
		_CharTr = GameObject.Find ("PlayerParent").transform;
		transform.parent = _MapTr.transform;
		_fArrowSpeed = 20.0f;
		StartCoroutine (ArrowDestroy ());

		Vector3 dir = _CharTr.position - transform.position;

		float angle = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.back);
	}
	
	// Update is called once per frame
	void Update () {
		ArrowMove ();

	}

	void ArrowMove(){	
		transform.Translate (Vector2.up * _fArrowSpeed * Time.deltaTime);
	}

	IEnumerator ArrowDestroy(){
		yield return new WaitForSeconds (5f);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Char")) {
			if (!_PlayerSc._bDamageAccess) {
				if (_PlayerSc._nPlayerHp > 0) {
					_PlayerSc._nPlayerHp -= 30;
				} 
			}
			Destroy (gameObject);
		}
	}
}
