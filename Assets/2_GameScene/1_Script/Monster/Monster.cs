using UnityEngine;
using UnityEditor;
using System.Collections;

public class Monster : MonoBehaviour {

	public PlayerMove _PlayerSc = null;

	public GameObject _ParentGams = null;
	public GameObject _ArrowGams = null;

	public Transform _CharTr = null;

	public Rigidbody2D _MonsterRig2D = null;

	public BoxCollider2D _MonsterAttackBc = null;

	Vector3 dir = Vector3.zero;

	public int _nMovePosRand = 0;
	public int _nMonsterHp = 0;

	public float _fMonsterSpeed= 0.0f;
	float angle = 0.0f;
	float _fPlayerDistance = 0.0f;
	float _fArrowTimeSave = 0.0f;
	float _fArrowShootingDelay =0.0f;

	public bool _bPlayerChasing = false;
	public bool _bAttackAccess = false;
	public bool _bRemoteArrowDelay = false;
	public bool _bRangePlayer = false;

	// Use this for initialization
	void Start () {
		_ParentGams =  this.gameObject.transform.parent.gameObject;
		_PlayerSc = GameObject.Find ("Player").GetComponent<PlayerMove> ();
		_MonsterRig2D = this.gameObject.transform.parent.GetComponent<Rigidbody2D> ();
		_CharTr = GameObject.Find ("PlayerParent").transform;
		_ArrowGams = (GameObject)AssetDatabase.LoadAssetAtPath ("Assets/2_GameScene/3_Prefabs/Arrow.prefab", typeof(GameObject));
		_fArrowShootingDelay = 2.0f;					//원거리 발사 속도
		//_MonsterAttackBc = transform.FindChild ("MonsterAttack").GetComponent<BoxCollider2D> ();
		StartCoroutine (PosChange ());
		if (gameObject.name == "AssasinMonster") {
			_fMonsterSpeed = 3.0f;
			_nMonsterHp = 50;
		} else if (gameObject.name == "TankMonster") {
			_fMonsterSpeed = 1.5f;
			_nMonsterHp = 150;
		} else {
			_fMonsterSpeed = 1.0f;
			_nMonsterHp = 100;
		}
	}
	
	// Update is called once per frame
	void Update () {
		MonsterMng ();
		HitRangePlayer ();
		if (this.gameObject.name == "RemoteMonster") {
			RemoteMonAttack ();
		}
	}

	void MonsterMng()
	{

		Vector2 _MonsterMoveVec = Vector2.zero;

		if (_bPlayerChasing) {
		 	dir = _CharTr.position - transform.position;

			angle = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.back);
		}
		else {
		
		}

		if (_nMovePosRand == 1) {
			//_ParentGams.transform.Translate (Vector2.up * _fMonsterSpeed * Time.deltaTime);
			_MonsterMoveVec.y += _fMonsterSpeed;
			transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		} 
		else if (_nMovePosRand == 2) {
			//_ParentGams.transform.Translate (Vector2.down * _fMonsterSpeed * Time.deltaTime);
			_MonsterMoveVec.y -= _fMonsterSpeed;
			transform.rotation = Quaternion.Euler (0f, 0f, 180f);
		}
		else if (_nMovePosRand == 3) {
			//_ParentGams.transform.Translate (Vector2.left * _fMonsterSpeed * Time.deltaTime);
			_MonsterMoveVec.x -= _fMonsterSpeed;
			transform.rotation = Quaternion.Euler (0f, 0f, 90f);
		}
		else if (_nMovePosRand == 4) {
			//_ParentGams.transform.Translate (Vector2.right * _fMonsterSpeed * Time.deltaTime);
			_MonsterMoveVec.x += _fMonsterSpeed;
			transform.rotation = Quaternion.Euler (0f, 0f, 270f);
		}
		_MonsterRig2D.velocity = _MonsterMoveVec;

		if (_nMonsterHp <= 0) {
			Destroy (gameObject);
		}

	}
		
	void RemoteMonAttack()
	{
		if (_bAttackAccess && _bRangePlayer) {
			ShootArrow ();
		}
	}

	void ShootArrow()
	{
		if (!_bRemoteArrowDelay) {
			_fArrowTimeSave = Time.time;
			Instantiate (_ArrowGams, _ParentGams.transform.localPosition, Quaternion.Euler (0f, 0f, angle - 270f));

			_bRemoteArrowDelay = true;
		}

		if (Time.time > _fArrowTimeSave + _fArrowShootingDelay) {                                //연사속도
			_bRemoteArrowDelay = false;
		}
	}

	void HitRangePlayer()
	{
		_fPlayerDistance = Vector3.Distance (_CharTr.position, transform.position);
		//if (this.gameObject.name == "RemoteMonster") {
			//if (_fPlayerDistance <= 7f) {
		//		Debug.Log (transform.name + "가 범위 안에 있음");
		//	} 
		//}
	}

	public IEnumerator PosChange()
	{
		if (_bPlayerChasing == false)
		{
			_nMovePosRand = Random.Range (1, 5);
			yield return new WaitForSeconds (1f);
			StartCoroutine(PosChange());
		}
	}
		void OnTriggerEnter2D(Collider2D col)
	{
		
	}

}