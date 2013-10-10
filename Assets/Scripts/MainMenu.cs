using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public GameObject receiver;
	public Rect  buttonRun;
	public Rect buttonMenu;
	public Rect buttonMoreBabies;
	public Rect buttonProcreate;
	public Rect buttonManageBabies;
	public Rect buttonBuyStuff;
	public GUIText procreatingTimerText;
	public bool procreating;
	public int procreatingTimer;
	public GUITexture logo;
	
//	public float slide=0;

	
	
	void Start()
	{
		
		
		
		procreatingTimerText.text= "No new baby in production";
		//procreatingTimerText.color=;
		procreatingTimer=100;
		buttonProcreate.x=-100;

		/*buttonRun = new Rect(100, 50, 100, 50);
		buttonMenu = new Rect(150, 100, 100, 50);
		buttonMoreBabies = new Rect(200, 150, 100, 50);
		buttonManageBabies = new Rect(250, 200, 100, 50);
		buttonBuyStuff = new Rect(300, 250, 100, 50);*/
		procreating=false;
	}
	void Update()
	{

		if(procreating){
			procreatingTimer--;
			procreatingTimerText.text="Making New Baby : "+procreatingTimer;
		
			if(procreatingTimer<=0){
				finishProcreatingTimer();
				
			}
		}
		//if()
	/*	if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel( Application.loadedLevel+1 );
		}*/
	}
	private void SendMessage(object parameter)
	{
		if(receiver) receiver.SendMessage("OnButtonClicked", parameter, SendMessageOptions.DontRequireReceiver);
	}
	void OnGUI()
	{
		GUIStyle buttonStyle = new GUIStyle( GUI.skin.button );
		buttonStyle.wordWrap = true;
		buttonStyle.alignment = TextAnchor.UpperCenter;

		if( GUI.Button(buttonRun, "Run", buttonStyle) )
		{
			SendMessage("Run");
			GameState.paused=false;
			//hide logo
			logo.transform.Translate(-100,0,0);
			buttonMenu.x=-100;
		
			buttonRun.x=-100;
			buttonProcreate.x=-100;
			buttonMoreBabies.x=-100;
			buttonManageBabies.x=-100;
			buttonBuyStuff.x=-100;
		
			GameState.setGameScene();
			
			//	Application.LoadLevel( Application.loadedLevel+1 );
		}
	/*	if( GUI.Button(buttonMenu, "Menu", buttonStyle) )
		{
			SendMessage("Menu");
		}*/
		if( GUI.Button(buttonMoreBabies, "Get More Babies", buttonStyle) )
		{
			SendMessage("Get More Babies");
			//   slide += Time.deltaTime;
			//buttonProcreate = new Rect(250, 400, 100, 40);
			buttonProcreate.x=250;
			buttonProcreate.y=400;
			buttonProcreate.width=100;
			buttonProcreate.height=40;
    	//	GUI.DrawTexture(new Rect(Mathf.Lerp(100,250,slide),400,100,40));
		
		}
	/*	if( GUI.Button(buttonManageBabies, "Manage Your Babies", buttonStyle) )
		{
			SendMessage("Manage Your Babies");
		}
		if( GUI.Button(buttonBuyStuff, "Buy More Stuff",buttonStyle) )
		{
			SendMessage("Buy More Stuff");
		}*/
		if( GUI.Button(buttonProcreate, "Procreate",buttonStyle) )
		{
			print("procreating");
			SendMessage("Procreate");
			procreating=true;
		  
		}
	}
	public void finishProcreatingTimer(){
		
		procreating=false;
		procreatingTimer=100;	
		  GameState.createBaby("jojo");
	
	}
	
	
}
