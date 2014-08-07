using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Roads : MonoBehaviour
{
		//positioning
		private	int currentPosRange=0;
		private	int posRange=0;
		private	int maxPosRange=0;
		private int numPosition = 0;
		private Vector3 walkwayPosLeft = new Vector3 (-11.8f,0f,0f);
		private Vector3  walkwayPosRight = new Vector3 (0f,0f,0f);
		private Vector3  walkwayCurvedPosLeft = new Vector3 (1.47f,0f,0f);
		private Vector3 roadSideQuarterPosLeft1 = new Vector3 (-34.5f,0f,0f);
		private Vector3 roadSideLeftPos = new Vector3 (-35f,0f,0f);
		private Vector3  roadSideRightPos =  new Vector3 (0f,0f,0f);
		private Vector3  streetCenterPos = new Vector3 (0f,0f,0f);
		private Vector3  streetSideRightPos = new Vector3 (0f,0f,0f);
		private Vector3 streetSidePosLeft =  new Vector3 (-32.6f,0f,0f);
		private Texture streetTexture, streetSideTexture, walkwayStraightTexture,walkwayCurvedTexture,roadSideGrassTexture, roadSideQuarterTexture;
		private bool bCurvedLeft=false;
		private bool bCurvedRight=false;
		//private bool bCurvedRight=false;


		//roads gameobject
		public GameObject walkwayStraightLeft, walkwayStraightRight, walkwayCurvedRight, walkwayCurvedLeft,  streetCenter, streetSideRight, streetSideLeft, roadSideLeft, roadSideRight, roadSideQuarterRight1, roadSideQuarterRight2, roadSideQuarterLeft1, roadSideQuarterLeft2, mainRoad;

	

		//private int scaffoldLengthStartEnd =1;
		//	private int scaffoldLengthMiddle =2;
		private float scaffoldHeight=5.3f;
		//assets GameObject
		public GameObject stopPost, lampPost, signPost, fireHydrant, barrier, buildingCube, foodStand,scaffold,  scaffoldStart, scaffoldEnd;
		public MeshCollider stopPostCollider, lampPostCollider, signPostCollider, fireHydrantCollider, barrierCollider,  foodStandCollider, scaffoldStartCollider, scaffoldEndCollider;




		private bool[] occupiedObjectPosLeft = new bool[GameState.lengthPositions.Length];
		private bool[] occupiedObjectPosRight = new bool[GameState.lengthPositions.Length];

	
	//collectibles
	public GameObject coinObject, foodObject, boosterObject;
	public BoxCollider coinCollider, foodCollider, boosterCollider;

	public MeshCollider  roadSideColliderLeft,roadSideColliderRight, walkwayStraightColliderLeft,walkwayStraightColliderRight;
	public BoxCollider streetCenterCollider;

	void Start ()
	{
				StartCoroutine(statusUpdate(1.0F));
				for(var i=0;i<GameState.lengthPositions.Length;i++)
				{		occupiedObjectPosLeft[i]=false;
						occupiedObjectPosRight[i]=false;
				}


		
	}
	
	public void createIdentity(){
				int roadType = Random.Range (0, 3);
				switch (roadType) {
				case 0: 
				
						createStraightGrassRoad ();
						break;
				case 1:
						createCurvedRightGrassRoad ();
						break;
				case 2:
						createCurvedLeftGrassRoad ();
						break;
				}

				createBooster(Random.Range(0,10)-8);
				createCoins(Random.Range(2,8));
				createFood(Random.Range(0,3),0);
				createFood(Random.Range(0,3),1);
				createBarrier(Random.Range (0, 7) - 3);
				createLampPost(Random.Range (0, 3), false);
				createLampPost(Random.Range (0, 3), true);
				createFireHydrant(Random.Range (0, 3)-1, false);
				createFireHydrant(Random.Range (0, 3)-1, true);
				createSignPost(Random.Range (0, 3)-2, false);
				createSignPost(Random.Range (0, 3)-2, true);
				createBuilding(Random.Range (2, 5), true);
				createBuilding(Random.Range (2, 5), false);
				createScaffold(Random.Range (0, 6)-4, true);
				createScaffold(Random.Range (0, 6)-4, false);
				tag="Ground";

	}
	
	public void createStraightGrassRoad(){
		bCurvedLeft = false;
		mainRoad = (GameObject) Instantiate(Resources.Load("RoadParts/street_center", typeof(GameObject)));
				mainRoad.layer = GameState.safeCollideLayer;

		streetCenter =GameObject.Find("street_straight");
		streetCenter.name="street_center";
		streetTexture = Resources.Load("RoadParts/Textures/street_straight") as Texture;
		streetCenter.renderer.material.mainTexture = streetTexture;

	//	streetCenter.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.wrapMode = TextureWrapMode.Clamp;
		
		roadSideLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side", typeof(GameObject)));
		roadSideLeft.transform.parent= mainRoad.transform;
		roadSideGrassTexture = Resources.Load("RoadParts/Textures/grass_side") as Texture;
		roadSideLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = roadSideGrassTexture;
	//	roadSideLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.filterMode = FilterMode.Point;
	//	roadSideLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.wrapMode = TextureWrapMode.Clamp;
		//roadSideLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.mipMapBias = 0.5f;
		
	 	roadSideRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side", typeof(GameObject)));
		roadSideRight.transform.parent= mainRoad.transform;
		roadSideRight.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = roadSideGrassTexture;
		
		
		walkwayStraightLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_straight", typeof(GameObject)));
		walkwayStraightLeft.transform.parent= mainRoad.transform;
		walkwayStraightTexture = Resources.Load("RoadParts/Textures/walkway_straight") as Texture;
		walkwayStraightLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = walkwayStraightTexture;
	 	
		walkwayStraightRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_straight", typeof(GameObject)));
		walkwayStraightRight.transform.parent= mainRoad.transform;
		walkwayStraightRight.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = walkwayStraightTexture;
		
		//hugecollision?
		streetCenterCollider= mainRoad.AddComponent<BoxCollider>();
		streetCenterCollider.size= new Vector3(500,999,0);
	
		
		walkwayStraightLeft.transform.Translate(walkwayPosLeft);
		roadSideLeft.transform.Translate(roadSideLeftPos);
			
		GameState.parentThisShit(mainRoad);
		GameState.setRoadPosition(this);


	}
		public void createCurvedRightGrassRoad(){
				bCurvedRight = true;
				mainRoad = (GameObject) Instantiate(Resources.Load("RoadParts/street_center", typeof(GameObject)));

				streetCenter =GameObject.Find("street_straight");
				streetCenter.name="street_center";
				streetTexture = Resources.Load("RoadParts/Textures/street_straight") as Texture;
				streetCenter.renderer.material.mainTexture = streetTexture;

				streetSideRight = (GameObject) Instantiate(Resources.Load("RoadParts/street_side", typeof(GameObject)));
				streetSideRight.transform.parent= mainRoad.transform;
				streetSideTexture = Resources.Load("RoadParts/Textures/street_side") as Texture;
				streetSideRight.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = streetSideTexture;

				roadSideLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side", typeof(GameObject)));
				roadSideLeft.transform.parent= mainRoad.transform;
				roadSideGrassTexture = Resources.Load("RoadParts/Textures/grass_side") as Texture;
				roadSideLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = roadSideGrassTexture;

				//fix name material in 3ds max
				roadSideQuarterRight1 = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side_quarter", typeof(GameObject)));
				roadSideQuarterRight1.transform.parent= mainRoad.transform;
				roadSideQuarterTexture = Resources.Load("RoadParts/Textures/grass_corner") as Texture;
				roadSideQuarterRight1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = roadSideQuarterTexture;
				roadSideQuarterRight1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.wrapMode = TextureWrapMode.Clamp;
				roadSideQuarterRight1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.filterMode = FilterMode.Point;
				roadSideQuarterRight1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.mipMapBias = 0.5f;

				walkwayStraightLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_straight", typeof(GameObject)));
				walkwayStraightLeft.transform.parent= mainRoad.transform;
				walkwayStraightTexture = Resources.Load("RoadParts/Textures/walkway_straight") as Texture;
				walkwayStraightLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = walkwayStraightTexture;

				walkwayCurvedRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_curved", typeof(GameObject)));
				walkwayCurvedRight.transform.parent= mainRoad.transform;
				walkwayCurvedTexture = Resources.Load("RoadParts/Textures/walkway_curved02") as Texture;
				walkwayCurvedRight.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = walkwayCurvedTexture;

				//hugecollision?
				streetCenterCollider= mainRoad.AddComponent<BoxCollider>();
				streetCenterCollider.size= new Vector3(500,999,0);

				walkwayStraightLeft.transform.Translate(walkwayPosLeft);
				roadSideLeft.transform.Translate(roadSideLeftPos);
				createStopPost(false);
				//	walkwayStraightLeft.transform.Translate(walkwayPosLeft);
				//roadSideLeft.transform.Translate(roadSideLeftPos);

				GameState.parentThisShit(mainRoad);
				GameState.setRoadPosition(this);
				occupiedObjectPosRight [0] = true;
		}

		public void createCurvedLeftGrassRoad(){
				bCurvedLeft = true;
				mainRoad = (GameObject) Instantiate(Resources.Load("RoadParts/street_center", typeof(GameObject)));

				streetCenter =GameObject.Find("street_straight");
				streetCenter.name="street_center";
				streetTexture = Resources.Load("RoadParts/Textures/street_straight") as Texture;
				streetCenter.renderer.material.mainTexture = streetTexture;

				streetSideLeft = (GameObject) Instantiate(Resources.Load("RoadParts/street_side", typeof(GameObject)));
				streetSideLeft.transform.parent= mainRoad.transform;
				streetSideTexture = Resources.Load("RoadParts/Textures/street_side") as Texture;
				streetSideLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = streetSideTexture;

				roadSideRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side", typeof(GameObject)));
				roadSideRight.transform.parent= mainRoad.transform;
				roadSideGrassTexture = Resources.Load("RoadParts/Textures/grass_side") as Texture;
				roadSideRight.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = roadSideGrassTexture;

				//fix name material in 3ds max
				roadSideQuarterLeft1 = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side_quarter", typeof(GameObject)));
				roadSideQuarterLeft1.transform.parent= mainRoad.transform;
				roadSideQuarterTexture = Resources.Load("RoadParts/Textures/grass_corner") as Texture;
				roadSideQuarterLeft1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = roadSideQuarterTexture;
				roadSideQuarterLeft1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.wrapMode = TextureWrapMode.Clamp;
				roadSideQuarterLeft1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.filterMode = FilterMode.Point;
				roadSideQuarterLeft1.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture.mipMapBias = 0.5f;

				walkwayStraightRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_straight", typeof(GameObject)));
				walkwayStraightRight.transform.parent= mainRoad.transform;
				walkwayStraightTexture = Resources.Load("RoadParts/Textures/walkway_straight") as Texture;
				walkwayStraightRight.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = walkwayStraightTexture;

				walkwayCurvedLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_curved", typeof(GameObject)));
				walkwayCurvedLeft.transform.parent= mainRoad.transform;
				walkwayCurvedTexture = Resources.Load("RoadParts/Textures/walkway_curved02") as Texture;
				walkwayCurvedLeft.GetComponentInChildren<MeshFilter>().renderer.material.mainTexture = walkwayCurvedTexture;

				//hugecollision?
				streetCenterCollider= mainRoad.AddComponent<BoxCollider>();
				streetCenterCollider.size= new Vector3(500,999,0);
				streetSideLeft.transform.Translate(streetSidePosLeft);
				roadSideQuarterLeft1.transform.Translate(roadSideQuarterPosLeft1);
				walkwayCurvedLeft.transform.Rotate(0f,0f,-180f);
				walkwayCurvedLeft.transform.Translate(walkwayCurvedPosLeft);
				createStopPost(true);
				//	walkwayStraightLeft.transform.Translate(walkwayPosLeft);
				//roadSideLeft.transform.Translate(roadSideLeftPos);

				GameState.parentThisShit(mainRoad);
				GameState.setRoadPosition(this);
				occupiedObjectPosLeft [0] = true;
		}
	
	void createBooster(int numAssets){
		
		if (numAssets > 0) {
			int x = 0;
			float chosenLane;
						maxPosRange = posRange = (GameState.lengthPositions.Length / numAssets);
			currentPosRange = 0;
			numPosition = 0;
						bool[] positionChecker = new bool[GameState.lengthPositions.Length];

			while (x != numAssets) {
					numPosition = Random.Range (currentPosRange, maxPosRange);
					chosenLane = GameState.lanes [Random.Range (0, 3)];
					GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];
 					boosterObject = (GameObject)GameObject.Instantiate (Resources.Load ("CollectibleAssets/BoosterSpeed", typeof(GameObject)));
					boosterObject.transform.parent = mainRoad.transform;
					//needs adjustments fill positions x/numsCoins
					
					boosterObject.transform.Translate (chosenLane, GameState.objectPosLength [x]  - this.transform.position.z - GameState.roadLength / 2 + 3f, 1f);
					boosterObject.renderer.castShadows = false;
					boosterObject.renderer.receiveShadows = false;
					BoosterSpeed booster = boosterObject.AddComponent<BoosterSpeed> ();
					boosterObject.transform.parent = booster.transform;
					booster.tag = "BoosterSpeed";
								boosterCollider = boosterObject.AddComponent<BoxCollider> ();
					boosterCollider.size = new Vector3 (4.2f, 4.2f, 4.2f);
					boosterCollider.isTrigger = true;
					positionChecker [numPosition] = true;
					x++;
					
 			}
			
		}
	}
		void createCoins(int numCoins){
				if (numCoins > 0) {

						int x=0;
						float chosenLane;
						 numPosition = 0;
						bool[] positionChecker = new bool[GameState.lengthPositions.Length];

						for (var i = 0; i < GameState.lengthPositions.Length; i++) {
								positionChecker [i] = false;
						}
				
						while (x != numCoins) {
							
										numPosition = Random.Range (0, GameState.lengthPositions.Length - 1);
										chosenLane = GameState.lanes [Random.Range (0, 3)];
								GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];
			
								if (positionChecker [numPosition] == false) {
										//with pool
										/*
										if (GameState.coinPoolIndex < GameState.coinPool.Length-1) {
												GameState.coinPoolIndex++;
										} else {
												GameState.coinPoolIndex = 0;
										}


										GameState.coinPool[GameState.coinPoolIndex].renderer.enabled = true;
										GameState.coinPool[GameState.coinPoolIndex].collider.enabled = true;
										GameState.coinPool[GameState.coinPoolIndex].transform.Translate ( chosenLane ,GameState.objectPosLength [x]  - this.transform.position.z - GameState.roadLength / 2 + 3f, 1f);
										positionChecker [numPosition] = true;
										x++;*/
										//without pool
									

										coinObject = (GameObject)GameObject.Instantiate (Resources.Load ("CollectibleAssets/Coin", typeof(GameObject)));
										coinObject.transform.parent = mainRoad.transform;
										//needs adjustments fill positions x/numsCoins
									
										coinObject.transform.Translate (chosenLane, GameState.objectPosLength [x]  - this.transform.position.z - GameState.roadLength / 2 + 3f, 1f);
										coinObject.renderer.castShadows = false;
										coinObject.renderer.receiveShadows = false;
										Coin coin = coinObject.AddComponent<Coin> ();
										coinObject.transform.parent = coin.transform;
										coin.tag = "Coin";
										coinCollider = coinObject.AddComponent<BoxCollider> ();
										coinCollider.size = new Vector3 (4.2f, 4.2f, 4.2f);
										coinCollider.isTrigger = true;
										positionChecker [numPosition] = true;
										x++;
								}
						}
				}

	}




	void createFood(int numFood, int caseFood){

				if (numFood > 0) {
						int typeFood;

						int x=0;
						 numPosition = 0;
						bool[] positionChecker = new bool[GameState.lengthPositions.Length];
						for(var i=0;i<GameState.lengthPositions.Length;i++)
						{
								positionChecker[i]=false;
						}

						while (x != numFood) {
								numPosition = Random.Range (0, GameState.lengthPositions.Length - 1);

								if (positionChecker [numPosition] == false) {
										GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];
										if (caseFood == 0)
												typeFood = Random.Range (0, 2);
										else
												typeFood = caseFood;

		
										switch (typeFood) {
										case 0:
												foodObject = (GameObject)GameObject.Instantiate (Resources.Load ("CollectibleAssets/HotDog", typeof(GameObject)));
												break;
					
										case 1:
												foodObject = (GameObject)GameObject.Instantiate (Resources.Load ("CollectibleAssets/BabyFood", typeof(GameObject)));
												break;
										}
										foodObject.transform.parent = mainRoad.transform;
										//needs adjustments fill positions x/numsCoins
										foodObject.transform.Translate (GameState.lanes[Random.Range(0,3)], GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2, 1f);
										Food food = foodObject.AddComponent<Food> ();
										foodObject.transform.parent = food.transform;
										food.tag = "Food";
										foodObject.renderer.castShadows = false;
										foodObject.renderer.receiveShadows = false;
										foodCollider = foodObject.AddComponent<BoxCollider> ();
										foodCollider.size = new Vector3 (4.2f, 4.2f, 4.2f);
										foodCollider.isTrigger = true;
										positionChecker [numPosition] = true;
										x++;
								}
						}
				}
	}

		void createBarrier(int numBarriers){

				if (numBarriers > 0) {
						int x = 0;
						int randomizedLane;
						maxPosRange = posRange = (GameState.lengthPositions.Length / numBarriers);
						currentPosRange = 0;
						numPosition = 0;
						while (x != numBarriers) {
								numPosition = Random.Range (currentPosRange, maxPosRange);
								randomizedLane = Random.Range (0, 3);
								if ((randomizedLane==0 && !occupiedObjectPosLeft [x]) || (randomizedLane==3 && !occupiedObjectPosRight [x])||randomizedLane==2||randomizedLane==1) {
										GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];
										//pool version
										if (GameState.barrierPoolIndex < GameState.barrierPool.Length-1) {
												GameState.barrierPoolIndex++;
										} else {
												GameState.barrierPoolIndex = 0;
										}
										//	GameState.barrierPool[GameState.barrierPoolIndex].transform.parent = mainRoad.transform;
										//		GameState.barrierPool [GameState.barrierPoolIndex].transform.position = Vector3.zero;
										//GameState.barrierPool [GameState.barrierPoolIndex].transform.localPosition = Vector3.zero;
										GameState.barrierPool [GameState.barrierPoolIndex].transform.position = Vector3.zero;
										GameState.barrierPool[GameState.barrierPoolIndex].transform.Translate (GameState.lanes [randomizedLane], GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2, 1f);
										GameState.barrierPool[GameState.barrierPoolIndex].rigidbody.useGravity = true;
										GameState.barrierPool[GameState.barrierPoolIndex].rigidbody.isKinematic = false;
										GameState.barrierPool[GameState.barrierPoolIndex].rigidbody.mass = 0.8f;
										GameState.barrierPool [GameState.barrierPoolIndex].renderer.enabled = true;
										GameState.barrierPool [GameState.barrierPoolIndex].collider.enabled = true;
										currentPosRange = maxPosRange;
										maxPosRange += posRange;	
										x++;
										//non-pool version
										/*	barrier = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/WoodBarrier", typeof(GameObject)));
										barrier.transform.parent = mainRoad.transform;
										barrier.transform.Translate (GameState.lanes [randomizedLane], GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2, 1f);
										barrierCollider = barrier.gameObject.AddComponent<MeshCollider> ();
										barrierCollider.sharedMesh = barrier.GetComponentInChildren<MeshFilter> ().sharedMesh;
										barrier.AddComponent<Rigidbody> ();
										barrier.rigidbody.useGravity = true;
										barrier.rigidbody.mass = 0.8f;
										currentPosRange = maxPosRange;
										maxPosRange += posRange;	
										x++;*/

								}
						}
				
				}
		}
		//create a more dynamic distance
		void createLampPost(int numLampPosts, bool bObjectIsFlipped){

				if (numLampPosts > 0) {
						int x = 0;
						float objectPos;
						resetPositionRange (numLampPosts, bObjectIsFlipped);
						while (x != numLampPosts) {

								numPosition = Random.Range (currentPosRange, maxPosRange);

								if ((bObjectIsFlipped && !occupiedObjectPosLeft [numPosition]) || (!bObjectIsFlipped && !occupiedObjectPosRight [numPosition])) {
										GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];

										lampPost = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/LampPost", typeof(GameObject)));
										lampPost.transform.parent = mainRoad.transform;

										if (Random.Range (0, 2) == 0) {
												objectPos = GameState.lanes [0];
												bObjectIsFlipped = false;
											
										}
										else {
												objectPos = GameState.lanes [3];
												bObjectIsFlipped = true;
											
										}

										//		lampPost.transform.Translate(objectPos,Random.Range(0,GameState.roadLength)-this.transform.position.z-GameState.roadLength/2,0f);
										lampPost.transform.Translate (objectPos, GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2, 0f);

										lampPostCollider = lampPost.gameObject.AddComponent<MeshCollider> ();
										lampPostCollider.sharedMesh = lampPost.GetComponentInChildren<MeshFilter> ().sharedMesh;

										if (bObjectIsFlipped) {
												lampPost.transform.Rotate (transform.forward * 180);
								
											
										}
										currentPosRange = maxPosRange;
										maxPosRange += posRange;	
										x++;
								}
						}

				}

		}
		//create a more dynamic distance
		void createStopPost(bool bObjectIsFlipped){

				bool bFacingTraffic=false;
				if (Random.Range (0, 2) != 0) {
						bFacingTraffic = true;
				} 

				stopPost = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/StopPost", typeof(GameObject)));
				stopPost.transform.parent = mainRoad.transform;

				stopPostCollider = stopPost.gameObject.AddComponent<MeshCollider> ();
				stopPostCollider.sharedMesh = stopPost.GetComponentInChildren<MeshFilter> ().sharedMesh;

				if (bObjectIsFlipped) {
						occupiedObjectPosLeft [0] = true;
						if (bFacingTraffic) {
								stopPost.transform.Translate (GameState.lanes [0], GameState.objectPosLength [0] - this.transform.position.z - GameState.roadLength / 2, 0f);

								stopPost.transform.Rotate (transform.forward * 180);

						} else {
								stopPost.transform.Translate (GameState.lanes [0], GameState.objectPosLength [0] - this.transform.position.z - GameState.roadLength / 2+17f, 0f);

								stopPost.transform.Rotate (transform.forward * 90);

						}
						bObjectIsFlipped = false;
				} else {
						occupiedObjectPosRight [0] = true;
						if (bFacingTraffic) {
								stopPost.transform.Translate (GameState.lanes [3], GameState.objectPosLength [0] - this.transform.position.z - GameState.roadLength / 2+17f, 0f);
						} else {
								stopPost.transform.Translate (GameState.lanes [3], GameState.objectPosLength [0] - this.transform.position.z - GameState.roadLength / 2, 0f);

								stopPost.transform.Rotate (transform.forward * 270);
						}
				}

		}

		void createFireHydrant(int numFireHydrant, bool bObjectIsFlipped){

				if (numFireHydrant > 0) {
						int x = 0;
						resetPositionRange (numFireHydrant, bObjectIsFlipped);
			
						while (x != numFireHydrant) {
										numPosition = Random.Range (currentPosRange, maxPosRange);
								if ((bObjectIsFlipped && !occupiedObjectPosLeft [numPosition]) || (!bObjectIsFlipped && !occupiedObjectPosRight [numPosition])) {
												
										GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];

										fireHydrant = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/FireHydrant", typeof(GameObject)));

										fireHydrant.transform.parent = mainRoad.transform;
										fireHydrantCollider = fireHydrant.gameObject.AddComponent<MeshCollider> ();
										fireHydrantCollider.sharedMesh = fireHydrant.GetComponentInChildren<MeshFilter> ().sharedMesh;
									
									
										if (bObjectIsFlipped) {
												fireHydrant.transform.Translate (GameState.lanes [3], GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2 + 6f, 0f);

												fireHydrant.transform.Rotate (transform.forward * 180);

										} else {
												fireHydrant.transform.Translate (GameState.lanes [0], GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2 + 6f, 0f);

										}
										currentPosRange = maxPosRange;
										maxPosRange += posRange;	
										x++;

								}
						}
				}

		}

		void createSignPost(int numSignPost, bool bObjectIsFlipped){

				if (numSignPost > 0) {
						int x = 0;
						resetPositionRange (numSignPost, bObjectIsFlipped);
						while (x != numSignPost) {
									numPosition = Random.Range (currentPosRange, maxPosRange);
								if ((bObjectIsFlipped && !occupiedObjectPosLeft [numPosition]) || (!bObjectIsFlipped && !occupiedObjectPosRight [numPosition])) {
											
										GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];

										signPost = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/SignPost", typeof(GameObject)));
										signPost.transform.parent = mainRoad.transform;

										signPostCollider = signPost.gameObject.AddComponent<MeshCollider> ();
										signPostCollider.sharedMesh = signPost.GetComponentInChildren<MeshFilter> ().sharedMesh;

										if (bObjectIsFlipped) {
												signPost.transform.Translate (GameState.lanes [3] + 0.6f, GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2 - 6f, 0f);
												signPost.transform.Rotate (transform.forward * 180);
										} else {
												signPost.transform.Translate (GameState.lanes [0], GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2 - 6f, 0f);
									
										}
										currentPosRange = maxPosRange;
										maxPosRange += posRange;	
										x++;
								}
						}

				}

		}


		void createBuilding(int numBuilding, bool bObjectIsFlipped){

				if (numBuilding > 0) {
						int x = 0;
						int buildingType;
						resetPositionRange (numBuilding, bObjectIsFlipped);
						while (x != numBuilding) {
								buildingType = Random.Range (0, 3);
								numPosition = Random.Range (currentPosRange, maxPosRange);
								GameState.objectPosLength [x] = GameState.lengthPositions [numPosition];
						
								switch (buildingType) {
								case 0:
										buildingCube = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/BuildingCubeLow", typeof(GameObject)));
										break;
								case 1:
										buildingCube = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/BuildingCubeMedium", typeof(GameObject)));
										break;
								case 2:
										buildingCube = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/BuildingCubeHigh", typeof(GameObject)));
										break;

								}

								buildingCube.transform.parent = mainRoad.transform;
								if (bObjectIsFlipped) {
								buildingCube.transform.Translate (GameState.lanes [0] - 10f, GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2, 0f);
								} else {
								buildingCube.transform.Translate (GameState.lanes [3] + 10f, GameState.objectPosLength [x] - this.transform.position.z - GameState.roadLength / 2, 0f);
									buildingCube.transform.Rotate (0f, 0f, 180f);
								}

								buildingCube.name = "building" + Random.Range (0, 10000);
								currentPosRange = maxPosRange;
								maxPosRange += posRange;	
								x++;
						}
				}
		}

		void createScaffold(int numAsset, bool bObjectIsFlipped){
				if (numAsset > 0) {
						int x = 0;
						//	int totalScaffoldLength;
						float scaffoldPosition;
						int ScaffoldLength=0;
						//int ScaffoldLength=Random.Range(1,3);
						//without pool
						//	scaffold = new GameObject();
					
						resetPositionRange (numAsset, bObjectIsFlipped);
						numPosition = Random.Range (currentPosRange, maxPosRange);
						//with pool
						/*if (GameState.scaffoldPoolIndex < GameState.scaffoldPool.Length-1) {
								GameState.scaffoldPoolIndex++;
						} else {
								GameState.scaffoldPoolIndex = 0;
						}


	
						GameState.scaffoldPool[GameState.scaffoldPoolIndex].renderer.enabled = true;
						GameState.scaffoldPool[GameState.scaffoldPoolIndex].collider.enabled = true;

						scaffoldPosition = GameState.lengthPositions [numPosition];

						if (bObjectIsFlipped) {
								GameState.scaffoldPool[GameState.scaffoldPoolIndex].transform.Translate (GameState.lanes [0],  -scaffoldPosition -this.transform.position.z,0f );
								occupiedObjectPosLeft [x] = true;
								GameState.createCoinsRow(Random.Range(3,7+ScaffoldLength), true, scaffoldHeight, GameState.scaffoldPool[GameState.scaffoldPoolIndex] );
								//	scaffold.transform.Translate (GameState.lanes [0] - 10f,  GameState.lengthPositions [numPosition]- this.transform.position.z - GameState.roadLength / 2, 0f);
						} else {
								GameState.scaffoldPool[GameState.scaffoldPoolIndex].transform.Translate (GameState.lanes [3],  -scaffoldPosition- this.transform.position.z,0f);
								occupiedObjectPosRight [x] = true;
								GameState.createCoinsRow(Random.Range(3,7+ScaffoldLength), true, scaffoldHeight, GameState.scaffoldPool[GameState.scaffoldPoolIndex] );
								//scaffold.transform.Translate (GameState.lanes [3] + 10f,  GameState.lengthPositions [numPosition] - this.transform.position.z - GameState.roadLength / 2, 0f);

						}
*/
						//without pool
						scaffold = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/ScaffoldCenter", typeof(GameObject)));
						//	scaffold.transform.Translate (0f, -16.65f, 0f);
						scaffold.transform.parent = scaffold.transform;
						scaffold.gameObject.AddComponent<MeshCollider> ().sharedMesh = scaffold.GetComponentInChildren<MeshFilter> ().sharedMesh;

						scaffoldStart = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/ScaffoldStart", typeof(GameObject)));
						scaffoldStart.transform.parent = scaffold.transform;
						scaffoldStartCollider = scaffoldStart.gameObject.AddComponent<MeshCollider> ();
						scaffoldStartCollider.sharedMesh = scaffoldStart.GetComponentInChildren<MeshFilter> ().sharedMesh;
						//totalScaffoldLength = scaffoldLengthStartEnd + scaffoldLengthMiddle * ScaffoldLength;

					
								

					
						scaffoldEnd = (GameObject)GameObject.Instantiate (Resources.Load ("RoadAssets/ScaffoldEnd", typeof(GameObject)));
						scaffoldEnd.transform.Translate (0f, -scaffold.transform.position.z, 0f);
						scaffoldEndCollider = scaffoldEnd.gameObject.AddComponent<MeshCollider> ();
						scaffoldEndCollider.sharedMesh = scaffoldEnd.GetComponentInChildren<MeshFilter> ().sharedMesh;

						scaffoldEnd.transform.parent = scaffold.transform;
						scaffold.transform.parent = mainRoad.transform;
						scaffoldPosition = GameState.lengthPositions [numPosition];


						if (bObjectIsFlipped) {
								scaffold.transform.Translate (GameState.lanes [0] , scaffoldPosition - this.transform.position.z,0f);
								occupiedObjectPosLeft [x] = true;
								GameState.createCoinsRow(Random.Range(3,7+ScaffoldLength), true, scaffoldHeight, scaffold );
								//	scaffold.transform.Translate (GameState.lanes [0] - 10f,  GameState.lengthPositions [numPosition]- this.transform.position.z - GameState.roadLength / 2, 0f);
						} else {
								scaffold.transform.Translate (GameState.lanes [3], scaffoldPosition- this.transform.position.z, 0f   );
								occupiedObjectPosRight [x] = true;
								GameState.createCoinsRow(Random.Range(3,7+ScaffoldLength), true, scaffoldHeight, scaffold );
								//scaffold.transform.Translate (GameState.lanes [3] + 10f,  GameState.lengthPositions [numPosition] - this.transform.position.z - GameState.roadLength / 2, 0f);

						}

				}


		}

		void resetPositionRange(int numAsset, bool bObjectIsFlipped){

				//need to reset maxPosRange
				maxPosRange = 0;

				if (bCurvedLeft && bObjectIsFlipped) {
					
						posRange = ((GameState.lengthPositions.Length-3) / (numAsset));
						//	posRange =2;
						maxPosRange = 3 + posRange;
						currentPosRange = 3;
						//			print ("***maxPosRange*** " + maxPosRange + " | ***posRange*** " + posRange);

				} else if (bCurvedRight && !bObjectIsFlipped) {
					posRange = ((GameState.lengthPositions.Length-3) / (numAsset));
						//	posRange =2;
						maxPosRange = 3 + posRange;
						currentPosRange = 3;
					
				} else {
						maxPosRange = posRange = ((GameState.lengthPositions.Length) / (numAsset));
						currentPosRange = 0;
				}
		}
		//not called?
		void OnCollisionEnter(Collision c)
		{		
		//	babyDist.text += " health/velocity : "+ rigidbody.maxAngularVelocity.ToString("F1");
			
		 	if(c.gameObject.tag=="Stroller"&& rigidbody.maxAngularVelocity>0){
		
			
			//	GameState.currentRoadIndex = this.name.Remove(5);
				
			}  
					print ("oncollision called in road****************** collision with = "+c.collider+ " c = "+c);
		}
		public void destroySelf(){

				Destroy (transform.root.gameObject);
				Destroy (this);

		}
	
		IEnumerator statusUpdate(float waitTime) {
				while (true) {   
						yield return new WaitForSeconds (waitTime);
						if (this.transform.position.z < GameState.PC.transform.position.z - 180) {
								GameState.resetObjectPools (false);
								destroySelf ();
						//	Destroy(this);
						}
				}
		}
}

