using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachWeapon : MonoBehaviour {


	public bool rightHand = true;
	public bool midHand = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position = GameManger.instace.heroGo.transform.position + new Vector3 (2, 0, 0);
	}

	void FixedUpdate () {
		if(rightHand)
		{
			this.transform.position = GameManger.instace.heroGo.transform.position + new Vector3 (0.7f, 0, 0.4f);
		}
		else if(midHand)
		{
			this.transform.position = GameManger.instace.heroGo.transform.position + new Vector3 (0f, 2, 0f);
		}
		else
		{
			this.transform.position = GameManger.instace.heroGo.transform.position + new Vector3 (-1f, 0, 0.1f);
		}


	}

}
 