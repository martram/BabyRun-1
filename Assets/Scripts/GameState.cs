using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour
{
	//audio
	//	public AudioController Audio= new AudioController();
		//private AudioClip MenuMusic;
	public static  AudioController AudioControl;

	//menuItems
	
	public static GUIText babyNameText;
	public static GUIText babyAgeText;
	public static GUIText babyHungerText;
	public static GUIText babySleepinessText;
	public static GUIText babyHappinessText;
	public static GUIText babyDiseaseText;
	public static GUIText babyPoopText;
	public static GUIText babyHealthText;
		/*public static List<GUIText> babyNameText;
	public static List<GUIText> babyAgeText;
	public static List<GUIText> babyHungerText;
	public static List<GUIText> babySleepinessText;
	public static List<GUIText> babyHappinessText;
	public static List<GUIText> babyDiseaseText;
	public static List<GUIText> babyPoopText;
	public static List<GUIText> babyHealthText;*/


	public static HUD HUDinstance;
	public static GameObject HUDobject;
	public static Rect  HUDRect;
	public static Vector2  cameraPoint;
	public 	static Font arialFont;
	public static List<GameObject> tombstones;
	public static List<GameObject> itemsGo;
	public static int numItems=4;
	public static int idx=0;
	public static GameObject itemListGo;
	public static List<ItemClass> itemList;
    public static ItemDataClass itemData = new ItemDataClass ();
	public static int resetProcreationTime=4;
	public static int procreatingTimer=resetProcreationTime;
	public static bool bShowMainMenu=true;
	public static bool bProcreating=false;
	public static bool bDoneProcreating=false;

	//public static List<String> bodyParts
	
	//generics 

	public static GameObject cameraPerspective;
	public static GameObject cameraOrthogonal;
	public static float defTimeScale = 1f;	
	public static bool bPaused = true;
	public static bool bGamesceneSet=false;
	public static bool bRunning = false;
	public static int safeCollideLayer;
	public static int  currentHighScore;
	private static bool bIsLoaded=false;
	private const int timeRatio = 16000;
	
	
	//player data
	public static TextMesh coinCounter;
	public static TextMesh foodCounter;
	public static int coins = 0;
	public static int food = 0;
	public static CarriageController stroller;
	public static GameObject strollerObject;
	public static bool bFirstTimeUser=true;
	public static Vector3 startPosition = new Vector3 (0, 0.85f, 0);
	public static bool isCatInFace = false;
	private static int catStuckEnergy = 100;
	public static GameObject playerCharacterFaceNode;
	
	//baby data
		//public static GameObject strollerBabyNodeObject;
	public static List<Baby> baby;
	public static List<BabyData> babyData;
	public  static int babyIndex= 0;
	public static int babyNum = 0;
	public static bool bBabyInStroller = false;
	public static int deadBabyNum=0;
		private static int liveBabyNum = 0;
	
	//assets data
	public static List<CarController> cars;
	public static int carIndex=0;
	private static float startTimeLeft, startTimeRight;
	private static float carTimeLeft = 0.5f;
	private static float carTimeRight = 0.5f;

		private static int carFrequencyLeft=40;
		private static int carFrequencyRight=40;
		private static GameObject coinObject;
		private static BoxCollider coinCollider;
		public static GameObject ParticleCoins;
		public static GameObject ParticleFood;

	//road data
	public static List<Roads> roads;
	public static int currentRoadIndex=0;
	public static Roads road01, road02, road03;
	public static GameObject roadObject01,roadObject02,roadObject03;
	public static float roadLength=83.25f;
	public static int roadIndex=0;
	
	public static GameObject PC;
	public static float[] lanes = new float[4];
		public static int numPositions=10;
	public static float[] lengthPositions = new float[numPositions];
		public static float[] objectPosLength = new float[12];
		public static int hugePool=38;
		public static int bigPool=16;
		public static int smallPool=8;
		public static int barrierPoolIndex = -1;
		public static int scaffoldPoolIndex = -1;
		public static int coinPoolIndex = -1;
		//road pool
		//	public GameObject[] walkwayStraightLeftPool, walkwayStraightRightPool, walkwayCurvedRightPool, walkwayCurvedLeftPool,  streetCenterPool, streetSideRightPool, streetSideLeftPool, roadSideLeftPool, roadSideRightPool, roadSideQuarterRightPool, roadSideQuarterLeftPool, mainRoadPool = new GameObject[8];
	
		//Object Pool
		//public GameObject[] stopPostPool, lampPostPool, signPostPool, foodStandPool; 

		public static GameObject[] barrierPool = new GameObject[bigPool];
		public static GameObject[] buildingCubePool= new GameObject[bigPool];
		//	public static GameObject[] scaffoldPool = new GameObject[smallPool];
		public static GameObject[] coinPool = new GameObject[hugePool];


		public GameObject[] fireHydrantPool = new GameObject[smallPool];
		public static Coin[] coinControllerPool;

	private bool couldBeSwipe;
		private Vector2 startPos;
		private float startTime;
		private float comfortZoneY;
		private float maxSwipeTime,minSwipeDist;

	//private bool isFollowingBaby=false;
	private static Vector3 catFacePos;

	private  static GameObject UISelection;
	private static UISelectionBar SelectionDots;
	public GameState(){
		
			print ("new gamestate");

		}
	
		void Awake () {
				// Make the game run as fast as possible in the web player
				Application.targetFrameRate = 90;

		}

	void Start()
		{
		//MainMenu Baby assets
		UISelection= new GameObject("UISelection");
		SelectionDots= UISelection.AddComponent<UISelectionBar>();

				//create pools
				/*		for (int x = 0; x < hugePool; x++) {
						coinPool[x] = (GameObject)GameObject.Instantiate (Resources.Load ("CollectibleAssets/Coin", typeof(GameObject)));
						//	coinPool[x].gameObject.AddComponent<MeshCollider> ().sharedMesh = coinPool[x] .GetComponentInChildren<MeshFilter> ().sharedMesh;
						coinPool[x].AddComponent<BoxCollider> ().size= new Vector3 (4.2f, 4.2f, 4.2f);

						coinPool [x].collider.isTrigger = true;
						coinPool[x].AddComponent<Coin> ();
						// coinPool[x].transform.parent = coinPool[x].AddComponent<CoinController> ().transform;
						coinPool [x].tag = "Coin";
						coinPool[x].renderer.castShadows = false;
						coinPool[x].renderer.receiveShadows = false;
						coinPool [x].renderer.enabled = false;
						coinPool [x].collider.enabled = false;




				}*/
			

				for (int x = 0; x < bigPool; x++) {
						barrierPool[x] = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/WoodBarrier", typeof(GameObject)));
						barrierPool[x].gameObject.AddComponent<MeshCollider> ().sharedMesh = barrierPool[x] .GetComponentInChildren<MeshFilter> ().sharedMesh;
						barrierPool[x].AddComponent<Rigidbody> ();
						barrierPool [x].rigidbody.useGravity = false;
						barrierPool [x].rigidbody.isKinematic = true;
						barrierPool [x].renderer.enabled = false;
						barrierPool [x].collider.enabled = false;
						//		barrierPool [x].transform.position = new Vector3(-100,-100,-100);

				}
				/*	for (int x = 0; x < smallPool; x++) {
						scaffoldPool[x]= (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/Scaffold", typeof(GameObject)));
						scaffoldPool[x].gameObject.AddComponent<MeshCollider> ().sharedMesh = scaffoldPool[x] .GetComponentInChildren<MeshFilter> ().sharedMesh;	

						scaffoldPool[x].renderer.enabled = false;
						scaffoldPool [x].collider.enabled = false;
						scaffoldPool [x].transform.parent = null;
						scaffoldPool [x].transform.Translate (0, 0, 0);

				}*/

			
				ParticleCoins= GameObject.Find("ParticleCoins");
				ParticleFood= GameObject.Find("ParticleFood");

				safeCollideLayer = LayerMask.NameToLayer("Nonfatal Collision");
				HUDobject = GameObject.Find ("HUD");
				HUDinstance = HUDobject.GetComponent<HUD> ();
				//for asset positionning
				HUDRect = (new Rect (HUDinstance.screenX, HUDinstance.screenY, HUDinstance.areaWidth, HUDinstance.areaHeight));
			

				cameraOrthogonal=GameObject.Find("Ortho Camera");
				cameraPerspective=GameObject.Find("Main Camera");
				//cameraPoint = Camera.main.ScreenToWorldPoint (HUDRect.center);
				cameraPoint = cameraPerspective.camera.ScreenToWorldPoint (HUDRect.center);

				cameraOrthogonal.camera.enabled = true;
				cameraPerspective.camera.enabled = false;
			


				arialFont = (Font)Resources.Load ("Fonts/Arial Black");
				babyNameText = new GUIText();
				babyAgeText = new GUIText();
				babyHungerText = new GUIText();
				babySleepinessText = new GUIText();
				babyHappinessText =new GUIText();
				babyDiseaseText = new GUIText();
				babyPoopText = new GUIText();
				babyHealthText = new GUIText();

				lanes [0] = -8f;
				lanes [1] = -2.2f;
				lanes [2] = 2.2f;
				lanes [3] = 8f;
				for (var z = 0; z < numPositions; z++) {

						lengthPositions [z] = roadLength / numPositions * z;
				}
				baby = new List<Baby> ();
				babyData = new List<BabyData> ();
				defTimeScale = Time.timeScale;

		
				cars = new List<CarController> ();
				PC = GameObject.Find ("PC");
				PC.rigidbody.useGravity = false;
				PC.rigidbody.mass = 90f;

				roads = new List<Roads> ();
				CreateStroller ();
				
				if (!bIsLoaded) {
						SaveLoad.Load ();
						if (SaveLoad.bFileExist) {
					
							print ("SaveLoad loaded");

								loadGamestate ();

						} else {
								bFirstTimeUser = true;

						}
				}



				if (bFirstTimeUser||baby[0]==null) {
						createBaby ("Cat Scratch");
				}
				StartCoroutine(statusUpdate(1.0F));
				startTimeLeft = Time.time;
				startTimeRight = Time.time;

				itemsGo = new List<GameObject> ();
				itemList = new List<ItemClass> ();
				createInventory ();

				AudioControl = cameraPerspective.AddComponent<AudioController>();
			
				AudioControl.playMenuMusic ();

		}
		public static void setLiveBabyNum(int newNum){
				liveBabyNum= newNum;
		}
		public static int getLiveBabyNum(){
				return liveBabyNum;
		}
		public static int getLiveBabyIndex(){
		int tempIndex=0;
		int i;
		int tempLiveBaby=0;
		for(i=0;i<baby.Count;i++){
			if(!baby[i].deadBaby){
				if(babyIndex==i){
					tempIndex=i;

				}
				tempLiveBaby++;
			}

		}

			return tempIndex;
		}
		private static void loadGamestate(){
				bFirstTimeUser = false;
				bIsLoaded = true;
				coins = SaveLoad.data.numCoins;
				food = SaveLoad.data.numFood;
				//calculate time elapsed
				procreatingTimer = SaveLoad.data.procreatingTimer;

				bDoneProcreating = SaveLoad.data.bDoneProcreating;
				bProcreating = SaveLoad.data.bProcreating;
				if (bDoneProcreating) {
						bDoneProcreating=false;
						bProcreating=false;
						procreatingTimer = resetProcreationTime;
				}
				currentHighScore = SaveLoad.data.highScore;
				itemData = SaveLoad.data.itemData;
				HUDinstance.UpdateCoins ();
				HUDinstance.UpdateFood ();

				HUDinstance.UpdateHighScore (currentHighScore);
				babyIndex = SaveLoad.data.babyIndex;

				for(var x = 0; x < SaveLoad.data.babyNum; x++){
						createBaby("tempNameLoad");
						//baby [x].resetBaby ();

				}

		}
	public static void FollowBaby(){
		//camera follows baby when tossed
		print("camera follow baby");
	//	cameraPerspective.transform.parent= baby[babyIndex].transform;
	//	isFollowingBaby=true;

	} 
	private void resetCamera(){
		//isFollowingBaby=false;
		cameraPerspective.transform.position= new Vector3(-2f,4f,5f);
		//cameraPerspective.transform.parent = PC.transform;

	}
	private void Update(){


		if(isCatInFace){
			cameraPerspective.transform.position = new Vector3(baby[babyIndex].transform.position.x, baby[babyIndex].transform.position.y+4f-catFacePos.y, baby[babyIndex].transform.position.z-5f-catFacePos.z);
		}else if(baby[babyIndex].isTossed){

			cameraPerspective.transform.position = new Vector3(baby[babyIndex].transform.position.x, cameraPerspective.transform.position.y, baby[babyIndex].transform.position.z-5f-catFacePos.z);

		}else{
			cameraPerspective.transform.position = new Vector3(baby[babyIndex].transform.position.x,  baby[babyIndex].transform.position.y+4f, baby[babyIndex].transform.position.z-5f);

		}
	}
		IEnumerator statusUpdate(float waitTime) {
				while (true) {   
						yield return new WaitForSeconds (waitTime);
						if (bGamesceneSet && !bPaused && !baby[babyIndex].isTossed) {
								//out of range?
								//if (!cars [carIndex-1].isHonking&& cars [carIndex-1].transform.position.x==stroller.transform.position.x) {
								//		cars [carIndex-1].PlayCarHorn ();
								//}


								if (Time.time - startTimeLeft > carTimeLeft && Random.Range (0, 100) < carFrequencyLeft) {
										startTimeLeft = Time.time;
										createVehicule (lanes [1]);
								}
								if (Time.time - startTimeRight > carTimeRight && Random.Range (0, 100) < carFrequencyRight) {
										startTimeRight = Time.time;
										createVehicule (lanes [2]);
								}
								if (PC.transform.position.z > roads [roadIndex - 1].transform.position.z - 150f) {
										createRoad ();
								}
					
								if (baby [babyIndex].isCat) {
										if (Random.Range (0, 6) < 1 && !isCatInFace) {
												isCatInFace = true;
												catStuckEnergy = 100;
												//animate cat in face or player
												baby [babyIndex].transform.position = playerCharacterFaceNode.transform.position;
												baby [babyIndex].transform.Rotate (-90f, 0f, 0f);
								
										} else if (isCatInFace && Random.Range (0, 3) < 1) {

												//force strafe
												/*	if (Random.Range (0, 1) > 0.5) {

														stroller.StartStrafeRight ();
												} else {
														stroller.StartStrafeLeft ();
												}*/
												if (baby [babyIndex].isCat && Random.Range (0, 9) < 1) {

														removeCatFromFace ();
												}
														
										}
								} 
						}
				}
	}
		public static void swapCamera(){

				if (cameraPerspective.camera.enabled) {
						cameraOrthogonal.camera.enabled = true;
						cameraPerspective.camera.enabled = false;
						for (var z = 0; z < baby.Count-1; z++) {
					
								//baby[z].transform.localScale = new Vector3(0.5f,0.5f,0.5f);

								 		}
				} else {
						cameraOrthogonal.camera.enabled = false;
						cameraPerspective.camera.enabled = true;
						for (var z = 0; z < baby.Count-1; z++) {

							//	baby[z].transform.localScale = new Vector3(1f,1f,1f);

						 		}

				}


		}
		public static void removeCatFromFace(){
		
		 //	baby [babyIndex].transform.localPosition = Vector3.zero;

			 	baby [babyIndex].transform.position = stroller.strollerBabyNode.transform.position;
				baby [babyIndex].transform.Rotate (90f, 0f, 0f);
				isCatInFace = false;
				catStuckEnergy = 0;
			
		}
	public static void reduceCatStuckEnergy(){
		
				catStuckEnergy-=20;
				if (catStuckEnergy <= 0) {
						removeCatFromFace ();
				}
	}

	public static bool IsPaused()
	{
		return bPaused;
	}
	
	public static void AddCoins(int count)
	{
				coins += count;
				//coinCounter.text = "x"+coins;
				HUDinstance.UpdateCoins ();
	}
		public static void RemoveCoins(int count)
		{
				coins -= count;
				//coinCounter.text = "x"+coins;
				HUDinstance.UpdateCoins ();
		}
	
	public static void AddFood(int count)
	{
				food += count;
				HUDinstance.UpdateFood ();
				//	foodCounter.text = "x"+food;
	}
		public static void RemoveFood(int count)
		{
				food -= count;
				//coinCounter.text = "x"+coins;
				HUDinstance.UpdateCoins ();
		}


		public static void PauseGameState(){
				if(bPaused) Time.timeScale = defTimeScale;
				else Time.timeScale = 0f;
				bPaused = !bPaused;
		}

		public static void CreateStroller(){
		
		//	GameObject govar=  new GameObject("Stroller");
		stroller = PC.AddComponent<CarriageController>();
		strollerObject = GameObject.Find("DuckTree");
		playerCharacterFaceNode = GameObject.Find("PlayerFaceNode");
		playerCharacterFaceNode.renderer.enabled = false;

		stroller.createIdentity(strollerObject);
			
		stroller.strollerObject.transform.parent = PC.transform;

		stroller.transform.parent=strollerObject.transform;
		stroller.strollerCollisionObject.transform.parent = PC.transform;
		//stroller.transform.Translate(0f,0.85f,0f);
		stroller.transform.Translate(0f,0f,0f);
	 	 

	}
	//baby related functions
	
	public static void createBaby(string babyName){

				//GetBaby<Baby>();
				GameObject govar=  new GameObject("Baby");	
				Baby babyObject= govar.AddComponent<Baby>();	
		
				baby.Add(babyObject);	

				BabyData bbd= new BabyData();
				babyData.Add(bbd);

				System.DateTime creationDate = System.DateTime.Now;

				if (SaveLoad.bFileExist&&SaveLoad.data.babyData.Count>babyNum) {
			print ("savefile exist! "+SaveLoad.data.babyData [babyNum].diseaseCounter);
						creationDate = SaveLoad.data.babyData [babyNum].timeOfBirth;
						System.TimeSpan timeElapsed = (System.DateTime.Now - creationDate);

						baby [babyNum].isItABoy = SaveLoad.data.babyData [babyNum].bIsItABoy;
						baby [babyNum].race = SaveLoad.data.babyData [babyNum].race;
						baby [babyNum].isCat = SaveLoad.data.babyData [babyNum].bCat;
					
						babyName = SaveLoad.data.babyData [babyNum].babyName;

						baby [babyNum].babyID = SaveLoad.data.babyData [babyNum].babyID;
						baby [babyNum].deadBaby = SaveLoad.data.babyData [babyNum].deadBaby;
						baby [babyNum].statusHealth = SaveLoad.data.babyData [babyNum].statusHealth;
						baby [babyNum].statusHead = SaveLoad.data.babyData [babyNum].statusHead;
						baby [babyNum].statusLegLeft = SaveLoad.data.babyData [babyNum].statusLegLeft;
						baby [babyNum].statusLegRight = SaveLoad.data.babyData [babyNum].statusLegRight;
						baby [babyNum].statusArmLeft = SaveLoad.data.babyData [babyNum].statusArmLeft;
						baby [babyNum].statusArmRight = SaveLoad.data.babyData [babyNum].statusArmRight;
						baby [babyNum].statusTorso = SaveLoad.data.babyData [babyNum].statusTorso;
						if (baby [babyNum].statusHealth<=0 || baby [babyNum].statusHead<=0 || baby [babyNum].statusArmLeft<=0) {
								baby [babyNum].deadBaby = true;
						}

						//babyData[babyNum].maxHunger=baby[babyNum].maxHunger;
						//calculate compared to time converted to ...ticks?

						baby [babyNum].hunger = SaveLoad.data.babyData [babyNum].hunger - (float)(timeElapsed.TotalSeconds / timeRatio);
						//	baby [babyNum].hunger = SaveLoad.data.babyData [babyNum].hunger+System.Convert.ToUInt64(System.DateTime.Now-creationDate);
						//	babyData[babyNum].maxSleepiness=baby[babyNum].maxSleepiness;
					
						baby [babyNum].sleepiness =SaveLoad.data.babyData [babyNum].sleepiness + (float)(timeElapsed.TotalSeconds / timeRatio);
						if (baby [babyNum].sleepiness > baby [babyNum].maxSleepiness) {
								baby [babyNum].sleepiness = baby [babyNum].maxSleepiness;
						}
						baby [babyNum].happiness =SaveLoad.data.babyData [babyNum].happiness - (float)(timeElapsed.TotalSeconds / timeRatio);
						baby [babyNum].poop = SaveLoad.data.babyData [babyNum].poop+(int)(Random.Range(0f,0.1f)*timeElapsed.TotalSeconds / timeRatio);
						baby [babyNum].foodEatenCounter = SaveLoad.data.babyData [babyNum].foodEatenCounter;

						baby [babyNum].diseaseCounter = SaveLoad.data.babyData [babyNum].diseaseCounter;
						if (baby [babyNum].diseaseCounter > 0) {
								//calculate with date and creation
						}
						baby [babyNum].armLeftPart = SaveLoad.data.babyData [babyNum].armLeftPart;
						baby [babyNum].armRightPart = SaveLoad.data.babyData [babyNum].armRightPart;
						baby [babyNum].legLeftPart = SaveLoad.data.babyData [babyNum].legLeftPart;
						baby [babyNum].legRightPart = SaveLoad.data.babyData [babyNum].legRightPart;
						baby [babyNum].headPart = SaveLoad.data.babyData [babyNum].headPart;
						baby [babyNum].torsoPart = SaveLoad.data.babyData [babyNum].torsoPart;

						baby [babyNum].isArmLeftAttached = SaveLoad.data.babyData [babyNum].bArmLeftAttached;
						baby [babyNum].isArmRightAttached = SaveLoad.data.babyData [babyNum].bArmRightAttached;
						baby [babyNum].isLegLeftAttached = SaveLoad.data.babyData [babyNum].bLegLeftAttached;
						baby [babyNum].isLegRightAttached = SaveLoad.data.babyData [babyNum].bLegRightAttached;
						baby [babyNum].isHeadAttached = SaveLoad.data.babyData [babyNum].bHeadAttached;

				}
				/*if (bFirstTimeUser) {
						baby [babyNum].bCat = true;
				}*/
				baby[babyNum].createIdentity(babyName,babyNum,creationDate);


				baby[babyNum].babyObject.transform.parent =govar.transform;


				GameObject babyNamego = new GameObject ("babyNameGUIText " + babyNum);
				babyNameText = babyNamego.AddComponent<GUIText>();
				babyNameText.fontSize = 11;
				babyNameText.font = arialFont;

				babyNameText.transform.position = new Vector3 ((babyNum*100f / Screen.width)+0.25f,0.7f, 0f);

						GameObject babyHealth = new GameObject ("babyHealthGUIText " + babyNum);
				babyHealthText = babyHealth.AddComponent<GUIText> ();
				babyHealthText.fontSize = 11;
				babyHealthText.font = arialFont;
				babyHealthText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.65f, 0f);

						GameObject babyAge = new GameObject ("babyAgeGUIText " + babyNum);
						babyAgeText = babyAge.AddComponent<GUIText> ();
						babyAgeText.fontSize = 11;
						babyAgeText.font = arialFont;
						babyAgeText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.6f, 0f);

						//replace below by progress bar
						GameObject babyHunger = new GameObject ("babyHungerGUIText " + babyNum);
						babyHungerText = babyHunger.AddComponent<GUIText> ();
						babyHungerText.fontSize = 11;
						babyHungerText.font = arialFont;
						babyHungerText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.55f, 0f);

						GameObject babySleepiness = new GameObject ("babySleepinessGUIText " + babyNum);
						babySleepinessText = babySleepiness.AddComponent<GUIText> ();
						babySleepinessText.fontSize = 11;
						babySleepinessText.font = arialFont;
						babySleepinessText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.5f, 0f);

				GameObject babyHappiness = new GameObject ("babyHappinessGUIText " + babyNum);
				babyHappinessText = babyHappiness.AddComponent<GUIText> ();
				babyHappinessText.fontSize = 11;
				babyHappinessText.font = arialFont;
				babyHappinessText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.45f, 0f);

						GameObject babyDisease = new GameObject ("babyDiseaseGUIText " + babyNum);
						babyDiseaseText = babyDisease.AddComponent<GUIText> ();
						babyDiseaseText.fontSize = 11;
						babyDiseaseText.font = arialFont;
						babyDiseaseText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.4f, 0f);

						GameObject babyPoop = new GameObject ("babyPoopGUIText " + babyNum);
					babyPoopText = babyPoop.AddComponent<GUIText> ();
					babyPoopText.fontSize = 11;
					babyPoopText.font = arialFont;
					babyPoopText.transform.position = new Vector3 ((babyNum * 100f / Screen.width) + 0.25f, 0.35f, 0f);
				

				//govar.transform.Translate(cameraPoint.x+Camera.main.pixelWidth/1000+(1.1f*Camera.main.pixelWidth/1000*babyNum),cameraPoint.y*0.55f,HUDinstance.transform.position.z+1f);	

				//govar.transform.Translate(babyIndex+1f,2,0);	
				babyIndex = babyNum;
				setLiveBabyNum(getLiveBabyNum()+1);
				if (babyIndex != 0) {
						baby [0].killBaby ();
				}
				
				showBabiesMainMenu ();
				babyNum++;

			
	}

	public static void createVehicule(float laneX){
		
		GameObject carObject=new GameObject("Car");
		CarController carVehicule = carObject.AddComponent<CarController> ();
		cars.Add(carVehicule);
		cars[carIndex].createIdentity(carIndex);
		cars[carIndex].carObject.transform.parent =carObject.transform;
		cars[carIndex].transform.Translate(laneX,0.93f,PC.transform.position.z+90f);
		
	
	//	cars[carIndex].transform.Translate(laneX,0.93f,cars[carIndex].carObject.transform.position.z);
		carIndex++;
	}
	
	public static void createRoad(){
		
		GameObject roadObject = new GameObject("Road");
		Roads road= roadObject.AddComponent<Roads>();
		roads.Add(road);
		roads[roadIndex].createIdentity();
		//roads[roadIndex].mainRoad.transform.parent =roadObject.transform;
		roadIndex++;
	}


		public static	void createCoinsRow(int numCoins, bool setHigh,float setHeight, GameObject parentObject){
				if (numCoins > 0) {

						int x=0;
						bool[] positionChecker = new bool[lengthPositions.Length];

						while (x != numCoins) {
								objectPosLength [x] =  x*1.5f;

								//	objectPosLength [x] =   lengthPositions [0]-x*1.5f;

								//with pool
								/*	if (coinPoolIndex < coinPool.Length-1) {
										coinPoolIndex++;
								} else {
										coinPoolIndex = 0;
								}

								coinPool[coinPoolIndex].renderer.enabled = true;
								coinPool[coinPoolIndex].collider.enabled = true;
								coinPool[coinPoolIndex].transform.position = parentObject.transform.position;
								coinPool[coinPoolIndex].transform.parent = parentObject.transform;

										//needs adjustments fill positions x/numsCoins

										if (setHigh) {
										coinPool[coinPoolIndex].transform.position += new Vector3(0f,setHeight,0f);
										coinPool[coinPoolIndex].transform.position += new Vector3(0f,0f,objectPosLength [x]);

										} else {
										coinPool[coinPoolIndex].transform.position+= new Vector3(0f,1f,0f);
										coinPool[coinPoolIndex].transform.position += new Vector3(0f,0f,objectPosLength [x]);

										}

										x++;
										
*/

								//without pool

										coinObject = (GameObject)GameObject.Instantiate (Resources.Load ("CollectibleAssets/Coin", typeof(GameObject)));
										coinObject.transform.position = parentObject.transform.position;
										coinObject.transform.parent = parentObject.transform;


										//needs adjustments fill positions x/numsCoins

										if (setHigh) {
												coinObject.transform.position += new Vector3(0f,setHeight,0f);
												coinObject.transform.position += new Vector3(0f,0f,objectPosLength [x]);

										} else {
												coinObject.transform.position+= new Vector3(0f,1f,0f);
												coinObject.transform.position += new Vector3(0f,0f,objectPosLength [x]);

										}
										coinObject.renderer.castShadows = false;
										coinObject.renderer.receiveShadows = false;
										Coin coin = coinObject.AddComponent<Coin> ();
								//	coinObject.transform.parent = coin.transform;
										coin.tag = "Coin";
										coinCollider = coinObject.AddComponent<BoxCollider> ();
										coinCollider.size = new Vector3 (4.2f, 4.2f, 4.2f);
										coinCollider.isTrigger = true;
										x++;

						}
				}

		}

	public static void setGameScene(){
				createRoad ();
				createRoad ();
				stroller.transform.Translate (lanes [2], 0f, 0f);
				stroller.strollerCollisionObject.collider.enabled=true;
				baby [babyIndex].transform.parent = stroller.strollerBabyNode.transform;
				baby [babyIndex].transform.Translate (stroller.strollerBabyNode.transform.position);
				baby [babyIndex].transform.Rotate (new Vector3 (90, 0, 0));
				bRunning = true;
				bPaused = false;
				bGamesceneSet = true;
				saveBabiesToData ();
				bBabyInStroller = true;
				HUDinstance.resetScore();
				stroller.StartRunning ();
				catFacePos=playerCharacterFaceNode.transform.position-stroller.strollerBabyNode.transform.position;
				//print ("1 catFacePos"+catFacePos);

		//		catFacePos=playerCharacterFaceNode.transform.position;
			//	print (playerCharacterFaceNode.transform.localPosition+" = 2 catFacePos = "+catFacePos);

			//	print (baby[babyIndex].transform.localPosition+" = babypos = "+baby[babyIndex].transform.position);

				HUDinstance.alert.signPrevious.guiTexture.enabled = false;
				HUDinstance.alert.signNext.guiTexture.enabled = false;
				HUDinstance.alert.signCurrent.guiTexture.enabled = false;
				HUDinstance.alert.signRunning.guiTexture.enabled = false;

				int i;
				//print(System.DateTime.Now+"baby alert true "+i);
				for (i=0;i<baby.Count;i++){
						print ("baby[i].statusHealth " + baby [i].statusHealth);
						if(baby[i].statusHealth<40
								||!baby[i].isArmLeftAttached
								||!baby[i].isArmRightAttached
								||!baby[i].isLegLeftAttached
								||!baby[i].isLegRightAttached
								||baby[i].happiness<200
								||baby[i].sleepiness<200
								||baby[i].diseaseCounter>1
						){

								HUDinstance.alert.signRunning.guiTexture.enabled = true;

						}
				}



	}
		public static void ResetGameState(){
				if(bPaused)
				{
						Time.timeScale = defTimeScale;
						bPaused = false;
				}
				//coins = 0;
				//food = 0;
				resetObjectPools (true);
				resetGameScene();
		}


		public static void resetObjectPools(bool bResetAll){
				/*	for (int x = 0; x < hugePool; x++) {

						if (coinPoolIndex == -1) {
								coinPoolIndex = 0;
						}
						print ("coinPool [x]" + coinPool [x] + "index" + coinPoolIndex);
						if (bResetAll || coinPool [x].transform.position.z < PC.transform.position.z - 140) {
								coinPool [x].renderer.enabled = false;
								coinPool [x].collider.enabled = false;
								coinPool [x].transform.parent = null;
								coinPool [x].transform.position = new Vector3 (0f, 0f, 0f);
								coinPoolIndex--;

						}
						print ("resetted the pool");

				}*/
				for(int x=0;x<bigPool;x++){
					
						if (barrierPoolIndex == -1) {
								barrierPoolIndex = 0;
						}
						if (bResetAll||barrierPool [x].transform.position.z < PC.transform.position.z - 140){

								barrierPool [x].renderer.enabled = false;
								barrierPool [x].rigidbody.useGravity = false;
								barrierPool [x].rigidbody.isKinematic = true;
								barrierPool [x].collider.enabled = false;
								//	barrierPool [x].transform.position =  new Vector3(-100,-100,-100);
								barrierPoolIndex--;
								}

				}
				/*	for (int x = 0; x < smallPool; x++) {
					
						if (scaffoldPoolIndex == -1) {
								scaffoldPoolIndex = 0;
						}
						if (bResetAll || scaffoldPool [x].transform.position.z < PC.transform.position.z - 140) {
								scaffoldPool [x].renderer.enabled = false;
								scaffoldPool [x].collider.enabled = false;
								scaffoldPool [x].transform.position = new Vector3 (0f, 0f, 0f);
								scaffoldPoolIndex--;
							
						}

				}*/
		}
	public static void resetGameScene(){
				//destroy roads
				resetObjectPools (true);
				for (var x = roadIndex-1; x >= 0; x--) {

						if (roads [x]) {
								roads [x].destroySelf ();
		

						}
				}
				roads.Clear();	
				roadIndex = 0;
	
				//destroy vehicles
				for (var y = carIndex-1; y >= 0; y--) {

						if (cars [y]) {
								cars [y].destroySelf ();
				
						}

				}


				cars.Clear();
				carIndex = 0;
				removeCatFromFace ();
				HUDinstance.deadBabyText.text = "";
				baby [babyIndex].resetBaby ();
				updateAvatarColors ();
				PC.rigidbody.isKinematic = false;
				stroller.bCollisionCrash=false;
				PC.rigidbody.useGravity=true;
				PC.isStatic = true;
				PC.rigidbody.velocity = Vector3.zero;
				PC.rigidbody.angularVelocity= Vector3.zero;
				PC.transform.position=startPosition;
				//	PC.transform.position=Vector3.zero;
				createRoad();
				//resetCamera();
				stroller.resetState();

				setGameScene ();
				saveBabiesToData ();
			


		}
	
		public static void ReturnMainMenu(){
				swapCamera ();
				resetObjectPools (true);
				for (var x = roadIndex-1; x >= 0; x--) {
	
						if (roads [x] != null) {
								roads [x].destroySelf ();
						}
				}
				roads.Clear();	
				roadIndex = 0;

				//destroy vehicles
				for (var y = carIndex-1; y >= 0; y--) {

						if (cars [y] != null) {
								cars [y].destroySelf ();
						}
				}
				cars.Clear();
				carIndex = 0;
				stroller.bCollisionCrash=false;
				HUDinstance.deadBabyText.text = "";

				PC.rigidbody.useGravity=false;
				PC.isStatic = true;
				PC.rigidbody.velocity = Vector3.zero;
				PC.rigidbody.angularVelocity= Vector3.zero;
				PC.rigidbody.isKinematic = true;
				PC.transform.position=startPosition;
				bRunning = false;
				bPaused = true;
				bGamesceneSet = false;

				if(baby[babyIndex].deadBaby){
					lookForLiveBabies();
					if(getLiveBabyNum()>0){
						babyIndex =	getNextBabyIndex(true);

					}else{
						//cat
						babyIndex=0;
					}

				}
				showBabiesMainMenu ();
				saveBabiesToData ();
			
				//baby[babyIndex].transform.Translate(cameraPoint.x+0.5f+(Camera.main.pixelWidth/900*(babyIndex)),cameraPoint.y*0.55f,HUDinstance.transform.position.z+1f);	

		}
		public static void lookForLiveBabies(){
				int tempLiveBaby = 0;
				int x;
				for (x=1; x < baby.Count; x++) {
						if (!baby [x].deadBaby) {
								tempLiveBaby++;
						}
				}
				setLiveBabyNum(tempLiveBaby);
		}
	public static int getPreviousBabyIndex(bool bFirstSearch){
			int x;

		for (x=babyIndex-1; x > 0; x--) {
				if (!baby [x].deadBaby) {
					
					return x;
					
				}
			}
			if(bFirstSearch){
				return getNextBabyIndex(false);
			}
			return babyIndex;
			

		}
	public static int getNextBabyIndex(bool bFirstSearch){
				int x;
				for (x= babyIndex+1; x < baby.Count; x++) {
						if (!baby [x].deadBaby) {
								
								return x;
								
						}
				}
				if(bFirstSearch){
					return getPreviousBabyIndex(false);

				} 
				return babyIndex;
			

		}
		public static void showBabiesMainMenu(){
				bShowMainMenu = true;
				lookForLiveBabies ();
				int tempLivebaby = getLiveBabyNum();
				
				if (tempLivebaby == 0) {
					
						//	if (baby [0].deadBaby){

							baby [0].resetBaby ();					
							babyIndex = 0;
						//}

				} else {
						if (!baby[0].deadBaby){

							baby[0].killBaby ();
							//babyIndex =0;
							//baby [babyIndex].resetBaby ();
			
						}
						baby [babyIndex].resetBaby ();
		
				}


				//tempLivebaby = 0;

				for(var x=0;x<baby.Count;x++){
					//	if (!baby [x].deadBaby) {

								//	if(!baby [x].deadBaby&&x!=0){

								if (baby [x].isArmLeftAttached && baby [x].babyArmLeft != null) {
										baby [x].babyArmLeft.renderer.enabled = false;
								
								}

								if (baby [x].isArmRightAttached && baby [x].babyArmRight != null) {
									baby [x].babyArmRight.renderer.enabled = false;
								
								}
						
								if (baby [x].isLegRightAttached && baby [x].babyLegRight != null) {
										baby [x].babyLegRight.renderer.enabled = false;
									
								}
							
								if (baby [x].isLegLeftAttached && baby [x].babyLegLeft != null) {
										baby [x].babyLegLeft.renderer.enabled = false;
								
								}
			
								if (baby [x].isHeadAttached && baby [x].babyHead != null) {
										baby [x].babyHead.renderer.enabled = false;
								
								}
										
						
								baby [x].babyTorso.renderer.enabled = false;
							

								//baby [x].transform.position= new Vector3(cameraPoint.x+0.6f+(Camera.main.pixelWidth/900),cameraPoint.y*0.55f,HUDinstance.transform.position.z+1f);
								//tempLivebaby++;
						//} else {
						//		print (System.DateTime.Now+" killedbabyx =  " + baby [x]);
							//	baby [x].killBaby ();

					//	}
				}

				baby [babyIndex].resetBaby();
				baby [babyIndex].showRenderer ();

				baby [babyIndex].transform.position = new Vector3 (cameraOrthogonal.camera.transform.position.x, cameraPoint.y * 0.6f, HUDinstance.transform.position.z + 1f);
				
				
				//baby [babyIndex].transform.position = new Vector3 (cameraPoint.x - (Screen.width * 0.003f) + (cameraPerspective.camera.pixelWidth / 900), cameraPoint.y * 0.6f, HUDinstance.transform.position.z + 1f);


				HUDinstance.alert.signPrevious.guiTexture.enabled = false;
				HUDinstance.alert.signNext.guiTexture.enabled = false;
				HUDinstance.alert.signCurrent.guiTexture.enabled = false;

				createSelectionIcons();
		}

		public static void hideBabiesMainMenu(){
				for(var x=0;x<baby.Count;x++){
						if(!baby [x].deadBaby){
								if(baby [x].isArmLeftAttached&&baby [x].babyArmLeft!=null){
										baby [x].babyArmLeft.renderer.enabled = false;
								}
								if (baby [x].isArmRightAttached&&baby [x].babyArmRight!=null) {
										baby [x].babyArmRight.renderer.enabled = false;
								}
								if (baby [x].isLegRightAttached&&baby [x].babyLegRight!=null) {
										baby [x].babyLegRight.renderer.enabled = false;
								}
								if (baby [x].isLegLeftAttached&&baby [x].babyLegLeft!=null) {
										baby [x].babyLegLeft.renderer.enabled = false;
								}
								if (baby [x].isHeadAttached&&baby [x].babyHead!=null) {
										baby [x].babyHead.renderer.enabled = false;
								}
								baby [x].babyArmLeftNode.renderer.enabled = false;
								baby [x].babyArmRightNode.renderer.enabled = false;
								baby [x].babyLegRightNode.renderer.enabled = false;
								baby [x].babyLegLeftNode.renderer.enabled = false;
								baby [x].babyHeadNode.renderer.enabled = false;
								baby [x].babyTorso.renderer.enabled = false;

								//baby [x].transform.position= new Vector3(cameraPoint.x+0.7f+(Camera.main.pixelWidth/900*(liveBabyNum)),cameraPoint.y*0.55f,HUDinstance.transform.position.z+1f);
						}
				}
		}
		public static void babyTombstones(){
				for (var x = 0; x < deadBabyNum; x++) {

						//GameObject tombstoneObject = (GameObject)GameObject.Instantiate (Resources.Load ("InterfaceAssets/Tombstone", typeof(GameObject)));
				
				}

		}

		public static void updateAvatarColors(){

				GameState.HUDinstance.babyAvatar.setAvatarColor("Head", baby[babyIndex].statusHead); 
				GameState.HUDinstance.babyAvatar.setAvatarColor("Torso", baby[babyIndex].statusTorso); 
				GameState.HUDinstance.babyAvatar.setAvatarColor("ArmLeft", baby[babyIndex].statusArmLeft); 
				GameState.HUDinstance.babyAvatar.setAvatarColor("ArmRight", baby[babyIndex].statusArmRight); 
				GameState.HUDinstance.babyAvatar.setAvatarColor("LegLeft", baby[babyIndex].statusLegLeft); 
				GameState.HUDinstance.babyAvatar.setAvatarColor("LegRight", baby[babyIndex].statusLegRight); 
				GameState.HUDinstance.babyAvatar.setAvatarColor("Health", baby[babyIndex].statusHealth); 


		}
		public static void updateBabyStatus(){
				int i;
				//print(System.DateTime.Now+"baby alert true "+i);
				if (bRunning) {
						for (i = 0; i < baby.Count; i++) {
								print ("baby[i].statusHealth " + baby [i].statusHealth);
								if (baby [i].statusHealth < 40
								    || !baby [i].isArmLeftAttached
								    || !baby [i].isArmRightAttached
								    || !baby [i].isLegLeftAttached
								    || !baby [i].isLegRightAttached
								    || baby [i].happiness < 200
								    || baby [i].sleepiness < 200
								    || baby [i].diseaseCounter > 1) {

										HUDinstance.alert.signRunning.guiTexture.enabled = true;

								}
						}
				} else {
						HUDinstance.alert.signRunning.guiTexture.enabled = false;
				}

				updateAvatarColors ();
		}

		public static void saveBabiesToData(){
				for(var x=0;x<baby.Count;x++){
				
						babyData[x].bIsItABoy=baby[x].isItABoy;
						babyData[x].race=baby[x].race;
						babyData[x].bCat=baby[x].isCat;
						babyData[x].timeOfBirth=baby[x].timeOfBirth;
						babyData[x].babyName=baby[x].babyName;
						babyData[x].babyID=baby[x].babyID;

						babyData[x].statusHealth=baby[x].statusHealth;
						babyData[x].statusHead=baby[x].statusHead;
						babyData[x].statusLegLeft=baby[x].statusLegLeft;
						babyData[x].statusLegRight=baby[x].statusLegRight;
						babyData[x].statusArmLeft=baby[x].statusArmLeft;
						babyData[x].statusArmRight=baby[x].statusArmRight;
						babyData[x].statusTorso=baby[x].statusTorso;
						babyData[x].deadBaby=baby[x].deadBaby;
					

						//babyData[x].maxHunger=baby[x].maxHunger;
						babyData[x].hunger=baby[x].hunger;
						//	babyData[x].maxSleepiness=baby[x].maxSleepiness;
						babyData[x].sleepiness=baby[x].sleepiness;
						babyData[x].happiness=baby[x].happiness;
						babyData[x].poop=baby[x].poop;
						babyData[x].foodEatenCounter=baby[x].foodEatenCounter;
						babyData[x].diseaseCounter=baby[x].diseaseCounter;
						babyData[x].armLeftPart=baby[x].armLeftPart;
						babyData[x].armRightPart=baby[x].armRightPart;
						babyData[x].legLeftPart=baby[x].legLeftPart;
						babyData[x].legRightPart=baby[x].legRightPart;
						babyData[x].headPart=baby[x].headPart;
						babyData[x].torsoPart=baby[x].torsoPart;

						babyData [x].bArmLeftAttached=baby [x].isArmLeftAttached;
						babyData [x].bArmRightAttached = baby [x].isArmRightAttached;
						babyData [x].bLegLeftAttached = baby [x].isLegLeftAttached;
						babyData [x].bLegRightAttached = baby [x].isLegRightAttached;
						babyData [x].bHeadAttached = baby [x].isHeadAttached;

				}


				SaveLoad.Save ();
				//	printData ();
		}
	public static void setRoadPosition(Roads road){
		
			road.transform.Translate(0f,0f,roadLength*roadIndex-1);
			//road.transform.Translate(0f,0f,roadLength*roadIndex+["road0"+index].transform.Position.z);

		
	}
	public static void parentThisShit(GameObject go){

		go.transform.parent=roads[roadIndex].gameObject.transform;

	}

	public static void babyDeath(){
	//Destroy.baby;
				deadBabyNum++;
				HUDinstance.deadBabyText.text=baby[babyIndex].babyName+" is Dead!";
	}
	public static void SwapBaby(){
				//public static List<int>  liveBabyIndexList= new List<int>();
			lookForLiveBabies();
			int tempLiveBaby = getLiveBabyNum();
		if(tempLiveBaby>0){
			babyIndex =	getNextBabyIndex(true);
			baby[babyIndex].resetBaby ();
			ResetGameState ();

			return;

		}
										
								
		if (!baby [babyIndex].deadBaby) {
						print ("no other baby available...continue with your live baby");
		}else {
						print ("no baby available...switching for cat");
						baby [0].reviveBaby ();
						ResetGameState ();
		}

	}

		//MAIN MENU *******************
		//************************

	private static void createSelectionIcons(){
	//	SelectionDots.removeDots();

		SelectionDots.createDots();
		
	}

		public static void	createInventory(){
				//		GameObject itemObject = new GameObject("Item");
			
				for(int x=0;x<numItems;x++){
						ItemClass item= new ItemClass();
						itemList.Add (item);
					
						//	print ("createInventory GameState.itemList [x].id" + itemList[x].id);
						GameState.itemList [x].itemId = x;
						GameState.itemList [x].itemName = itemData.itemsName[x];
						GameState.itemList [x].description = itemData.description[x];
						//GameState.itemList [x].itemName = inventoryItemsName[x];
						//need list of gameobject
						//GameState.itemList [x].mesh = GameState.baby [0].babyHead;			
						//itemList [x].description = ;
						//itemList [x].numPossessed = ;
				}
				accessItems ();
		}
		public static void accessItems(){
				//print ("accessitemlist = "+itemList[0].);

				//	print ("createInventory GameState.itemList [x].id" + itemList[0].);



		}
		public static void showItemsMainMenu(){
				if (itemsGo.Count == 0) {

						for (var x = 0; x < numItems; x++) {
								GameObject buyableItem;
								print("itemData.itemsClassName[x]+/+itemData.itemsObjectName[x] ====  "+ itemData.itemsClassName[x]+"/"+itemData.itemsObjectName[x]);
								//	if (itemData.itemsClassName [x]=="Baby"||itemData.itemsClassName [x]=="Cat") {
								buyableItem = (GameObject)GameObject.Instantiate (Resources.Load (itemData.itemsClassName[x]+"/"+itemData.itemsObjectName[x], typeof(GameObject)));
								itemsGo.Add (buyableItem);
								itemsGo [x].transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
			 	itemsGo [x].layer= LayerMask.NameToLayer("UI");
								//	}

				if( itemData.itemsGroupName[x] =="Collectible"){
					itemsGo [x].transform.localPosition = new Vector3 ((cameraOrthogonal.transform.position.x - cameraOrthogonal.camera.pixelWidth*0.001f + cameraOrthogonal.camera.pixelWidth *0.0005f* (x)), cameraOrthogonal.camera.pixelHeight *0.0054f, HUDinstance.transform.position.z + 1f);


				}else{

					 
						itemsGo [x].transform.localPosition = new Vector3 ((cameraOrthogonal.transform.position.x - cameraOrthogonal.camera.pixelWidth*0.0005f + cameraOrthogonal.camera.pixelWidth *0.0005f* (-2+x)), cameraOrthogonal.camera.pixelHeight *0.005f, HUDinstance.transform.position.z + 1f);
						
						

				}
								//itemsGo [x].transform.position = new Vector3 ((cameraOrthogonal.camera.pixelWidth *0.0005f * (x))-cameraOrthogonal.camera.pixelWidth *0.0043f, cameraOrthogonal.camera.pixelHeight *0.005f, HUDinstance.transform.position.z + 1f);
								//	itemsGo [x].transform.position = new Vector3 ((cameraOrthogonal.transform.position.x-1f+0.4f * (x)), cameraOrthogonal.transform.position.y-0.2f, HUDinstance.transform.position.z + 1f);

								print (itemsGo [x].transform.position +" cam pos = "+ cameraOrthogonal.transform.position);
								//itemsGo [x].transform.position = new Vector3 ((Camera.main.pixelWidth *0.0015f * (x))-Camera.main.pixelWidth *0.004f, Camera.main.pixelHeight *0.005f, HUDinstance.transform.position.z + 1f);

						}
				} else {

						for (var x = 0; x < numItems; x++) {
								itemsGo [x].gameObject.renderer.enabled = true;
						}
				}

		}
		public static void hideItemsMainMenu(){
			
				for(var x=0;x<numItems;x++){

						itemsGo [x].gameObject.renderer.enabled = false;

				}

			
		}
	/*	public  void playMenuMusic(AudioClip MenuMusic){
			//	MenuMusic = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Music/music_menu", typeof(AudioClip)));
				gameObject.audio.clip = MenuMusic;
				gameObject.audio.Play ();
		}
	
*/

}
