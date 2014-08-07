using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
	
	public GUISkin menuSkin;
		private  float areaWidth=Screen.width;
		private  float areaHeight=Screen.height;

	public AudioClip beep;
	//old method
	public GameObject receiver;

	public GUIText procreatingTimerText;

	//public GUIText[] babyAgeText;

	
		public static bool bInGetMoreBabies=false;
		public static bool bInBuySuff=false;
		public static bool bInCemetery = false;

		public GUIButton ButtonSelectBaby;
		private GUIStyle buttonStyle;
		private string babyNameTF="New Baby";
		private bool bSubmitted=false;


		//private int liveBabyNum=0;
		private bool bBabyCreated=false;

		private int tempBabyIndexPrevious;
		private int tempBabyIndexNext;

		private Rect rectHunger;
		private Rect rectHungerBackground;	
		private Color colorHunger;
		private Rect rectSleepiness;
		private Rect rectSleepinessBackground;	
		private Color colorSleepiness;
		private Rect rectHappiness;
		private Rect rectHappinessBackground;	
		private Color colorHappiness;
		private Rect rectHealth;
		private Rect rectHealthBackground;	
		private Color colorHealth;

		private Color colorRectBackground;

		private Texture2D _staticRectTexture;
		private GUIStyle _staticRectStyle;

	//public UISelectionBar UISelection;

	void Start()
	{
				procreatingTimerText.text= "";
				procreatingTimerText.transform.position=new Vector3 (0.4f,0.8f, 0f);
				rectHunger = new Rect ((Screen.width>>1)-30, (Screen.height>>1)-28, 100, 10);
				rectHungerBackground = new Rect ((Screen.width>>1)-32, (Screen.height>>1)-32, 110, 14);

				rectSleepiness = new Rect ((Screen.width>>1)-30, (Screen.height>>1)+2, 100, 10);
				rectSleepinessBackground = new Rect ((Screen.width>>1)-32, (Screen.height>>1)-2, 110, 14);

				rectHappiness = new Rect ((Screen.width>>1)-30, (Screen.height>>1)+30, 100, 10);
				rectHappinessBackground = new Rect ((Screen.width>>1)-32, (Screen.height>>1)+26, 110, 14);

				rectHealth = new Rect ((Screen.width>>1)-30, (Screen.height>>1)+60, 100, 10);
				rectHealthBackground = new Rect ((Screen.width>>1)-32, (Screen.height>>1)+56, 110, 14);
				colorRectBackground = new Color (0.4f, 0.4f, 0.4f);

				colorHunger = new Color (1f, 1f, 1f);
				colorSleepiness = new Color (1f, 1f, 1f);
				colorHappiness = new Color (1f, 1f, 1f);
				colorHealth = new Color (1f, 1f, 1f);

			
			//procreatingTimerText.color=;
				//buttonProcreate.x=-100;
				//textfields for babies
		
				//array
				//babyAgeText = new GUIText[GameState.babyNum];
			
				for (int i = 0; i < GameState.babyNum; i++) {
						//arrayversion
						//	babyAgeText[i] = (GUIText)babyAge.AddComponent (typeof(GUIText));
						if (GameState.babyNum == 0) {
								GameState.babyAgeText.text = "you have no babies";
						} else {
								GameState.babyAgeText.text = "your babies";
						}	
				}
			
				StartCoroutine(statusUpdate(1.0F));

	}
		void DrawRect(Rect position, Color color){
				if (_staticRectTexture == null) {
						_staticRectTexture = new Texture2D (1, 1);
				}
				if (_staticRectStyle == null) {
						_staticRectStyle = new GUIStyle ();
				
				}
				_staticRectTexture.SetPixel (0, 0, color);
				_staticRectTexture.Apply ();

				_staticRectStyle.normal.background = _staticRectTexture;

				GUI.Box (position, GUIContent.none, _staticRectStyle);
			
				//
			/*	Texture2D texture = new Texture2D (1, 1);
				texture.SetPixel (0, 0, color);
				texture.Apply ();
				GUI.skin.box.normal.background = texture;
				GUI.Box(position, GUIContent.none)*/
		
		}
		IEnumerator statusUpdate(float waitTime) {
				while (true) {   
						yield return new WaitForSeconds (waitTime);
						//eventually would need token present at all time during procreation process
						if(GameState.bProcreating && !GameState.bDoneProcreating){
						
						
								GameState.procreatingTimer--;
								procreatingTimerText.text="Making New Baby : "+GameState.procreatingTimer;
								if(GameState.procreatingTimer<=0){
										finishProcreatingTimer();


								}
						}
				}
		}
	private void SendMessage(object parameter)
	{
		if(receiver) receiver.SendMessage("OnButtonClicked", parameter, SendMessageOptions.DontRequireReceiver);
	}
	void OnGUI()
		{
				//need hibernate mode


				buttonStyle = new GUIStyle (GUI.skin.button);
				buttonStyle.wordWrap = true;
				buttonStyle.alignment = TextAnchor.UpperCenter;
		
				GUI.skin = menuSkin;
				float screenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
				float screenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
				//GUILayout.BeginArea (new Rect (screenX*0.5f, screenY, areaWidth, areaHeight));
				GUI.BeginGroup (new Rect (screenX * 0.1f, screenY, areaWidth, areaHeight));
				//GUI.BeginGroup(new Rect (-100f, screenY, areaWidth, areaHeight));

				if (GameState.bRunning || bInCemetery || bInBuySuff) {

								GameState.babyNameText.text = "";
								GameState.babyAgeText.text = "";
								GameState.babyHungerText.text = "";
								GameState.babySleepinessText.text = "";
								GameState.babyDiseaseText.text = "";	
								GameState.babyHappinessText.text = "";
								GameState.babyPoopText.text = "";
								GameState.babyHealthText.text = "";	

					
				} else {
				
						//	liveBabyNum = 0;

						//for (int xy = 0; xy < GameState.babyNum; xy++) {
							
						//if (!GameState.baby [xy].deadBaby&&!GameState.baby [xy].isCat) {
						if (!GameState.baby [GameState.babyIndex].deadBaby&&!GameState.baby [GameState.babyIndex].isCat) {

										//add prefix


								string babyNameTxt = GameState.baby [GameState.babyIndex].babyName.ToString ();
										GameState.babyNameText.text = babyNameTxt;
								
									
								string babyTimerTxt ="Age: "+ string.Format ("{0:yyyy-MM-dd}", System.DateTime.Now - GameState.baby [GameState.babyIndex].timeOfBirth);
												//string babyTimerTxt = GameState.baby [xy].babyTimer.ToString ();
												GameState.babyAgeText.text = babyTimerTxt;

								//string babyHungerTxt  ="Hunger: ";
							 	string babyHungerTxt  ="Hunger: "+  GameState.baby [GameState.babyIndex].hunger.ToString ();
												GameState.babyHungerText.text = babyHungerTxt;
												rectHunger.width = GameState.baby [GameState.babyIndex].hunger * 0.01f;
												colorHunger.g = GameState.baby [GameState.babyIndex].hunger * 0.0001f;
												colorHunger.b = GameState.baby [GameState.babyIndex].hunger * 0.0001f;
								DrawRect (rectHungerBackground, colorRectBackground);				
								DrawRect (rectHunger, colorHunger);
											

								string babySleepinessTxt  ="Sleepiness: "+  GameState.baby [GameState.babyIndex].sleepiness.ToString ();
												GameState.babySleepinessText.text = babySleepinessTxt;

								DrawRect (rectSleepinessBackground, colorRectBackground);				
								DrawRect (rectSleepiness, colorSleepiness);
											
								string babyHappinessText  ="Happiness: "+  GameState.baby [GameState.babyIndex].happiness.ToString ();
										GameState.babyHappinessText.text = babyHappinessText;

								DrawRect (rectHappinessBackground, colorRectBackground);				
								DrawRect (rectHappiness, colorHappiness);

								string babyDiseaseTxt  ="Diseases: "+  GameState.baby [GameState.babyIndex].diseaseCounter.ToString ();
												GameState.babyDiseaseText.text = babyDiseaseTxt;

								string babyPoopTxt  ="Poop: "+  GameState.baby [GameState.babyIndex].poop.ToString ();
												GameState.babyPoopText.text = babyPoopTxt;

								string babyHealthTxt  ="Health: "+  GameState.baby [GameState.babyIndex].statusHealth.ToString ();
												GameState.babyHealthText.text = babyHealthTxt;
									
								DrawRect (rectHealthBackground, colorRectBackground);				
								DrawRect (rectHealth, colorHealth);


								//liveBabyNum++;
								} else {
								GameState.babyNameText.text = "";
								GameState.babyAgeText.text = "";
								GameState.babyHungerText.text = "";
								GameState.babySleepinessText.text = "";
								GameState.babyHappinessText.text = "";
								GameState.babyDiseaseText.text = "";								
								GameState.babyPoopText.text = "";
								GameState.babyHealthText.text = "";
								}
						//}
					

				}
				
				if (!GameState.bRunning) {
			
						if (bInGetMoreBabies) {
								//if (GUILayout.Button ("Procreate")) {
								//set var for size
								if (!GameState.bProcreating) {
										if (GUI.Button (new Rect (0, 60, 120, 30), "Procreate", buttonStyle)) {

												print ("GameState.bProcreating");
												GameState.bProcreating = true;
										}
								}

								//if (GUILayout.Button ("Back")) {
								if (GUI.Button (new Rect (0, 90, 120, 30), "Back", buttonStyle)) {

										bInGetMoreBabies = false;
								}


								if (GameState.bDoneProcreating && !bSubmitted) {
										//	GUILayout.BeginArea (new Rect ((liveBabyNum*100f / Screen.width)+0.25f, screenY*0.7f, areaWidth, areaHeight));
										GUILayout.BeginArea (new Rect ((Screen.width * 0.5f) - 250f, Screen.height * 0.7f, 250f, 400f));



										print ("bBabyCreated = " + bBabyCreated);
										GUILayout.BeginVertical ();
										if (!bBabyCreated) {
												GameState.createBaby ("Your New Baby!");
											
												bBabyCreated = true;
										}

										if (GameState.baby [GameState.babyIndex].isItABoy) {
												//	GUI.Label (new Rect (0, 60, 200, 30), "Congratulations! It's a baby boy!", buttonStyle); 

												GUILayout.Label ("Congratulations! It's a boy!", GUILayout.Width (200));
										} else {
												//		GUI.Label (new Rect (0, 60, 200, 30), "Congratulations! It's a baby girl!", buttonStyle);

												GUILayout.Label ("Congratulations! It's a girl!", GUILayout.Width (200));
										}
										// First Name
										GUILayout.BeginHorizontal ();
										//	GUI.Label (new Rect (200, 90, 180, 30), "Your baby's Name", buttonStyle);

										GUILayout.Label ("Your baby's Name", GUILayout.Width (90));
										//babyNameTF = GUI.TextField (new Rect (180, 120, 220, 30), babyNameTF);
										babyNameTF = GUILayout.TextField (babyNameTF);
										GUILayout.EndHorizontal ();
										//if (GUI.Button (new Rect (200, 150, 180, 30), "Submit", buttonStyle)) {
										if (GUILayout.Button ("Submit")) {
												print ("GameState.babyIndex = " + GameState.babyIndex);
												GameState.baby [GameState.babyNum - 1].babyName = babyNameTF;
										
												doneProcreating ();
										}

										GUILayout.EndVertical ();
										GUILayout.EndArea ();
								}


						} else if (bInCemetery) {
								GameState.hideBabiesMainMenu ();
								GameState.babyTombstones ();
								if (GUI.Button (new Rect (0, 60, 120, 30), "Revive Selected Baby! (10 coins)", buttonStyle)) {
										//if (GUILayout.Button ("Revive Selected Baby! (10 coins)")) {
										if (GameState.baby [GameState.babyIndex].deadBaby) {
												if (GameState.coins >= 0) {
														//hard cash?
														GameState.deadBabyNum--;
														GameState.coins -= 0;
														GameState.HUDinstance.UpdateCoins ();
														GameState.baby [GameState.babyIndex].reviveBaby ();
														showBabies();
												} else {
														print ("Not enough coins!");
												}
										} else {
												print ("No dead baby to revive!");
										}
								}

								//	if (GUILayout.Button ("Back")) {
								if (GUI.Button (new Rect (0, 90, 120, 30), "Back", buttonStyle)) {
										bInCemetery = false;
										showBabies();
								}



						} else if (bInBuySuff) {
								GameState.hideBabiesMainMenu ();
								int xNumItems = 0;
								///could be horizontally set with images******************
								while (xNumItems<GameState.numItems) {
										GUILayout.BeginArea (new Rect ((Screen.width * 0.07f)+xNumItems*Screen.width*0.15f, Screen.height * 0.7f, 80f, 400f));
							

										GUILayout.BeginVertical ();
										//GUILayout.BeginHorizontal ();

										GUILayout.Label (GameState.itemData.itemsName[xNumItems], GUILayout.Width (90));
										GUILayout.Label (GameState.itemData.description[xNumItems], GUILayout.Width (90));
										if(GameState.itemData.itemsGroupName [xNumItems]!="Collectible"){
											
											GUILayout.Label ("Number Possessed: "+GameState.itemData.numPossessed[xNumItems], GUILayout.Width (90));
										}

										//	GUILayout.EndHorizontal ();
										if (GUILayout.Button ("Buy! (3 coins)")) {
												print ("bought item  = " +GameState.itemData.itemsName[xNumItems]);
												GameState.itemData.numPossessed [xNumItems]++;
											switch(GameState.itemData.itemsTypeName [xNumItems] ){
											case "Coin":
												GameState.AddCoins (200);
												print("bought coins");
												break;
											case "Food":
												GameState.AddFood (20);
												print("bought Food");
												break;
											}
										}
					if(GameState.itemData.itemsGroupName [xNumItems]!="Collectible"){
						if (GUILayout.Button ("Assign to Currently Selected Baby")) {
							if (GameState.itemData.numPossessed [xNumItems] > 0) {
								
								switch(GameState.itemData.itemsGroupName [xNumItems] ){
									
									
								case "Arm":
									if (GameState.baby [GameState.babyIndex].babyArmLeftJoint == null) {
										GameState.itemData.numPossessed [xNumItems]--;
										if (GameState.baby [GameState.babyIndex].babyArmLeft != null) {
											DestroyImmediate (GameState.baby [GameState.babyIndex].babyArmLeft);
										}
										GameState.baby [GameState.babyIndex].armLeftPart = GameState.itemData.itemsTypeName [xNumItems];
										GameState.baby [GameState.babyIndex].isArmLeftAttached = true;
										GameState.baby [GameState.babyIndex].resetMembers ();
										//reattach 
									}else if(GameState.baby [GameState.babyIndex].babyArmRightJoint == null){
										
										GameState.itemData.numPossessed [xNumItems]--;
										if (GameState.baby [GameState.babyIndex].babyArmRight != null) {
											DestroyImmediate (GameState.baby [GameState.babyIndex].babyArmRight);
										}
										GameState.baby [GameState.babyIndex].armRightPart = GameState.itemData.itemsTypeName [xNumItems];
										GameState.baby [GameState.babyIndex].isArmRightAttached = true;
										GameState.baby [GameState.babyIndex].resetMembers ();
									}
									break;
									//objects are not destroyed
								case "Leg":
									if (GameState.baby [GameState.babyIndex].babyLegLeftJoint == null) {
										GameState.itemData.numPossessed [xNumItems]--;
										if (GameState.baby [GameState.babyIndex].babyLegLeft != null) {
											DestroyImmediate (GameState.baby [GameState.babyIndex].babyLegLeft.gameObject);
											
										}
										GameState.baby [GameState.babyIndex].legLeftPart = GameState.itemData.itemsTypeName [xNumItems];
										GameState.baby [GameState.babyIndex].isLegLeftAttached = true;
										GameState.baby [GameState.babyIndex].resetMembers ();
									} else if (GameState.baby [GameState.babyIndex].babyLegRightJoint == null) {
										GameState.itemData.numPossessed [xNumItems]--;
										if (GameState.baby [GameState.babyIndex].babyLegRight != null) {
											
											DestroyImmediate (GameState.baby [GameState.babyIndex].babyLegRight.gameObject);
											
										}
										GameState.baby [GameState.babyIndex].legRightPart = GameState.itemData.itemsTypeName [xNumItems];
										GameState.baby [GameState.babyIndex].isLegRightAttached = true;
										GameState.baby [GameState.babyIndex].resetMembers ();
									}
									break;
								case "Head":
									if (GameState.baby [GameState.babyIndex].babyHeadJoint == null) {
										GameState.itemData.numPossessed [xNumItems]--;
										if (GameState.baby [GameState.babyIndex].babyHead != null) {
											DestroyImmediate (GameState.baby [GameState.babyIndex].babyHead.gameObject);
											
										}
										GameState.baby [GameState.babyIndex].headPart = GameState.itemData.itemsTypeName [xNumItems];
										GameState.baby [GameState.babyIndex].isHeadAttached = true;
										GameState.baby [GameState.babyIndex].resetMembers ();
									} 
									break;
								}
							}
						}
					}
									GUILayout.EndVertical ();
									GUILayout.EndArea ();
									xNumItems++;
				}
								///test

								/*	if (GUI.Button (new Rect (0, 60, 120, 30), "Buy!", buttonStyle)) {

										//if (GUILayout.Button ("Buy!")) {
										if (GameState.coins > 0) {

												GameState.coins--;
												GameState.HUDinstance.AddCoins ();
										
										} else {
												print ("Not enough coins!");
										}
								}*/

								if (GUI.Button (new Rect (0, 90, 120, 30), "Back", buttonStyle)) {
										GameState.hideItemsMainMenu ();

										bInBuySuff = false;

				}
			} else {
										procreatingTimerText.text= "";
						
								//	GameState.showBabiesMainMenu ();
										//	if (GUILayout.Button ("RUN!")) {
				if (GUI.Button (new Rect (0, 60, 120, 30), "RUN!", buttonStyle)) {

						run ();
										

				}

										//if (GUILayout.Button ("Get More Babies")) {
										if (GUI.Button (new Rect (0, 90, 120, 30), "Get More Babies", buttonStyle)) {

												bInGetMoreBabies = true;
										}
										if (GUI.Button (new Rect (0, 120, 120, 30), "Baby Cemetery", buttonStyle)) {

												//	if (GUILayout.Button ("Baby Cemetery")) {

												bInCemetery = true;
				}
								if (GUI.Button (new Rect (0, 150, 120, 30), "Buy Stuff", buttonStyle)) {

										//if (GUILayout.Button ("Buy Stuff")) {
												GameState.showItemsMainMenu ();
												bInBuySuff = true;
				}

										if (GUI.Button (new Rect (0, 180, 120, 30), "Quit", buttonStyle)) {

												//if (GUILayout.Button ("Quit")) {
												GameState.saveBabiesToData ();
												Application.Quit ();
				}


			}
			
		}
			
						//	GUILayout.EndArea ();
	GUI.EndGroup ();
			
	GUI.BeginGroup (new Rect ((Screen.width * 0.2f), (Screen.height * 0.1f), (Screen.width * 0.5f) , (Screen.height * 0.4f)));
	if (!GameState.bRunning && !bInCemetery && !bInBuySuff) {
			if (!GameState.baby [GameState.babyIndex].deadBaby&&!GameState.baby [GameState.babyIndex].isCat) {
				if (GUI.Button (new Rect (50 , 0, 120, 30), "FEED BABY", buttonStyle)) {
					//if (GUILayout.Button ("FEED BABY " + xy)) {
					if (GameState.food > 0) {
											
												GameState.baby [GameState.babyIndex].hunger += 100;
												GameState.food--;
												GameState.updateBabyStatus();
												GameState.baby [GameState.babyIndex].foodEatenCounter++;
												GameState.baby [GameState.babyIndex].healBaby (20);
												if (Random.Range (0, 3) < 1 && GameState.baby [GameState.babyIndex].diseaseCounter>0 ) {
														GameState.baby [GameState.babyIndex].diseaseCounter--;

												}

												if (GameState.baby [GameState.babyIndex].foodEatenCounter > 4 && Random.Range (0, 5) < 1) {
														GameState.baby [GameState.babyIndex].poop++;
														GameState.baby [GameState.babyIndex].foodEatenCounter = 0;
												}
												if (GameState.baby [GameState.babyIndex].hunger > GameState.baby [GameState.babyIndex].maxHunger)
														GameState.baby [GameState.babyIndex].hunger =  GameState.baby [GameState.babyIndex].maxHunger;
												GameState.HUDinstance.UpdateFood ();

					} else {
						print ("Not enough Food!");
					}
				}
				if (GUI.Button (new Rect (50, 30, 120, 30), "CLEAN POOP", buttonStyle)) {
					//	GameState.HUDinstance.RemovePoop ();
					GameState.baby [GameState.babyIndex].poop = 0;
					//DIAPERS?
				}

								tempBabyIndexPrevious = GameState.getPreviousBabyIndex (false);
								tempBabyIndexNext = GameState.getNextBabyIndex (false);

								int i;
								//print(System.DateTime.Now+"baby alert true "+i);
								for (i=0;i<GameState.baby.Count;i++){
										if(GameState.baby[i].statusHealth<40
												||!GameState.baby[i].isArmLeftAttached
												||!GameState.baby[i].isArmRightAttached
												||!GameState.baby[i].isLegLeftAttached
												||!GameState.baby[i].isLegRightAttached
												||GameState.baby[i].happiness<200
												||GameState.baby[i].sleepiness<200
												||GameState.baby[i].diseaseCounter>1
										){
												if (i < GameState.babyIndex) {
														//		GameState.HUDinstance.alert.createAlertPrevious ();

														GameState.HUDinstance.alert.signPrevious.guiTexture.enabled = true;
									
												} else if (i > GameState.babyIndex) {
														//	GameState.HUDinstance.alert.createAlertNext ();

														GameState.HUDinstance.alert.signNext.guiTexture.enabled = true;
												} else {
														//		GameState.HUDinstance.alert.createAlertCurrent ();

														GameState.HUDinstance.alert.signCurrent.guiTexture.enabled = true;

												}
												//print (System.DateTime.Now + "baby - " +GameState.babyIndex+" - alert true " + i);
										}
								}

							

								if (tempBabyIndexPrevious !=	GameState.babyIndex) {

										if (GUI.Button (new Rect (-50, 100, 120, 30), "Previous", buttonStyle)) {
												GameState.babyIndex = GameState.getPreviousBabyIndex (true);
												print (System.DateTime.Now + "previous GameState.babyIndex = " + GameState.babyIndex);
												showBabies();

										}
								}
							
								if (tempBabyIndexNext !=	GameState.babyIndex) {

										if (GUI.Button (new Rect (150, 100, 120, 30), "Next", buttonStyle)) {

												GameState.babyIndex = GameState.getNextBabyIndex (true);
												print (System.DateTime.Now + "next GameState.babyIndex = " + GameState.babyIndex);
												showBabies();
										}
								}
				

			}


//multiple baby version
	/*					liveBabyNum = 0;
						//if (!bInGetMoreBabies) {
						int xy;
		for (xy = 0; xy < GameState.babyNum; xy++) {
			if (!GameState.baby [xy].deadBaby&&xy!=0) {
				if (GUI.Button (new Rect (50 + (liveBabyNum * 130), 0, 120, 30), "FEED BABY" + xy, buttonStyle)) {
												//if (GUILayout.Button ("FEED BABY " + xy)) {
					if (GameState.food > 0) {
						if (GameState.baby [xy].hunger < 0)
																GameState.baby [xy].hunger = 0;
														GameState.baby [xy].hunger += 100;
														GameState.food--;
														GameState.baby [xy].foodEatenCounter++;
														GameState.baby [xy].healBaby (20);
							if (Random.Range (0, 3) < 1) {
																GameState.baby [xy].diseaseCounter--;
														
							}

							if (GameState.baby [xy].foodEatenCounter > 4) {
																GameState.baby [xy].poop++;
																GameState.baby [xy].foodEatenCounter = 0;
							}
														GameState.HUDinstance.AddFood ();
						} else {
														print ("Not enough Food!");
						}
					}
					if (GUI.Button (new Rect (50 + (liveBabyNum * 130), 30, 120, 30), "CLEAN POOP" + xy, buttonStyle)) {
												//	GameState.HUDinstance.RemovePoop ();
												GameState.baby [xy].poop = 0;
												//DIAPERS?
					}

					if (GUI.Button (new Rect (50 + (liveBabyNum * 130), 60, 120, 30), "SELECT BABY" + xy, buttonStyle)) {

												GameState.babyIndex = xy;

					}
										liveBabyNum++;
				}

			}*/

						//}

		} else if (bInCemetery) {

			int deadBabyNumTemp = 0;
			for (int xy = 0; xy < GameState.baby.Count; xy++) {
				if (GameState.baby [xy].deadBaby&&!GameState.baby [xy].isCat) {

					if (GUI.Button (new Rect (80 + (deadBabyNumTemp * 130), 40, 100, 40), "SELECT DEAD BABY " + xy, buttonStyle)) {

												GameState.babyIndex = xy;
												
					}

										string babyNameTxt = GameState.baby [GameState.babyIndex ].babyName.ToString ();
										GameState.babyNameText.text = babyNameTxt;

										string babyTimerTxt = string.Format ("{0:yyyy-MM-dd}", System.DateTime.Now - GameState.baby [GameState.babyIndex ].timeOfBirth);

										GameState.babyAgeText.text = babyTimerTxt;

										string babyHungerTxt = GameState.baby [GameState.babyIndex ].hunger.ToString ();
										GameState.babyHungerText.text = babyHungerTxt;

										string babySleepinessTxt = GameState.baby [GameState.babyIndex ].sleepiness.ToString ();
										GameState.babySleepinessText.text = babySleepinessTxt;

										string babyPoopTxt = GameState.baby [GameState.babyIndex ].poop.ToString ();
										GameState.babyPoopText.text = babyPoopTxt;

										string babyHealthTxt = GameState.baby [GameState.babyIndex ].statusHealth.ToString ();
										GameState.babyHealthText.text = babyHealthTxt;
										deadBabyNumTemp++;

				}

			}
		}				 
						//}
						GUI.EndGroup ();

	}
	public void run(){
				GameState.bShowMainMenu = false;
				GameState.swapCamera ();
				GameState.resetGameScene ();
	}

	public void OpenLevel(string level){
		
		audio.PlayOneShot(beep);
		//yield new WaitForSeconds(0.35);
		Application.LoadLevel(level);
	
	}
	public void finishProcreatingTimer(){
		
				//GameState.bProcreating=false;
		print ("%%%% finished timer ? ");
		GameState.bDoneProcreating = true;
		GameState.procreatingTimer=GameState.resetProcreationTime;	
		//	GameState.createBaby("jojo");

	}
		private void doneProcreating(){
				print ("!!!!! doneProcreating ? ");
				GameState.bDoneProcreating = false;
				bBabyCreated = false;
				GameState.bProcreating = false;
				GameState.saveBabiesToData ();
				procreatingTimerText.text= "";
				//bSubmitted = true;
			
		
		}
	private void showBabies(){
		GameState.showBabiesMainMenu();
		GameState.updateAvatarColors();
	}

	private static void createSelectionIcons(){
		
		//removeDots();
		//	createDots();
		
	}
		public void submitBabyName(string babyNameParam){

				GameState.createBaby(babyNameParam);
		}

	
}

//@script RequireComponent(AudioSource);