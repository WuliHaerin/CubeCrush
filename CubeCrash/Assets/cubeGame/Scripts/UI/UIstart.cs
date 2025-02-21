using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UIstart : MonoBehaviour {


	public static UIstart instance;
	Image 				imageL;
	Image				imageR;
	Image  				goButton;


	Text				heroPriceText;
	public  Text		coinText;
	public GameObject   playImg;
	public GameObject 	 BuyText;
	GameObject 			hasbuytext;
	Text 				score;
	int 				heroIndex;
	int  				heroPrice =200;
	Transform 			thiTrans;
	bool 				isPress;
	int 				yourCoin=0;

	public AudioClip[] sound;
	AudioSource audicomp;



	public  List<Transform> heroList = new List<Transform>();

	public int YourCoin {
		get 
		{
			yourCoin = save.instance.load("coin");
			return yourCoin;
		}
		set {
			yourCoin += value;
			save.instance.Save (yourCoin, "coin");
			coinText.text = yourCoin.ToString ();
		}
	}

	public int HeroPrice {
		get {
			heroPrice = save.instance.load("heroPrice");
			if(heroPrice==0)
			{
				heroPrice = 200;
			}
			return heroPrice;
		}
		set {
			heroPrice = value*2;
			heroPriceText.text = heroPrice.ToString ();
			save.instance.Save2 (heroPrice, "heroPrice");
		}
	}

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{		
		audicomp = GetComponent<AudioSource> ();
		foreach(Transform child in transform)
		{
			heroList.Add (child);
		}
		thiTrans 		= this.transform;
		imageL 			= GameObject.Find("btShowL").GetComponent<Image>();
		imageR 			= GameObject.Find("btShowR").GetComponent<Image>();
		goButton 		= GameObject.Find("goButton").GetComponent<Image>();
		heroPriceText 	= GameObject.Find("heroPriceText").GetComponent<Text>();
		coinText		= GameObject.Find("coinText").GetComponent<Text>();
		BuyText 		= GameObject.Find ("BuyText");
		playImg 		= GameObject.Find ("playIm");	
		hasbuytext 		= GameObject.Find ("hasbuytext");
		score 			= GameObject.Find ("meterRun").GetComponent<Text>();

		//EventTriggerListener.Get(goButton.gameObject).onDown 	 		= OnButtonClick;
		//EventTriggerListener.Get(imageL.gameObject).onDown		 		= OnButtonClick;
		//EventTriggerListener.Get(imageR.gameObject).onDown 		 		= OnButtonClick;	
		imageL.GetComponent<Button>().onClick.AddListener(Left);
		imageR.GetComponent<Button>().onClick.AddListener(Right);
		goButton.GetComponent<Button>().onClick.AddListener(Go);
		

		BuyText.SetActive (false);
		hasbuytext .SetActive (false);
		score.text = save.instance.load ("score").ToString();
		heroPriceText.text  = HeroPrice.ToString();
		coinText.text 		= YourCoin.ToString ();

	}
	


	private void OnButtonClick(GameObject go)
	{
		
		if(go == imageL.gameObject)
		{		
			audicomp.PlayOneShot (sound [0]);
			if(thiTrans.position.x <=(heroList.Count-1)*-2)
			{
				return;
			}
			if(!isPress)StartCoroutine (move(-2));
		}
		if(go == imageR.gameObject)
		{
			audicomp.PlayOneShot (sound [0]);
			if (thiTrans.position.x == 0)
				return;
			if(!isPress)StartCoroutine (move(2));
		}
		if(go == goButton.gameObject)
		{
			audicomp.PlayOneShot (sound [0]);
			selectHero ();
		}
	

	}

	private void Left()
	{
        audicomp.PlayOneShot(sound[0]);
        if (thiTrans.position.x <= (heroList.Count - 1) * -2)
        {
            return;
        }
        if (!isPress) StartCoroutine(move(-2));
    }

	private void Right()
	{
        audicomp.PlayOneShot(sound[0]);
        if (thiTrans.position.x == 0)
            return;
        if (!isPress) StartCoroutine(move(2));
    }

	private void Go()
	{
        audicomp.PlayOneShot(sound[0]);
        selectHero();
    }



	IEnumerator move(int cout)
	{
		isPress = true;
		float t = 0f;
		Vector3 endpos = new Vector3 (thiTrans.position.x + cout, thiTrans.position.y, thiTrans.position.z);
		heroIndex = (int)(thiTrans.position.x + cout);
		swichText (heroIndex);	
		while(t<0.3f)
		{
			thiTrans.position = Vector3.Lerp(thiTrans.position,endpos,t);
			t += Time.deltaTime;
			yield return null;
		}
		thiTrans.position = endpos;
		isPress = false;
	}

	/// <summary>
	/// Sets the index of the hero.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	void setHeroIndex(int x)
	{
		switch(x)
		{
		case 0:			
			save.instance.Save2(1,"hero");
			break;
		case -2:			
			save.instance.Save2(2,"hero");

			break;
		case -4:			
			save.instance.Save2(3,"hero");		
			break;
		case -6:
			save.instance.Save2(4,"hero");

			break;
		case -8:			
			save.instance.Save2(5,"hero");

			break;
		case -10:			
			save.instance.Save2(6,"hero");	
			break;
		}
	}

	public void selectHero()
	{
		setHeroIndex (heroIndex);	
		if(checkHeroCanUse(heroIndex))
		{
			Application.LoadLevel("lv");
		}
		else
		{
			buyHero (heroIndex);
		}
	}

	bool checkHeroCanUse(int id)
	{
		int temp = 0;
		switch(id)
		{
		case 0:
			return true;

		case -2:
			temp = save.instance.load ("hero2");
			if(temp==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		case -4:
			
			temp = save.instance.load ("hero3");
			if(temp==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		case -6:

			temp = save.instance.load ("hero4");
			if(temp==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		case -8:
			temp = save.instance.load ("hero5");
			if(temp==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		case -10:
			temp = PlayerPrefs.GetInt ("hero6");
			if(temp==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		default:
			return false;
		}
	}

	/// <summary>
	/// 1 can use,2 
	/// </summary>
	/// <param name="id">Identifier.</param>
	public void swichText(int id)
	{
		int temp = 0;
		string tempSting="";
		switch(id)
		{
		case 0:
			temp = 1;
			break;
		case -2:			
			temp = save.instance.load("hero2");
			tempSting = "hero" + 2;
			break;
		case -4:			
			temp = save.instance.load("hero3");
			tempSting = "hero" + 3;
			break;
		case -6:			
			temp = save.instance.load("hero4");
			tempSting = "hero" + 4;
			break;
		case -8:			
			temp = save.instance.load("hero5");
			tempSting = "hero" + 5;
			break;
		case -10:			
			temp = save.instance.load("hero6");
			tempSting = "hero" + 6;
			break;
		}
	
		if(temp==1)
		{
			BuyText.SetActive (false);
			hasbuytext.SetActive (true);
			playImg.SetActive (true);
		}
		else
		{
			PlayerPrefs.SetInt (tempSting, 0);
			save.instance.Save (0, tempSting);
			BuyText.SetActive (true);
			hasbuytext.SetActive (false);
			playImg.SetActive (false);
		}
	}

	public void buyHero(int id)
	{
		if (id == 0)
			return;

		if (checkHeroCanUse (id))
		{			
			return;
		}
			
		if(shop.instace.spendCoin(HeroPrice))
		{
			audicomp.PlayOneShot (sound [1]);	
			switch(id)
			{
			case -2:				
				save.instance.Save2 (1, "hero2");
				break;
			case -4:				
				save.instance.Save2 (1, "hero3");
				break;
			case -6:				
				save.instance.Save2 (1, "hero4");
				break;
			case -8:				
				save.instance.Save2 (1, "hero5");
				break;
			case -10:				
				save.instance.Save2 (1, "hero6");
				break;
			}
			coinText.text 		= YourCoin.ToString ();		
			HeroPrice = heroPrice;		
			swichText (id);
		}
		else
		{
			
		}	
	}
	
	public void ShowCoin()
	{
        coinText.text = YourCoin.ToString();
    }

	public void SeeADTry()
	{
		setHeroIndex (heroIndex);	
		Application.LoadLevel ("lv");
	}


}
