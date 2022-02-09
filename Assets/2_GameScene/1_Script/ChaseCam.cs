using UnityEngine;
using System.Collections;

public class ChaseCam : MonoBehaviour {

	public GameObject _Target = null;

	public PlayerMove _PlayerSc = null;

	public float _fCamZpos = -10f;
	float _fCamSpeed = 0.0f;

	void Awake()
	{
		_fCamSpeed = 2.0f;
	}

	void Update(){
		if (_PlayerSc._bSpeedSkillOn) {
			_fCamSpeed = 5.0f;
		}
		else {
			_fCamSpeed = 2.0f;
		}
	}

	void FixedUpdate(){
		Vector3 TargetPos = new Vector3 (_Target.transform.position.x, _Target.transform.position.y, _fCamZpos);
		//if (
		//	(_Target.transform.localPosition.x <= 9.5f && _Target.transform.localPosition.y <= 11.5f) &&
		//	(_Target.transform.localPosition.x <= 9.5f && _Target.transform.localPosition.y >= -11.5f) &&
		//	(_Target.transform.localPosition.x >= -9.5f && _Target.transform.localPosition.y <= 11.5f) &&
		//	(_Target.transform.localPosition.x >= -9.5f && _Target.transform.localPosition.y >= -11.5f)
		//) {
		transform.position = Vector3.Lerp (transform.position, TargetPos, Time.deltaTime * _fCamSpeed);
		//}
	}
}
