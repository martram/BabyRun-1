using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour
{
	public TextMesh coinCounter;
	public TextMesh foodCounter;
	public static bool paused = true;
	private static int coins = 0;
	private static int food = 0;
	private float defTimeScale = 1f;
	public static int babyIDs=0;

	public static List<Baby> baby;
	
	public static GameObject stroller;
	
	public GameState(){
		//baby= new List<Baby>();
		
		print ("new gamestate");
		
	}
	void Start()
	{
	  baby= new List<Baby>();
		defTimeScale = Time.timeScale;
		print ("new start gamestate");
		
		//baby[0].enabled=true;
	}
	
	void Update()
	{
		coinCounter.text = "x"+coins;
		foodCounter.text = "x"+food;
		//baby[babyIDs].transform.Translate(babyIDs,babyIDs,babyIDs);
	//print("updating baby "+baby[babyIDs].transform.position+"  :  "+baby[babyIDs].transform.localPosition);
	
	//	print(foodCounter + " foodCounter = "+foodCounter.text+" food = "+food);
	}
	
	public static bool IsPaused()
	{
		return paused;
	}
	
	public static void AddCoins(int count)
	{
		coins += count;
	}
	
	public static void AddFood(int count)
	{
		food += count;
	}

	public void OnButtonClicked(object o)
	{
		if(o.ToString()=="Reset")
		{
			if(paused)
			{
				Time.timeScale = defTimeScale;
				paused = false;
			}
			coins = 0;
			food = 0;
			Application.LoadLevel( Application.loadedLevel );
		}
		else if(o.ToString()=="Pause")
		{
			if(paused) Time.timeScale = defTimeScale;
			else Time.timeScale = 0f;
			paused = !paused;
			
		}
	}
/*	void GetBaby() where T:class, new(){
		
		gameObject.AddComponent(typeof(T));
	}*/
	
	//baby related functions
	
	public static void createBaby(string babyName){
		
	
//	var babyObject = new Baby(babyName, babyIDs);
	//	var babyObject = ScriptableObject.CreateInstance(Baby(babyName, babyIDs));
	
		//GameObject govar;
		// var babyObject:Baby(babyName, babyIDs);
		
		//GetBaby<Baby>();
		GameObject govar=  new GameObject("Baby");
		govar.AddComponent<MeshCollider>();
		Baby babyObject= govar.AddComponent<Baby>();
	    
		baby.Add(babyObject);
		baby[babyIDs].createIdentity(babyName,babyIDs);
	
		baby[babyIDs].babyObject.transform.Translate(babyIDs,0,0);
		
		
	
		print("creating the baby in createBaby "+baby[babyIDs].babyObject.transform.position+"  :  "+baby[babyIDs].babyObject.transform.localPosition);
	
		babyIDs++;
		
		
	}
	public static void setGameScene(){
	//	GameObject govar=  new GameObject("CarriageController");
	 //   CarriageController stroller = govar.AddComponent<CarriageController>();
		GameObject strollerObject = GameObject.Find("Carriage");
		
		stroller = (GameObject) GameObject.Instantiate (strollerObject, Vector3.zero, Quaternion.identity);
		
		stroller = new GameObject("CarriageController");
		
	//	stroller.
		baby[babyIDs-1].babyObject.transform.Translate(0,0,0);
	}
	public static void babyDeath(){
		
	//Destroy.baby;
		
	}
}
