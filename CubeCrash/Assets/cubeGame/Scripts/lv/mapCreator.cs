using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreator : MonoBehaviour {


	// 0 nothing 1 tree 2 coin 3 shield 4 sword 5 axe
	// 101 jumpman 102 flower 103 jumpman 104 jianchi



	public TextAsset[] mapTextA ;

	public int[,] block;

	 List<string> eachline;

	public string allText;

	void Start()
	{
		createBlock ();
	}



	void OnEnable()
	{
	}


	public void createBlock()
	{


		int rd = Random.Range (0, mapTextA.Length);
		allText = mapTextA [rd].text;
	//	Debug.Log ("map" + (rd + 1));
		//allText = mapText.text;
		eachline = new List<string> ();
		//eachline.AddRange (allText.Split ("\n"[0]));
		eachline.AddRange (allText.Split (new char[]{'\n'}));

		int[,] spaces = new int[eachline.Count, 10];

		for(int i=0;i<eachline.Count;i++)
		{
			string st = eachline [i];

			string[] nums = st.Split(new char[]{','});

			if (nums.Length != 10)
			{  
				Debug.Log ("Misforned input on line "+i+1);  
			}

			for(int j =0 ; j<Mathf.Min(nums.Length,10);j++)
			{
				int val;
				int.TryParse (nums [j], out val);

				if(val==1)
				{				
					int t = Random.Range (0, 6);
					GameObject go=null;
					switch(t)
					{
					case 0:
						 go =spawnObject.instance.GetCreatFx ("tree01", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 1:
						go =spawnObject.instance.GetCreatFx ("tree02", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 2:
						go =spawnObject.instance.GetCreatFx ("tree03", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 3:
						go =spawnObject.instance.GetCreatFx ("tree04", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 4:
						go =spawnObject.instance.GetCreatFx ("jianchi", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 5:
						go =spawnObject.instance.GetCreatFx ("waterhole", new Vector3 (0, 0, 0)).gameObject;		
						break;
				
					}

					if(t==5)
					{
						go.transform.localPosition = new Vector3 (j, 0.03f, i)+transform.position ;		
					}
					else if(t==4)
					{
						go.transform.position = new Vector3 (j, -0.5f, i)+transform.position;	

					}
					else
					{
						go.transform.localPosition = new Vector3 (j, -0.4f, i)+transform.position +new Vector3(0,0,-0.5f);	
					}
							
				}
				if(val==2)
				{				
					GameObject go1=	spawnObject.instance.GetCreatFx("coin", new Vector3 (0, 0, 0)).gameObject;				
					go1.transform.localPosition = new Vector3 (j, -0.4f, i)+transform.position;		
				}
				if(val==3)
				{		

					int t = Random.Range (0, 3);
					GameObject go=null;
					switch(t)
					{
					case 0:
						go =spawnObject.instance.GetCreatFx ("sword", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 1:
						go =spawnObject.instance.GetCreatFx ("shield", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 2:
						go =spawnObject.instance.GetCreatFx ("jumpman", new Vector3 (0, 0, 0)).gameObject;		
						break;
					}
					go.transform.localPosition = new Vector3 (j, 0.5f, i)+transform.position;		
				}
				if(val==4)
				{				

					int t = Random.Range (0, 5);
					GameObject go=null;
					switch(t)
					{
					case 0:
						go =spawnObject.instance.GetCreatFx ("sword", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 1:
						go =spawnObject.instance.GetCreatFx ("shield", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 2:
						go =spawnObject.instance.GetCreatFx ("jumpman", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 3:
						go =spawnObject.instance.GetCreatFx ("fist", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 4:
						go =spawnObject.instance.GetCreatFx ("speed", new Vector3 (0, 0, 0)).gameObject;		
						break;
					}

					go.transform.localPosition = new Vector3 (j, 0.5f, i)+transform.position;		
				}
				if(val==5)
				{				


					int t = Random.Range (0, 5);
					GameObject go=null;
					switch(t)
					{
					case 0:
						go =spawnObject.instance.GetCreatFx ("sword", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 1:
						go =spawnObject.instance.GetCreatFx ("shield", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 2:
						go =spawnObject.instance.GetCreatFx ("axe", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 3:
						go =spawnObject.instance.GetCreatFx ("fist", new Vector3 (0, 0, 0)).gameObject;		
						break;
					case 4:
						go =spawnObject.instance.GetCreatFx ("speed", new Vector3 (0, 0, 0)).gameObject;		
						break;
					}

				//	GameObject go=	spawnObject.instance.GetCreatFx("axe", new Vector3 (0, 0, 0)).gameObject;
	
					go.transform.localPosition = new Vector3 (j, -0.4f, i)+transform.position;		
				}

				if(val==101)
				{									
					GameObject go=	spawnObject.instance.GetCreatFx("jumpman", new Vector3 (0, 0, 0)).gameObject;
	
					go.transform.localPosition = new Vector3 (j, 0, i)+transform.position;		
				}
				if(val==102)
				{				
					GameObject go=	spawnObject.instance.GetCreatFx("flower", new Vector3 (0, 0, 0)).gameObject;

					go.transform.localPosition = new Vector3 (j, -0.4f, i)+transform.position;		
				}
				if(val==103)
				{					
					GameObject go=	spawnObject.instance.GetCreatFx("walkMan", new Vector3 (0, 0, 0)).gameObject;

					go.transform.localPosition = new Vector3 (j, 0, i)+transform.position;		
				}
				if(val==104)
				{
					GameObject go33=spawnObject.instance.GetCreatFx("jianchi", new Vector3 (0, 0, 0)).gameObject;

					go33.transform.position = new Vector3 (j, -0.5f, i)+transform.position;	

				}
				if(val==105)
				{
					
					GameObject go33=spawnObject.instance.GetCreatFx("waterhole", new Vector3 (0, 0, 0)).gameObject;

					go33.transform.position = new Vector3 (j, 0.3f, i)+transform.position;	

				}
			}
		}
	}



	void FixedUpdate()
	{
		if(GameManger.instace.heroGo!=null)
		{
            if (Vector3.Distance(GameManger.instace.heroGo.transform.position, this.transform.position) > 50)
            {
                if (this.name != "T1")
                {
                    spawnObject.instance.DespanFx(this.gameObject);
                }

            }
        }

	}

}
 