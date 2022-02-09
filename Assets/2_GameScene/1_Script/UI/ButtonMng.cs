using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonMng : MonoBehaviour {

	public GameObject _ItemGetBtnGams = null;
	public GameObject _ItemBtnImgGams = null;
	public GameObject _PlayerSkillParentGams = null;
	public GameObject _ShiledPre = null;
	public GameObject _BoostTimeGams = null;
	public GameObject _AdrenalineTimeGams = null;
	public GameObject _ShiledTimeGams = null;

	public PlayerMove _PlayerSc = null;

	public Image _ItemBtnImg = null;

	public Sprite[] _ItemSr = new Sprite[7];


	public void SkillBtn()
	{
		switch (_PlayerSc._nSkill) {
		case 0:											//비어있는 상태

			break;

		case 1:											//이속 증가
			//_PlayerSkillSc.SpeedUp();
			_ItemBtnImgGams.SetActive (false);
			_BoostTimeGams.SetActive (true);
			break;

		case 2:											//아드레날린 폭주
			_ItemBtnImgGams.SetActive (false);
			_AdrenalineTimeGams.SetActive (true);
			break;

		case 3:											//흡혈 총알
			_ItemBtnImgGams.SetActive (false);
			_PlayerSc._bDrainBloodSkillOn = true;
			DrainSkillBulletPay ();
			break;

		case 4:											//방어
			_ItemBtnImgGams.SetActive (false);
			_ShiledTimeGams.SetActive (true);
			Instantiate (_ShiledPre, _PlayerSkillParentGams.transform.position, Quaternion.Euler (0f, 0f, 0f));
			break;

		case 5:											//순간이동

			break;

		case 6:											//포탑

			break;

		}
	}

	public void GetItemBtn()
	{
		_PlayerSc._bItemGet = true;

		switch (_PlayerSc._nSkill) {
		case 0:											//비어있는 상태

			break;

		case 1:											//이속 증가
			_ItemBtnImg.sprite = _ItemSr [1];
			_ItemBtnImgGams.SetActive (true);
			break;

		case 2:											//아드레날린 폭주
			_ItemBtnImg.sprite = _ItemSr [2];
			_ItemBtnImgGams.SetActive (true);
			break;

		case 3:											//흡혈 총알
			_ItemBtnImg.sprite = _ItemSr [3];
			_ItemBtnImgGams.SetActive (true);
			break;

		case 4:											//방어
			_ItemBtnImg.sprite = _ItemSr [4];
			_ItemBtnImgGams.SetActive (true);
			break;

		case 5:											//순간이동

			break;

		case 6:											//포탑

			break;

		}
		//_ItemGetBtnGams.SetActive (false);
	}

	public void DrainSkillBulletPay()
	{
		switch (_PlayerSc._nGunType) {
		case 0:											//Pistol
			_PlayerSc._nDrainBullet = 10;
			break;

		case 1:											//SMG
			_PlayerSc._nDrainBullet = 15;
			break;

		case 2:											//Ar
			_PlayerSc._nDrainBullet = 20;
			break;

		case 3:											//ShotGun
			_PlayerSc._nDrainBullet = 5;
			break;

		case 4:											//Sr
			_PlayerSc._nDrainBullet = 5;
			break;

		case 5:											//EventGun
			_PlayerSc._nDrainBullet = 30;
			break;

		}

	}

}