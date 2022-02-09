using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterRange : MonoBehaviour {

	public GameObject _SelfGams = null;
	public GameObject _PlayerGams = null;

	public Monster _MonsterSc = null;


	// Use this for initialization
	void Start () {
		_PlayerGams = GameObject.Find ("PlayerParent");
		_SelfGams = this.gameObject.transform.parent.gameObject;
		_MonsterSc = this.gameObject.transform.parent.gameObject.GetComponent<Monster> ();
	}
	
	// Update is called once per frame
	void Update () {
		MonsterChasing ();

	}

	void MonsterChasing(){
		if (_MonsterSc._bPlayerChasing == false) {

		} else {
			if (_SelfGams.name == "RemoteMonster") {
				_MonsterSc._bAttackAccess = true;
			} else {
				_SelfGams.transform.position = Vector3.Lerp (transform.position, _PlayerGams.transform.localPosition, _MonsterSc._fMonsterSpeed * Time.deltaTime);
			}
		}
	}

	IEnumerator AttackStart()
	{
		yield return new WaitForSeconds (1f);
		_MonsterSc._bAttackAccess = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Char"))
		{		
			_MonsterSc._bPlayerChasing = true;
			_MonsterSc._bRangePlayer = true;
			StartCoroutine (AttackStart ());
			_MonsterSc._nMovePosRand = 0;
			StopCoroutine (_MonsterSc.PosChange ());
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Char"))			
		{
			_MonsterSc._bPlayerChasing = false;
			_MonsterSc._bRangePlayer = false;
			_MonsterSc._bAttackAccess = false;
			StartCoroutine (_MonsterSc.PosChange ());
		}
	}
}