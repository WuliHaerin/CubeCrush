using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comander : MonoBehaviour {

	public static comander  instance;

	// Use this for initialization

	void Start () {

		if(instance!=null)
		{
			Destroy (this);
			return;
		}
		instance = this;
		DontDestroyOnLoad (this.gameObject);

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		ADFinish ();
	}

	public bool seeAdTryFinish = false;
	public bool seeAdGetGoldFinish = false;
	public bool seeAdRset = false;
	public void ADFinish()
	{
		if(seeAdTryFinish)
		{
			seeAdTryFinish = false;
			UIstart.instance.SeeADTry ();
			//to do
		}
		if(seeAdGetGoldFinish)
		{
			seeAdGetGoldFinish = false;

			GameManger.instace.setSound (0.5f);
			save.instance.Save (23, "coin");
			GameManger.instace.setCoin (23);		
			Application.LoadLevel("start");
		}
		if(seeAdRset)
		{
			seeAdRset = false;
			GameManger.instace.seeAdReset ();
		}
	}




}
