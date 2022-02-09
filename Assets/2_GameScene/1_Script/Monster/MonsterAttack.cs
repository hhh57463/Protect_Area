using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public Monster _SelfMonsterSc = null;
	public PlayerMove _PlayerSc = null;

	public float _fAttackTimeSave = 0.0f;
	public float _fAttackDelay = 0.0f;

	public bool _bMonsterAttackDelay = false;

	// Use this for initialization
	void Start () {
		_fAttackDelay = 1.0f;
		_SelfMonsterSc = this.gameObject.transform.parent.gameObject.GetComponent<Monster> ();
		_PlayerSc = GameObject.Find ("Player").GetComponent<PlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackMonster()
	{
		if (!_bMonsterAttackDelay) {
			_fAttackTimeSave = Time.time;
			_bMonsterAttackDelay = true;
			_SelfMonsterSc._MonsterAttackBc.enabled = true;
		}
		if (Time.time > _fAttackTimeSave + _fAttackDelay) {
			_bMonsterAttackDelay = false;
			_SelfMonsterSc._MonsterAttackBc.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Char")) {
			_PlayerSc._bDamageAccess = true;
			_PlayerSc._nPlayerHp -= 10;
			_SelfMonsterSc._bAttackAccess = false;
			AttackMonster ();
		}
	}
}
