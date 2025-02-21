using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour {


	public static save instance;
	public  string fileName = "heroData.txt";
	// Use this for initialization

	void Awake()
	{
		instance = this;
	}
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void Save(int data,string Savetag)
	{

		int t = PlayerPrefs.GetInt (Savetag);
		t += data;

		PlayerPrefs.SetInt (Savetag, t);
	}

	public void Save2(int data,string Savetag)
	{		
	
		PlayerPrefs.SetInt (Savetag, data);
	}



	public int load(string loadTag)
	{
		int temp = PlayerPrefs.GetInt (loadTag);
		if(temp ==null || temp ==0)
		{
			return 0;
		}
		else
		{
			return temp;
		}
	}



	
}
