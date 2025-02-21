using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class heroContrl : MonoBehaviour {



	public static heroContrl instance;

	public Transform hero;
	public bool isLeft;
	public bool isRight;
	public bool forward=true;
	public float speed = 5f;


	public float process;
	public bool sMove =false;
	public bool canmove = true;

	RaycastHit hit;
	RaycastHit hitL01;
	RaycastHit hitL02;
	RaycastHit hitR01;
	RaycastHit hitR02;
	RaycastHit hitF01;
	RaycastHit hitF02;

	public bool isSword;
	public bool isShield;
	public bool isAxe;
	public bool isSpeed;
	public bool isFist;
	public bool dropWater = false;

	public bool hitLwall = false;
	public bool hitRwall = false;
	public bool isAliveOnce = false;

	float temAxeTime;
	float temShieldTime;
	float temSwordTime;
	float temSpeedTime;
	float temFistTime;

	public Vector3	diePos;
	public Vector3 	endpos;

	public int heroId;
	GameObject swordHand;//the object attach the play,we need to deactive when time is done;
	GameObject axeHand;
	GameObject FistHand;
	GameObject shileGO;
	GameObject jianchiGo;
	Rigidbody  heroRigid;
	Collider[] go;

	// Use this for initialization
	void Start () {
		isAliveOnce = false;
		hero = this.transform;
		instance = this;
		heroRigid = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		castRay ();
		if(GameManger.instace.isOver || dropWater || hitRwall | hitLwall) return;	
		caculAxtTime ();
		caculShieldTime ();
		caculSwordTime ();
		caculSpeedTime ();
		caculFistTime ();
		MoveHero ();
	
	}




	IEnumerator MoveLeft()
	{
		GameManger.instace.playSound (0);
		canmove = false;
		process = 0;
		float elapsed = 0.0f;
		float rotated = 0.0f;
		while(process < 0.4f)
		{			
			hero.transform.position = Vector3.Lerp(hero.transform.position, endpos, process);
			process += Time.deltaTime *  speed;
			float step = 90 / 0.5f * Time.deltaTime*2;
			transform.RotateAround(transform.position, Vector3.forward, step );
		//	elapsed += Time.deltaTime;
			rotated += step;
			yield return null;
		}
		transform.RotateAround(transform.position, Vector3.forward, 90 - rotated );
		hero.transform.position = endpos;
		sMove = false;
		canmove = true;
	}

	IEnumerator MoveForwad()
	{
		GameManger.instace.playSound (0);
		GameManger.instace.setMeter (1);
		canmove = false;
		process = 0;
		float elapsed = 0.0f;
		float rotated = 0.0f;
		while(process < 0.4f)
		{
			hero.transform.position = Vector3.Lerp(hero.transform.position, endpos, process);
			process += Time.deltaTime *  speed;
			float step = 90 / 0.5f * Time.deltaTime*2f;
			transform.RotateAround(transform.position, Vector3.right, step );
			//elapsed += Time.deltaTime;
			rotated += step;
			yield return null;
		}
		transform.RotateAround(transform.position, Vector3.right, 90 - rotated );
		hero.transform.position = endpos;
		sMove = false;
		canmove = true;
	}

	IEnumerator MoveRight()
	{
		GameManger.instace.playSound (0);
		canmove = false;
		process = 0;
		float elapsed = 0.0f;
		float rotated = 0.0f;
		while(process < 0.4f)
		{
			hero.transform.position = Vector3.Lerp(hero.transform.position, endpos, process);
			process += Time.deltaTime *  speed;
			float step = 90 / 0.5f * Time.deltaTime*2;
			transform.RotateAround(transform.position, Vector3.back, step );
			//elapsed += Time.deltaTime;
			rotated += step;
			yield return null;
		}
		transform.RotateAround(transform.position, Vector3.back, 90 - rotated );
		hero.transform.position = endpos;
		sMove = false;
		canmove = true;
	}

	/// <summary>
	/// Moves the hero.
	/// </summary>
	void MoveHero()
	{		
		if (isLeft && canmove) // move left 
		{ 
			
				if (Physics.Raycast (transform.position, Vector3.left + new Vector3 (0, 0, 0.3f), out hit, 1f)) {	//check the left have any block?

				if (hit.collider.tag == "co") 
				{
					if(isAxe)//you have tha Axe item and kill the block
					{		
						GameManger.instace.playSound (4);
						GameManger.instace.playSound (6);					
						spawnObject.instance.CreatFx("swordTrail",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.CreatFx("treeExplosion",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.DespanFx (hit.collider.gameObject);
					}
					else
					{							
						forward = true;
						isLeft = false;				
						return;
					}							
				}



				}
			if (Physics.Raycast (transform.position, Vector3.left + new Vector3 (0, 0, -0.3f), out hit, 1f)) {
				if (hit.collider.tag == "co") {
					if (isAxe) {			
						GameManger.instace.playSound (4);
						GameManger.instace.playSound (6);
						spawnObject.instance.CreatFx("swordTrail",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.CreatFx("treeExplosion",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.DespanFx (hit.collider.gameObject);
					} else {							
						forward = true;
						isLeft = false;				
						return;
					}	
				}
			}
			if (!sMove) {
				endpos = new Vector3 (hero.transform.position.x - 1f, hero.transform.position.y, hero.transform.position.z);
				process = 0;
				sMove = true;
			}
			if (sMove) {
				StartCoroutine (MoveLeft ());
				isLeft = false;
				sMove = false;
				forward = true;
			} 
		}
		else if (forward && canmove)// move forward
				{ 				
			if (Physics.Raycast (transform.position, Vector3.forward + new Vector3 (0.3f, 0, 0f), out hit, 0.8f) ) {
						if (hit.collider.tag == "co") 
						{
							if(isAxe)
							{		
								GameManger.instace.playSound (4);
								GameManger.instace.playSound (6);								
								spawnObject.instance.CreatFx("swordTrail",transform,new Vector3(0,0,0.5f));							
								spawnObject.instance.CreatFx("treeExplosion",transform,new Vector3(0,0,0.5f));
								spawnObject.instance.DespanFx (hit.collider.gameObject);
							}
							else
							{							
								forward = false;				
								return;
							}							
						}
					}
			if (Physics.Raycast (transform.position, Vector3.forward + new Vector3 (-0.3f, 0, 0f), out hit, 0.8f)) 
					{
						if (hit.collider.tag == "co")
							{
							if(isAxe)
							{			
								GameManger.instace.playSound (4);
								GameManger.instace.playSound (6);
								
								spawnObject.instance.CreatFx("swordTrail",transform,new Vector3(0,0,0.5f));							
								spawnObject.instance.CreatFx("treeExplosion",transform,new Vector3(0,0,0.5f));
								spawnObject.instance.DespanFx (hit.collider.gameObject);
							}
							else
							{							
								forward = false;				
								return;
							}
							}
					}
					if (!sMove) {
						endpos = new Vector3 (hero.transform.position.x, hero.transform.position.y, hero.transform.position.z + 1f);
						process = 0;
						sMove = true;
					}
					if (sMove) {
						StartCoroutine (MoveForwad ());
						forward = true;
						sMove = false;
				}
			} else if (isRight && canmove) {
			if (Physics.Raycast (transform.position, Vector3.right + new Vector3 (0, 0, 0.3f), out hit, 1)) {

				if (hit.collider.tag == "co")
				{
					if (isAxe) {		
						GameManger.instace.playSound (4);
						GameManger.instace.playSound (6);
						spawnObject.instance.CreatFx("swordTrail",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.CreatFx("treeExplosion",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.DespanFx (hit.collider.gameObject);
					} 
					else 
					{							
						forward = true;
						isRight = false;
						return;
					}	
				}
				}
			if (Physics.Raycast (transform.position, Vector3.right + new Vector3 (0, 0, -0.3f), out hit, 1f)) {

				if (hit.collider.tag == "co")
				{
					if (isAxe) {	
						GameManger.instace.playSound (4);
						GameManger.instace.playSound (6);
						spawnObject.instance.CreatFx("swordTrail",transform,new Vector3(0,0,0.5f));					
						spawnObject.instance.CreatFx("treeExplosion",transform,new Vector3(0,0,0.5f));
						spawnObject.instance.DespanFx (hit.collider.gameObject);
					} 
					else 
					{							
						forward = true;
						isRight = false;
						return;
					}
				}	
				}
				if (!sMove) {
					endpos = new Vector3 (hero.transform.position.x + 1f, hero.transform.position.y, hero.transform.position.z);
					process = 0;
					sMove = true;
				}
				if (sMove) {
				StartCoroutine (MoveRight ());
					forward = true;
					sMove = false;
					isRight = false;
				}
			}
		}

//	void castRay()
//	{
//		Debug.DrawRay (transform.position+ new Vector3 (0, 0, 0.4f),Vector3.left ,Color.red);
//		Debug.DrawRay (transform.position+ new Vector3 (0, 0, -0.4f),Vector3.left ,Color.red);
//		Debug.DrawRay (transform.position+ new Vector3 (0, 0, -0.4f),Vector3.right ,Color.red);
//		Debug.DrawRay (transform.position+ new Vector3 (0, 0, 0.4f),Vector3.right ,Color.red);
//		Debug.DrawRay (transform.position+ new Vector3 (0.4f, 0, 0),new Vector3(0,0,0.7f),Color.red);
//		Debug.DrawRay (transform.position+ new Vector3 (-0.4f, 0, 0),new Vector3(0,0,0.7f) ,Color.red);
//	}
//

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("gold"))//get the gold
		{
			GameManger.instace.playSound (2);
			spawnObject.instance.DespanFx (other.gameObject);
			spawnObject.instance.CreatFx ("FxhitCoin", transform);
			GameManger.instace.setCoin (1);
		}
		if(other.tag.Equals("shield"))//get the shidle
		{
			temShieldTime = 0;
			if (isShield)
			{
				GameManger.instace.playSound (1);
				spawnObject.instance.DespanFx (other.gameObject);
				return;	
			}
			GameManger.instace.playSound (1);
			spawnObject.instance.DespanFx (other.gameObject);
			spawnObject.instance.CreatFx ("FxgetShield", transform,Vector3.zero);
			shileGO=spawnObject.instance.GetCreatFx ("Fxshield", transform,Vector3.zero).gameObject ;
			shileGO.transform.parent = this.transform;
			shileGO.transform.localPosition = Vector3.zero;
			isShield = true;
		}
		if(other.tag.Equals("sword"))//get the sword
		{			
			temSwordTime = 0;
			if (isSword)
			{
				GameManger.instace.playSound (5);
				spawnObject.instance.DespanFx (other.gameObject);
				spawnObject.instance.CreatFx ("FxgetSword", transform,Vector3.forward);
				return;	
			}				
			GameManger.instace.playSound (5);
			spawnObject.instance.DespanFx (other.gameObject);
			swordHand = spawnObject.instance.GetCreatFx ("swordHand", transform,Vector3.zero).gameObject ;
			spawnObject.instance.CreatFx ("FxgetSword", transform,Vector3.forward);
			isSword = true;
		}
		if(other.tag.Equals("axe"))//hit by enemy
		{
			temAxeTime = 0;
			if (isAxe)
			{
				GameManger.instace.playSound (3);
				spawnObject.instance.DespanFx (other.gameObject);
				return;
			}				
			GameManger.instace.playSound (3);
			spawnObject.instance.DespanFx (other.gameObject);
			axeHand= spawnObject.instance.GetCreatFx ("axeHand", transform,Vector3.zero).gameObject ;
			isAxe = true;
		}
		if(other.tag.Equals("Hp"))//get the hp
		{
			GameManger.instace.playSound (1);
			//other.gameObject.SetActive (false);
			//to do
		}
		if(other.tag.Equals("bullet"))//hit by enemy
		{
			hurtMe ();
			spawnObject.instance.DespanFx (other.gameObject);
		}
		if(other.tag.Equals("enemy"))//hit by enemy
		{
			hurtMe ();
			spawnObject.instance.DespanFx (other.gameObject);
		}
		if(other.tag.Equals("jianchi"))
		{
			jianchiGo = other.gameObject;
			hurtMe ();
		}
	
		if(other.tag.Equals("water"))
		{		
			dropWater = true;
			activeGravityKinemati (false);
			StartCoroutine (waitDie(2));
			other.gameObject.SetActive (false);
			//Debug.Log ("drop Water");
		}


		if(other.tag.Equals("lco"))
		{		
			hitLwall = true;
			activeGravityKinemati (false);
			StartCoroutine (waitDie(2));
		
		}

		if(other.tag.Equals("rco"))
		{		
			hitRwall = true;
			activeGravityKinemati (false);
			StartCoroutine (waitDie(2));
		}
		if(other.tag.Equals("fist"))		{		
			
			temFistTime = 0;
			if (isFist)
			{
				GameManger.instace.playSound (3);
				spawnObject.instance.DespanFx (other.gameObject);
				return;
			}				
			GameManger.instace.playSound (3);
			spawnObject.instance.DespanFx (other.gameObject);
			FistHand= spawnObject.instance.GetCreatFx ("fistHand", transform,Vector3.zero).gameObject ;
			spawnObject.instance.CreatFx ("FxgetFist", transform,Vector3.forward);

			isFist = true;
		}

		if(other.tag.Equals("speed"))
		{		

			temSpeedTime = 0;
			if (isSpeed)
			{
				GameManger.instace.playSound (3);
				spawnObject.instance.DespanFx (other.gameObject);
				return;
			}				
			GameManger.instace.playSound (3);
			spawnObject.instance.DespanFx (other.gameObject);
			spawnObject.instance.CreatFx ("FxgetSpeed", transform,Vector3.forward);

			isSpeed = true;
		}

	}


	void hurtMe()
	{
		
		if(isShield)
		{		
			spawnObject.instance.DespanFx (shileGO);
			spawnObject.instance.CreatFx("shiledExposion",transform);
			GameManger.instace.playSound (11);
			isShield = false;
			temShieldTime = 0;
			if(jianchiGo!=null)
			{
				spawnObject.instance.DespanFx (jianchiGo);
			}

			jianchiGo = null;
		}
		else
		{	
			diePos = transform.position;
			die ();
		}
	}

	IEnumerator waitDie(float waitime)
	{
		diePos = transform.position;
		yield return new WaitForSeconds (waitime);
		die ();
			
	}

	IEnumerator dieTiwce(float waitime)
	{
		spawnObject.instance.CreatFx("HeroDieExplosion",transform);
		GameManger.instace.playSound (9);
		this.gameObject.SetActive (false);
		UImain.instance.activeUI (1, true);
		yield return new WaitForSeconds (waitime);



	}


	void die()
	{
		saveScore ();
		GameManger.instace.isOver = true;
		if (isAliveOnce)
		{
			StartCoroutine (dieTiwce(1));
			return;
		}
		GameManger.instace.Gameover();
		GameManger.instace.playSound (9);
		spawnObject.instance.CreatFx("HeroDieExplosion",transform);
		this.gameObject.SetActive (false);
	}
		
	void caculAxtTime()
	{
		if(isAxe)
		{
			temAxeTime +=Time.deltaTime;
			//UImain.instance.SkillTimeText.text = (10 - temAxeTime).ToString ("F1");
			if(temAxeTime>10)
			{
				GameManger.instace.playSound (7);
				spawnObject.instance.CreatFx("AxeBroke", transform,new Vector3(-0.3f,0,0));
				spawnObject.instance.DespanFx (axeHand);
				axeHand = null;
				isAxe = false;
				temAxeTime = 0;
			}
		}
	}

	void caculShieldTime()
	{
		if(isShield)
		{
			temShieldTime +=Time.deltaTime;
			//UImain.instance.ShieldTimeText.text = (10 - temShieldTime).ToString ("F1");
			if(temShieldTime>10)
			{
				isShield = false;
				temShieldTime = 0;
				if(shileGO!=null)
				{
					spawnObject.instance.DespanFx (shileGO);
					shileGO = null;
				}

				//shileGO.transform.parent = poolManager.instance.transform;
			}
		}
	}

	void caculSwordTime()
	{
		if(isSword)
		{
			swordAtk ();
			temSwordTime +=Time.deltaTime;
			//UImain.instance.SwordTimeText.text = (3 - temSwordTime).ToString ("F1");
			if(temSwordTime>10)
			{
				GameManger.instace.playSound (7);
				spawnObject.instance.CreatFx("swordBroke", transform,new Vector3(0.4f,0,0));
				spawnObject.instance.DespanFx (swordHand);
				isSword = false;
				temSwordTime = 0;
				swordHand = null;
			}
		}
	}

	void caculSpeedTime()
	{
		if(isSpeed)
		{
			
			temSpeedTime +=Time.deltaTime;
			speed = 3.5f;
			if(temSpeedTime>10)
			{
				GameManger.instace.playSound (7);
			//	spawnObject.instance.CreatFx("swordBroke", transform,new Vector3(0.4f,0,0));
				//spawnObject.instance.DespanFx (swordHand);
				isSpeed = false;
				temSpeedTime = 0;
				speed = 2;
			}
		}
	}

	void caculFistTime()
	{
		if(isFist)
		{

			temFistTime +=Time.deltaTime;

			fireBullet ();
			if(temFistTime>10)
			{
				GameManger.instace.playSound (7);
				spawnObject.instance.CreatFx("FxgetFist", transform,new Vector3(0f,1,0));
				spawnObject.instance.DespanFx (FistHand);
				isFist = false;
				temFistTime = 0;
				FistHand = null;
			}
		}
	}

	float tRate =0;
	void fireBullet()
	{

		tRate += Time.deltaTime;
		if(tRate>1f)
		{
			spawnObject.instance.CreatFx("fistbullet", transform,new Vector3(0f,0,1));
			tRate = 0;
		}


	}
		
	void swordAtk()
	{
		go = Physics.OverlapSphere (transform.position, 1f);
		foreach(Collider go1 in go)
		{			
			if(go1.tag=="enemy")
			{
				spawnObject.instance.DespanFx (go1.gameObject);
				spawnObject.instance.CreatFx("swordAtkFx", transform,new Vector3(0.0f,0,2));
				GameManger.instace.playSound (10);
				spawnObject.instance.CreatFx("HeroDieExplosion",transform,new Vector3(0.4f,0,0));
			}
		}
	}

	public void liveKillAll()
	{
		go = Physics.OverlapSphere (transform.position, 3f);
		GameManger.instace.setSound (0.5f);
		foreach(Collider go1 in go)
		{

			if(go1.tag=="enemy" || go1.tag=="bullet" || go1.tag=="jianchi" )
			{
				spawnObject.instance.DespanFx (go1.gameObject);
				spawnObject.instance.CreatFx("HeroDieExplosion",transform,new Vector3(0.4f,0,0)); //diePos
				int tz = (int)diePos.z;
				int tx = (int)diePos.x;	
			
				activeGravityKinemati (true);
				this.transform.position = new Vector3((float)tx,0,(float)tz+0.5f);
				this.transform.eulerAngles = Vector3.zero;
			}
		}
		GameManger.instace.playSound (10);	
		spawnObject.instance.CreatFx("swordAtkFx", transform,new Vector3(0.0f,0,2));
		canmove = true;
		dropWater = false;
		diePos = Vector3.zero;
		heroContrl.instance.isAliveOnce = true;
		isSword = false;
		isShield = false;
		isAxe = false;
		isSpeed = false;
		isFist = false;
		if(axeHand!=null )
		{
			spawnObject.instance.DespanFx (axeHand);
		}
		if(swordHand!=null )
		{
			spawnObject.instance.DespanFx (swordHand);
		}
		if(shileGO!=null )
		{
			spawnObject.instance.DespanFx (shileGO);
		}
		if(FistHand!=null )
		{
			spawnObject.instance.DespanFx (FistHand);
		}
	}

	public void activeGravityKinemati(bool check)
	{		
		heroRigid.isKinematic = check;
		heroRigid.useGravity = !check;

	}


	void saveScore()
	{
		int score = save.instance.load ("score");
		if (GameManger.instace.countMeter > score)
		{
			save.instance.Save2 (GameManger.instace.countMeter, "score");
		}
	}


	public void useSkill()
	{
		
		switch(heroId)
		{
		case 0:
			// speed

			spawnObject.instance.CreatFx ("speed", transform.position);
			break;
		case 1:
			spawnObject.instance.CreatFx ("fist", transform.position);
			break;
		case 2:
			spawnObject.instance.CreatFx ("sword", transform.position);
			break;
		case 3:
			spawnObject.instance.CreatFx ("shield", transform.position);
			break;
		case 4:
			spawnObject.instance.CreatFx ("axe", transform.position);
			break;
		case 6:
			Debug.Log ("skill:"+heroId);
			break;
		case 7:
			Debug.Log ("skill:"+heroId);
			break;
		case 8:
			Debug.Log ("skill:"+heroId);
			break;
		case 9:
			Debug.Log ("skill:"+heroId);
			break;
		case 10:
			Debug.Log ("skill:"+heroId);
			break;
		default :
			
			break;
		}
	}

}

