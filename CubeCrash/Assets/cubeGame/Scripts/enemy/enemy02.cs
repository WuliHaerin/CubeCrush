using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy02 : MonoBehaviour {


	public float atkSpeed = 2;
	private float TempAtkSpeed;

	private GameObject hero;
	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		atk ();
	}


	void atk()
	{
		if (GameManger.instace.isOver)
			return;
		LookAtHero ();

		if (hero == null)
			return;
		if (Vector3.Distance (transform.position, hero.transform.position) > 25)
		{			
			return;
		}			

		TempAtkSpeed += Time.deltaTime;
		if(TempAtkSpeed>atkSpeed)
		{			
			TempAtkSpeed = 0;		
			Transform ob = spawnObject.instance.GetCreatFx("bullet",transform,new Vector3 (0, 0.5f, 0.3f));
			spawnObject.instance.CreatFx ("atkExplosion",this.transform,new Vector3 (0, 1.5f, 0.3f));
			ob.rotation = transform.rotation;

			if(GameManger.instace.countMeter>=100 && GameManger.instace.countMeter<=200)
			{
				atkSpeed = 4;
			}
			if(GameManger.instace.countMeter>200 && GameManger.instace.countMeter<=300)
			{
				atkSpeed = 3;
			}
			if(GameManger.instace.countMeter>300 && GameManger.instace.countMeter<=400)
			{
				atkSpeed = 2.5f;
			}
			if(GameManger.instace.countMeter>500 && GameManger.instace.countMeter<=300)
			{
				atkSpeed = 2;
			}
		}
	}

	void LookAtHero()
	{
		if(hero==null)
		{
			hero = GameObject.FindWithTag ("hero");
		}
		else
		{
			transform.LookAt (hero.transform);
		}

	}



}
