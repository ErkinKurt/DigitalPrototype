using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagger : MonoBehaviour {

	#region Singleton GameManagger

	private static GameManagger _instance;

	public static GameManagger Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject gm = new GameObject("GameManagggerLol");
				gm.AddComponent<GameManagger>();
			}

			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this; //singleton
	}

	#endregion

	//Game rule values
	public int soldierBeeResourceCost;
	public int workerBeeResourceCost;

	public int soldierBeeQuotaCost;
	public int workerBeeQuotaCost;

	public int maxBeeQuota;

}
