using UnityEngine;
using System.Collections;

public class SkillTime : MonoBehaviour {

	public PlayerMove _PlayerSc = null;

	public void BoostStart()
	{
		_PlayerSc._fPlayerSpeed = 10.0f;
		_PlayerSc._bSpeedSkillOn = true;
	}

	public void BoostEnd()
	{
		_PlayerSc._fPlayerSpeed = 5.0f;
		_PlayerSc._bSpeedSkillOn = false;
		gameObject.SetActive (false);
	}

	public void AdrenalineStart()
	{
		_PlayerSc._bAdrenalineSkillOn = true;
	}

	public void AdrenalineEnd()
	{
		_PlayerSc._bAdrenalineSkillOn = false;
		gameObject.SetActive (false);
	}

	public void ShiledStart()
	{
		_PlayerSc._bDamageAccess = true;
	}

	public void ShiledEnd()
	{
		_PlayerSc._bDamageAccess = false;
		gameObject.SetActive (false);
	}

}
