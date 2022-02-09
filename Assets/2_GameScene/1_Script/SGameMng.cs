using UnityEngine;
using System.Collections;

public class SGameMng : MonoBehaviour {

	private static SGameMng _Instance = null;

	public static SGameMng I
	{
		get
		{
			if (_Instance == null)
			{
				Debug.Log("instance is null");
			}
			return _Instance;
		}
	}

	void Awake()
	{
		_Instance = this;
	}


	public PlayerMove _PlayerSc = null;


	void Update()
	{
		if (_PlayerSc._nPlayerHp <= 0) {
			Debug.Log ("게임오버!");
		}
	}

}
