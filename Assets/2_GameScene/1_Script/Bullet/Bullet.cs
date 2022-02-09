using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	//public Monster _MonsterSc = null;
	public PlayerMove _PlayerSc = null;

	public Transform _BulletTr = null;

	private float _fBulletSpeed = 0.0f;

	public bool _bDrainBulletOn = false;

	// Use this for initialization
	void Start () {
		_PlayerSc = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		_BulletTr = GameObject.Find ("Map").transform;
		transform.parent = _BulletTr.transform;
		_fBulletSpeed = 20.0f;
		StartCoroutine (BulletDestroy ());
		if (this.gameObject.name == "Bullet(Clone)" || this.gameObject.name == "ShotGunBullet") {
			_bDrainBulletOn = false;
		} 
		else if (this.gameObject.name == "DrainBullet(Clone)" || this.gameObject.name == "DrainShotGunBullet") {
			_bDrainBulletOn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		BulletMove();
	}

	void BulletMove(){	
		transform.Translate (Vector2.up * _fBulletSpeed * Time.deltaTime);
	}

	IEnumerator BulletDestroy(){
		yield return new WaitForSeconds (5f);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Obstacle") || col.CompareTag("Monster") || col.CompareTag("Wall")) {
			Destroy (gameObject);
		}

		if (col.CompareTag ("Monster")) {
			Monster _MonsterSc = col.gameObject.GetComponent<Monster> ();

			if (_PlayerSc._nGunType == 0) {
				_MonsterSc._nMonsterHp -= 10;
				if (_bDrainBulletOn) {
					_PlayerSc._nPlayerHp += 10;
				}
			} else if (_PlayerSc._nGunType == 1) {
				_MonsterSc._nMonsterHp -= 10;
				if (_bDrainBulletOn) {
					_PlayerSc._nPlayerHp += 6;
				}
			} else if (_PlayerSc._nGunType == 2) {
				_MonsterSc._nMonsterHp -= 30;
				if (_bDrainBulletOn) {
					_PlayerSc._nPlayerHp += 5;
				}
			} else if (_PlayerSc._nGunType == 3) {
				_MonsterSc._nMonsterHp -= 10;
				if (_bDrainBulletOn) {
					_PlayerSc._nPlayerHp += 4;
				}
			} else if (_PlayerSc._nGunType == 4) {
				_MonsterSc._nMonsterHp -= 50;
				if (_bDrainBulletOn) {
					_PlayerSc._nPlayerHp += 20;
				}
			} else if (_PlayerSc._nGunType == 5) {
				_MonsterSc._nMonsterHp -= 30;
				if (_bDrainBulletOn) {
					_PlayerSc._nPlayerHp += 3;
				}
			}

		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		
	}

	void OnTriggerExit2D(Collider2D col)
	{

	}

}
