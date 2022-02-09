using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public PlayerMove _PlayerSc = null;

	public Text _PlayerHpText = null;

	public Slider _PlayerHpBar = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_PlayerHpText.text = "HP : " + _PlayerSc._nPlayerHp.ToString () + "%";
		_PlayerHpBar.value = (float)_PlayerSc._nPlayerHp / (float)_PlayerSc._nPlayerMaxHp;
	}
}
