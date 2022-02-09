using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

	public GameObject _PlayerParentGams = null;
	public GameObject _BulletPrefabs = null;
	public GameObject _DrainBulletPrefabs = null;
	public GameObject _ShotGunPrefabs = null;
	public GameObject _DrainShotGunPrefabs = null;
	public GameObject _GunGams = null;
	public GameObject _GunLineGams = null;
	public GameObject _ShotGunLineGams = null;
	public GameObject _NotEnoughBulletMsgGamse = null;
	public GameObject _ItemGetBtnGams = null;

	public Rigidbody2D _PlayerRig = null;

	public SpriteRenderer _GunSr = null;

	public Sprite[] _GunSprite = null;

	public int _nGunType = 0;
	public int _nRemnetBullet = 0;
	public int _nDrainBullet = 0;
	public int _nPlayerMaxHp = 0;
	public int _nPlayerHp = 0;
	public int _nSkill = 0;

	public float _fPlayerSpeed = 0.0f;
	float _fRotateDegree = 0.0f;
	float _fBulletTimeSave = 0.0f;
	float _fBulletDelay = 0.0f;					//소지하고 있는 총의 딜레이(임시임)

	bool _bPlayerDie = false;
	public bool _bDamageAccess = false;
	bool _bBulletShootDelay = false;
	public bool _bItemGet = false;
	public bool _bSpeedSkillOn = false;
	public bool _bAdrenalineSkillOn = false;
	public bool _bDrainBloodSkillOn = false;


	// Use this for initialization
	void Start () {
		_nSkill = 3;
		_fPlayerSpeed = 5.0f;
		_fBulletDelay = 0.5f;
		_nRemnetBullet = 10;
		_nPlayerMaxHp = 100;
		_nPlayerHp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerState ();
		Move();
		PlayerRotate();	
		GunSpriteChange ();
		PlayerGunMng ();
	}

	void PlayerState()
	{
		if (_nPlayerHp <= 0) {
			_bPlayerDie = true;
		}

		if (_bPlayerDie) {
			_nPlayerHp = 0;
		}
	}

	void Move()
	{
		Vector2 _PlayerMoveVec = Vector2.zero;
		if (Input.GetKey (KeyCode.W)) {
			//_PlayerParentGams.transform.Translate (Vector2.up * _fPlayerSpeed * Time.deltaTime);
			_PlayerMoveVec.y+=_fPlayerSpeed;
		}
		if (Input.GetKey (KeyCode.S)) {
			//_PlayerParentGams.transform.Translate (Vector2.down * _fPlayerSpeed * Time.deltaTime);
			_PlayerMoveVec.y-=_fPlayerSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			//_PlayerParentGams.transform.Translate (Vector2.left * _fPlayerSpeed * Time.deltaTime);
			_PlayerMoveVec.x-=_fPlayerSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			//_PlayerParentGams.transform.Translate (Vector2.right * _fPlayerSpeed * Time.deltaTime);
			_PlayerMoveVec.x+=_fPlayerSpeed;
		}
		_PlayerRig.velocity = _PlayerMoveVec;

		if (_nGunType == 0 || _nGunType == 4) {
			if (Input.GetMouseButtonDown (0)) {
				if (_nRemnetBullet > 0 || _nDrainBullet > 0) {
					_GunLineGams.SetActive (true);
				} else if (_nRemnetBullet <= 0 && _nDrainBullet <= 0) {
					_NotEnoughBulletMsgGamse.SetActive (true);
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				if (_nRemnetBullet > 0 || _nDrainBullet > 0) {
					_GunLineGams.SetActive (false);
					ShootingBullet (_fBulletDelay);
				}
			}
		} 
		else if (_nGunType == 3) {
			if (Input.GetMouseButtonDown (0)) {
				if (_nRemnetBullet > 0 || _nDrainBullet > 0) {
					_ShotGunLineGams.SetActive (true);
				} else if (_nRemnetBullet <= 0 && _nDrainBullet <= 0) {
					_NotEnoughBulletMsgGamse.SetActive (true);
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				if (_nRemnetBullet > 0 || _nDrainBullet > 0) {
					_ShotGunLineGams.SetActive (false);
					ShootingBullet (_fBulletDelay);
				}
			}
		}
		else {
			if (Input.GetMouseButton (0)) {
				ShootingBullet (_fBulletDelay);

				if (_nRemnetBullet <= 0 && _nDrainBullet <= 0) {
					_NotEnoughBulletMsgGamse.SetActive (true);
				}
			}
		}
	}

	void PlayerSkill()
	{
		switch (_nSkill) {
		case 0:											//비어있는 상태
			
			break;

		case 1:											//이속 증가
			
			break;

		case 2:											//아드레날린 폭주
			
			break;

		case 3:											//흡혈 총알
			
			break;

		case 4:											//방어
			
			break;

		case 5:											//순간이동
			
			break;

		case 6:											//포탑
			
			break;

		}

	}

	void PlayerGunMng()
	{
		if (_nGunType == 0) {
			_fBulletDelay = 1.0f;	
		} 
		else if (_nGunType == 1) {
			_fBulletDelay = 0.05f;	
		} 
		else if (_nGunType == 2) {
			_fBulletDelay = 0.1f;	
		} 
		else if (_nGunType == 3) {
			_fBulletDelay = 1.0f;	
		} 
		else if (_nGunType == 4) {
			_fBulletDelay = 2.0f;	
		} 
		else if (_nGunType == 5) {
			_fBulletDelay = 0.05f;	
		}


		if (_nDrainBullet <= 0) {
			_bDrainBloodSkillOn = false;
		}


	}

	void GunSpriteChange()
	{

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_nGunType = 0;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			_nGunType = 1;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			_nGunType = 2;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			_nGunType = 3;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			_nGunType = 4;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			_nGunType = 5;
		}

		if (_nGunType == 0) {
			_GunSr.sprite = _GunSprite [0];
		} else if (_nGunType == 1) {
			_GunSr.sprite = _GunSprite [1];
		} else if (_nGunType == 2) {
			_GunSr.sprite = _GunSprite [2];
		} else if (_nGunType == 3) {
			_GunSr.sprite = _GunSprite [3];
		} else if (_nGunType == 4) {
			_GunSr.sprite = _GunSprite [4];
		} else if (_nGunType == 5) {
			_GunSr.sprite = _GunSprite [5];
		}
	}

	void ShootingBullet(float fDelay)
	{
		if (!_bAdrenalineSkillOn) {
			if (!_bDrainBloodSkillOn) {
				if (!_bBulletShootDelay && _nRemnetBullet > 0) {										//일반총알
					_fBulletTimeSave = Time.time;

					_nRemnetBullet -= 1;						//총알 카운팅
					if (_nGunType == 3) {
						Instantiate (_ShotGunPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
					} else {
						Instantiate (_BulletPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
					}

					_bBulletShootDelay = true;
			
				}

				if (Time.time > _fBulletTimeSave + fDelay) {                                //연사속도
					_bBulletShootDelay = false;
				}
			} else if (!_bBulletShootDelay && _nDrainBullet > 0) {										//흡혈총알
				_fBulletTimeSave = Time.time;

				_nDrainBullet -= 1;						//총알 카운팅
				if (_nGunType == 3) {
					Instantiate (_DrainShotGunPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
				} else {
					Instantiate (_DrainBulletPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
				}

				_bBulletShootDelay = true;

			}

			if (Time.time > _fBulletTimeSave + fDelay) {                                //연사속도
				_bBulletShootDelay = false;
			}
		}
		else {
			if (!_bDrainBloodSkillOn) {
				if (_nGunType == 3) {
					Instantiate (_ShotGunPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
				} else {
					Instantiate (_BulletPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
				}
			} 
			else {
				if (_nGunType == 3) {
					Instantiate (_DrainShotGunPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
				} else {
					Instantiate (_DrainBulletPrefabs, _PlayerParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, _fRotateDegree - 90f));
				}
			}
		}
	}
		

	void PlayerRotate()
	{
		Vector3 mPosition = Input.mousePosition;
		Vector3 oPosition = transform.position;

		mPosition.z = oPosition.z - Camera.main.transform.position.z;

		Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

		float dy = target.y - oPosition.y;
		float dx = target.x - oPosition.x;
		_fRotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0f, 0f, _fRotateDegree);
	}
		
	IEnumerator DmgAccess(){
		yield return new WaitForSeconds (1.5f);
		Debug.Log ("데미지 입을 수 있음");
		_bDamageAccess = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{

	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Item"))			{
			Debug.Log ("아이템을 획득하려면 f키를 누르시오");	
		}

		if (col.tag == "Arrow") {
			if (!_bDamageAccess) {
				StartCoroutine (DmgAccess ());
				_bDamageAccess = true;
			}
		}

	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.transform.tag == "Monster") {
			Debug.Log ("ㅊㄷ");
			if (!_bDamageAccess) {
				if (_nPlayerHp > 0) 
				{
					_nPlayerHp -= 10;
				}
				StartCoroutine (DmgAccess ());
				_bDamageAccess = true;
			}
		}
	}

	public void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Item")) {
			_ItemGetBtnGams.SetActive (true);
			//if (Input.GetKeyDown (KeyCode.F)) {
			//	_nRemnetBullet += 300;
			//	Destroy (col.gameObject);

			if (_bItemGet) {
				_bItemGet = false;
				_ItemGetBtnGams.SetActive (false);
				Destroy (col.gameObject);
			} 

			else {

			}

		
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Item")) {
			_ItemGetBtnGams.SetActive (false);
		}
	}

}

