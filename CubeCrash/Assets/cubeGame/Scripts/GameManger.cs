using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManger : MonoBehaviour
{

	public static GameManger instace;

	public GameObject[] heroPrefab;

	//public int coin=0;
	public int countMeter = 0;

	public bool isOver = true;
	public GameObject creatPoint;

	public GameObject[] fx;
	public Transform[] plamform;
	public GameObject heroGo;
	public GameObject TTGO;

	public AudioClip[] sound;

	AudioSource audicomp;

	AudioSource bgmComp;


	GameObject heroGO;

	public int youCoin;


	// Use this for initialization
	void Start()
	{
		audicomp = GetComponent<AudioSource>();
		bgmComp = GameObject.Find("BGM").GetComponent<AudioSource>();
		instace = this;
		creatPoint = GameObject.Find("creatPoint");
		creatHero(creatPoint.transform.position);
		StartCoroutine(countDownShow(3));
		heroGo = GameObject.FindWithTag("hero");
		save.instance.Save2(1, "hero");

		//ranCretFirstfloor ();
	}

	void ranCretFirstfloor()
	{
		int r = Random.Range(0, 5);

		switch (r)
		{
			case 0:
				spawnObject.instance.GetCreatFx("floorFirst01", new Vector3(0.5f, -1, 10));
				break;
			case 1:
				spawnObject.instance.GetCreatFx("floorFirst02", new Vector3(0.5f, -1, 10));
				break;
			case 2:
				spawnObject.instance.GetCreatFx("floorFirst03", new Vector3(0.5f, -1, 10));
				break;
			case 3:
				spawnObject.instance.GetCreatFx("floorFirst04", new Vector3(0.5f, -1, 10));
				break;
			case 4:
				spawnObject.instance.GetCreatFx("floorFirst04", new Vector3(0.5f, -1, 10));
				break;
		}
	}


	// Update is called once per frame
	void Update()
	{

		//ADFinish ();
	}

	public void setSound(float val)
	{

		bgmComp.volume = val;
	}

	/// <summary>
	/// show the coin text
	/// </summary>
	/// <param name="num">Number.</param>
	public void setCoin(int num)
	{
		youCoin += num;
		UImain.instance.cointText.text = youCoin.ToString();
	}

	/// <summary>
	/// Sets the distance meter.
	/// </summary>
	/// <param name="num">Number.</param>
	public void setMeter(int num)
	{
		countMeter += num;
		UImain.instance.CountMeter.text = countMeter.ToString();
	}

	public void Gameover()
	{
		playSound(9);
		StartCoroutine(waitToShowMenu());
		isOver = true;
		SaveHeroCoin();
        AdManager.ShowInterstitialAd("1lcaf5895d5l1293dc",
                    () => {
                        Debug.Log("--插屏广告完成--");

                    },
                    (it, str) => {
                        Debug.LogError("Error->" + str);
                    });
        StartCoroutine(DeatCountDonw());
	}

	IEnumerator waitToShowMenu()
	{

		float temp = 0;
		while (temp < 1)
		{
			temp += Time.deltaTime;
			if (temp >= 1)
			{
				UImain.instance.activeUI(0, true);
			}
			yield return null;


		}
	}

	/// <summary>
	/// Creats the hero.
	/// </summary>
	/// <param name="pos">Position.</param>
	void creatHero(Vector3 pos)
	{

		int heroId = save.instance.load("hero");

		switch (heroId)
		{
			case 1:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
				heroGO.tag = "hero";
				break;
			case 2:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
				heroGO.tag = "hero";
				break;
			case 3:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 4:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 5:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 6:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 7:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 8:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 9:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			case 10:
				heroGO = Instantiate(heroPrefab[heroId], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
			default:
				heroGO = Instantiate(heroPrefab[1], pos, Quaternion.identity);
                heroGO.tag = "hero";
                break;
		}
	}

	/// <summary>
	/// save the coin and the run distance;
	/// </summary>
	public void SaveHeroCoin()
	{
		save.instance.Save(youCoin, "coin");
		PlayerPrefs.SetInt("runMeter", countMeter);
	}


	IEnumerator DeatCountDonw()
	{
		float temp = 0;
		while (temp < 10)
		{
			temp += Time.deltaTime;
			UImain.instance.AgainCountDonwText.text = ((int)(10 - temp)).ToString();
			if (temp >= 10)
			{
				UImain.instance.CountDonwText.text = "";
				UImain.instance.activeUI(0, false);

			}
			yield return null;
		}

		if (isOver)
		{
			UImain.instance.activeUI(1, true);
		}

	}


	IEnumerator countDownShow(float cout)
	{
		float temp = 0;
		while (temp < cout)
		{
			temp += Time.deltaTime;
			UImain.instance.CountDonwText.text = ((int)(cout - temp)).ToString();
			if (5 - temp < 1)
			{
				UImain.instance.CountDonwText.text = "Go!";
			}
			yield return null;

		}
		isOver = false;
		UImain.instance.CountDonwText.text = "";

	}

	/// <summary>
	/// 0 run sound 1 get item 2 get coin
	/// </summary>
	/// <param name="id">Identifier.</param>
	public void playSound(int id)
	{
		audicomp.PlayOneShot(sound[id]);
	}

	public void spend200Glive()
	{
		if (heroContrl.instance.isAliveOnce)
		{
			return;
		}

		if (shop.instace.spendCoin(200))
		{

			StopAllCoroutines();
			UImain.instance.activeUI(0, false);
			UImain.instance.activeUI(1, false);
			StartCoroutine(countDownShow(1.5f));
			heroGO.SetActive(true);

			if (heroContrl.instance.hitLwall)
			{
				heroGO.transform.position = heroContrl.instance.diePos + Vector3.right;
				heroContrl.instance.hitLwall = false;
			}
			else if (heroContrl.instance.hitRwall)
			{

				heroGO.transform.position = heroContrl.instance.diePos + Vector3.left;
				heroContrl.instance.hitRwall = false;
			}
			else
			{
				heroGO.transform.position = heroContrl.instance.diePos;
			}



			heroGO.transform.eulerAngles = Vector3.zero;
			heroContrl.instance.activeGravityKinemati(false);
			heroContrl.instance.liveKillAll();

		}
	}

	/// <summary>
	/// Sees the ad reset. 
	/// </summary>
	public void seeAdReset()
	{
		StopAllCoroutines();
		UImain.instance.activeUI(0, false);
		UImain.instance.activeUI(1, false);
		StartCoroutine(countDownShow(4f));
		heroGO.SetActive(true);
		if (heroContrl.instance.hitLwall)
		{
			heroGO.transform.position = heroContrl.instance.diePos + Vector3.right;
			heroContrl.instance.hitLwall = false;
		}
		else if (heroContrl.instance.hitRwall)
		{

			heroGO.transform.position = heroContrl.instance.diePos + Vector3.left;
			heroContrl.instance.hitRwall = false;
		}
		else
		{
			heroGO.transform.position = heroContrl.instance.diePos;
		}


        heroContrl.instance.activeGravityKinemati(true);
        heroGO.transform.eulerAngles = Vector3.zero;
		heroContrl.instance.liveKillAll();


	}

	public void StopAllCroti()
	{
		StopAllCoroutines();
	}

	public Vector3 GetTouchPosion()
	{
		Ray rayT = Camera.main.ScreenPointToRay(Input.mousePosition);
		return rayT.GetPoint(1);
	}



}
