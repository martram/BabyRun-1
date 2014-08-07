using UnityEngine;
using System.Collections;
using System;
//using System.Collections.Generic;


public class HUD : MonoBehaviour
{
	public GUISkin menuSkin;
	//defined in unity
	public float areaWidth;
	public float areaHeight;
	public float screenX;
	public float screenY;
	public GameObject receiver;
	public GameObject GUICoin;
	public GameObject GUIFood;


	public GUIText runScoreText, highScoreText, coinCountText, foodCountText, deadBabyText, scoreMultiplierText, scoreMultiplierDigitsText;
	public string buttonText;
	public int runningScore;
	private string	tempMultiplierString;
	private float runningMultiplier =1f;
	private int runningMultiplierDigits=0;
	private int runningMultiplierNum=1;
	private int oldDistance;
	private const string runningMultiplierPrefix = "X ";

	private const string runningDistancePrefix = "Run Score: ";
	private const string runningDistanceSuffix = "!";
	public const string highScoreDistancePrefix = "HIGHSCORE: ";
	public int highScore;

		public HUDbabyAvatar babyAvatar;

		public Alert alert;

	void Start()
	{
				//menuSkin = this;

				GameObject runScore = new GameObject ("GUIrunScoreText " + GameState.babyIndex);
				runScoreText = runScore.AddComponent<GUIText>();
				runScoreText.fontSize = 15;
				runScoreText.font = GameState.arialFont;
				runScoreText.transform.position = new Vector3 (0.7f,0.93f, 0f);

				GameObject scoreMultiplier = new GameObject ("GUIScoreMultiplierText " + GameState.babyIndex);
				scoreMultiplierText = scoreMultiplier.AddComponent<GUIText>();
				scoreMultiplierText.fontSize = 15;
				scoreMultiplierText.font = GameState.arialFont;
				scoreMultiplierText.alignment=TextAlignment.Right;
				scoreMultiplierText.anchor=TextAnchor.UpperRight;
				scoreMultiplierText.transform.position = new Vector3 (0.82f,0.93f, 0f);

				GameObject scoreMultiplierDigits = new GameObject ("GUIScoreMultiplierText " + GameState.babyIndex);
				scoreMultiplierDigitsText = scoreMultiplierDigits.AddComponent<GUIText>();
				scoreMultiplierDigitsText.fontSize = 15;
				scoreMultiplierDigitsText.font = GameState.arialFont;
				scoreMultiplierDigitsText.transform.position = new Vector3 (0.82f,0.93f, 0f);

				GameObject highScore = new GameObject ("GUIhighScoreText " + GameState.babyIndex);
				highScoreText = highScore.AddComponent<GUIText>();
				highScoreText.fontSize = 15;
				highScoreText.font = GameState.arialFont;
				highScoreText.transform.position = new Vector3 (0.7f,0.96f, 0f);


				GameObject coinCount = new GameObject ("GUIcoinCountText");
				coinCountText = coinCount.AddComponent<GUIText>();
				coinCountText.fontSize = 15;
				coinCountText.font = GameState.arialFont;
				coinCountText.transform.position = new Vector3 (0.45f,0.95f, 0f);
				coinCountText.text = "0";
				GameObject foodCount = new GameObject ("GUIfoodCountText");
				foodCountText = foodCount.AddComponent<GUIText>();
				foodCountText.fontSize = 15;
				foodCountText.font = GameState.arialFont;
				foodCountText.transform.position = new Vector3 (0.55f,0.95f, 0f);
				foodCountText.text = "0";

				//contextual text
				GameObject deadBaby = new GameObject ("GUIdeadBabyText " + GameState.babyIndex);
				deadBabyText = deadBaby.AddComponent<GUIText>();
				deadBabyText.fontSize = 22;
				deadBabyText.font = GameState.arialFont;
				deadBabyText.transform.position = new Vector3 (0.5f,0.6f, 0f);


				//GUICoin= new GameObject("GUICoin");
				GUICoin = (GameObject) GameObject.Instantiate(Resources.Load("CollectibleAssets/Coin", typeof(GameObject)));
				GUICoin.transform.parent = GameObject.Find("Main Camera").transform;
				GUICoin.transform.position = new Vector3 (-1.65f,3.9f, 8f);
				GUICoin.renderer.castShadows = false;
				GUIFood = (GameObject) GameObject.Instantiate(Resources.Load("CollectibleAssets/BabyFood", typeof(GameObject)));
				GUIFood.transform.parent = GameObject.Find("Main Camera").transform;
				GUIFood.transform.position = new Vector3 (0.5f,3.9f, 8f);
				GUIFood.renderer.castShadows = false;
				babyAvatar = gameObject.AddComponent<HUDbabyAvatar>();
				babyAvatar.createHUDavatar();

				//plan canada international
				alert = gameObject.AddComponent<Alert> ();
				alert.createAlertPrevious ();
				alert.signPrevious.guiTexture.enabled = false;
				alert.createAlertNext ();
				alert.signNext.guiTexture.enabled = false;
				alert.createAlertCurrent ();
				alert.signCurrent.guiTexture.enabled = false;
				alert.createAlertRunning ();
				alert.signRunning.guiTexture.enabled = false;
				//	alert.sign.transform.parent = gameObject.transform;
			
				//babyAvatar = new HUDbabyAvatar ();
				//	babyAvatar.setAvatarColor ("head", 2);
			
				Coin coin = GUICoin.AddComponent<Coin>();
		scoreMultiplierText.text="X 1";
		StartCoroutine(multiplierUpdate(0.7F));
	 	StartCoroutine(scoreUpdate(0.1F));
	


	}

	private void SendMessage(object parameter)
	{
		print ("receiver received! " + parameter);
		if(receiver) receiver.SendMessage("OnButtonClicked", parameter, SendMessageOptions.DontRequireReceiver);
		
	}

	IEnumerator scoreUpdate(float waitTime) {
		while (true) {   
			yield return new WaitForSeconds (waitTime);
			if (GameState.bGamesceneSet && !GameState.bPaused && !GameState.baby[GameState.babyIndex].isTossed) {
				updateScore();
			
			}
		}
	
	}


	IEnumerator multiplierUpdate(float waitTime) {
		while (true) {   
			yield return new WaitForSeconds (waitTime);
			if (GameState.bGamesceneSet && !GameState.bPaused && !GameState.baby[GameState.babyIndex].isTossed) {
				updateMultiplier();
				
			}
		}
		
	}

	private void updateScore(){
		oldDistance= runningScore;
		runningScore = (int)Math.Round(oldDistance+(GameState.stroller.runSpeed*0.1)*runningMultiplier);

	 	runScoreText.text = runningDistancePrefix +  runningScore.ToString() + runningDistanceSuffix;
	}
	private void updateMultiplier(){
		runningMultiplierDigits ++;
		if(runningMultiplierDigits>9){
			runningMultiplier+=0.1f;
			runningMultiplierDigits=0;
			runningMultiplierNum++;
		}
		scoreMultiplierDigitsText.text ="."+runningMultiplierDigits.ToString();
		scoreMultiplierText.text = runningMultiplierPrefix+runningMultiplierNum.ToString();
	}
	public void resetScore(){
		scoreMultiplierText.text="1";
		scoreMultiplierDigitsText.text=".0";
		runningMultiplierNum=1;
		runningMultiplier=1;
		runningMultiplierDigits=0;
		runningScore=0;
		runScoreText.text = runningDistancePrefix + runningScore.ToString()+ runningDistanceSuffix;


	}

	public void UpdateCoins(){
		
			coinCountText.text =GameState.coins.ToString();

	}	
	public void UpdateFood(){

			foodCountText.text =GameState.food.ToString();

	}
		public void UpdateHighScore (int hs){

				highScoreText.text = highScoreDistancePrefix + hs;

		}

	void OnGUI()
	{	
				/*GUIStyle buttonStyle = new GUIStyle( GUI.skin.button );
				buttonStyle.wordWrap = true;
				buttonStyle.alignment = TextAnchor.UpperCenter;*/

				GUI.skin = menuSkin;
					
				//	float screenY=Screen.height;
				//	float screenX=Screen.width;

				screenY=((Screen.height*0.8f)-(areaHeight*0.5f));
				screenX=((Screen.width*0.8f)-(areaWidth*0.5f));

				GUILayout.BeginArea(new Rect(screenX,screenY, areaWidth,areaHeight));
			
				if (GameState.bRunning) {
					
						if (GUILayout.Button ("Swap with another live Baby")) {
								print ("swaping baby");
								GameState.SwapBaby ();
						}
						if (GUILayout.Button ("Pause")) {
								print ("pausing");
								GameState.PauseGameState ();
						}
						//why no reset
						if (GUILayout.Button ("Reset")) {

								print ("reseting");
								if (!GameState.baby [GameState.babyIndex].deadBaby) {
										GameState.ResetGameState ();
								} else {
										print ("baby is dead, swap with another baby");
								}
						}
						//why no reset
						if (GUILayout.Button ("Return Home")) {

								print ("returning home");

								GameState.ReturnMainMenu ();
								//GameState.PauseGameState ();

						}
				}
				GUILayout.EndArea();

	}
}
