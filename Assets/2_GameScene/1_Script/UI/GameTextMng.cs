using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTextMng : MonoBehaviour {

	public PlayerMove _PlayerSc = null;

	public Text _PlayerRemnantBullet = null;
	public Text _GunTypeText = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!_PlayerSc._bDrainBloodSkillOn) {
			_PlayerRemnantBullet.text = _PlayerSc._nRemnetBullet.ToString ();
		}
		else {
			_PlayerRemnantBullet.text = _PlayerSc._nRemnetBullet.ToString () +" + " + _PlayerSc._nDrainBullet.ToString ();
		}
		if (_PlayerSc._nGunType == 0) {
			_GunTypeText.text = "Pistol";
		} else if (_PlayerSc._nGunType == 1) {
			_GunTypeText.text = "SMG";
		} else if (_PlayerSc._nGunType == 2) {
			_GunTypeText.text = "AR";
		} else if (_PlayerSc._nGunType == 3) {
			_GunTypeText.text = "Shot Gun";
		} else if (_PlayerSc._nGunType == 4) {
			_GunTypeText.text = "SR";
		} else if (_PlayerSc._nGunType == 5) {
			_GunTypeText.text = "Event Riple";
		}
	}
}
