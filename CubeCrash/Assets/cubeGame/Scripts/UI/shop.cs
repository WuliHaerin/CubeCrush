using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {


	public static shop instace;
	int coin;


	// Use this for initialization
	void Start ()
	{
		instace = this;

	}


	public GameObject AdPanel;

	public bool spendCoin(int cost)
	{
		coin = save.instance.load("coin");

		if(coin>=cost)
		{
			coin = coin-cost;
			save.instance.Save2 (coin,"coin");
			return true;
		}
		else
		{
			AdPanel.SetActive (true);
			return false;
		}
	}

}
