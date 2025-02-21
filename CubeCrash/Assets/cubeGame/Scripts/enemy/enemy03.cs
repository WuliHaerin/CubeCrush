using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy03 : MonoBehaviour {

	private GameObject hero;
	private Vector3 heroPos;
	public float atkSpeed = 2;
	private float TempAtkSpeed;
	public bool CanJunp = false;
	public float jumpSpeed = 10;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManger.instace.isOver)
			return;
		atk ();

		if (hero == null)
			return;
		if(CanJunp)
		{
			if (Vector3.Distance (transform.position, hero.transform.position) > 10)
			{
				CanJunp = false;
				return;
			}
			else
			{
				jump ();

			}
		}
		if(transform.position.y<-0.1f &&  CanJunp )//reset the enemy
		{			
			transform.position = new Vector3 (transform.position.x,0,transform.position.z);
			CanJunp = false;
			jumpSpeed = 20;
		}
		
	}

	void atk()
	{	
		TempAtkSpeed += Time.deltaTime;
		if(TempAtkSpeed>atkSpeed)
		{		
			FindtHero ();	
			TempAtkSpeed = 0;
			CanJunp = true;
		}
	}

	 Vector3 FindtHero()
	{
		hero = GameObject.FindWithTag ("hero");
		if(hero)
		{
			heroPos = hero.transform.position;	
			return heroPos;
		}
		else
		{
			return heroPos;
		}
	}

	void jump()
	{		
		transform.position += transform.up * jumpSpeed * Time.deltaTime;
		transform.position = Vector3.Lerp (transform.position, new Vector3 (heroPos.x, 0, heroPos.z), Time.deltaTime*4f);
		jumpSpeed -= 15 * Time.deltaTime;
	}

}
