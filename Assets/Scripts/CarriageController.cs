using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CarriageController : MonoBehaviour
{
	//public Baby baby;
	public Transform duckMovers;
	//public Collider upper, lower;
	
	private bool ducking = false, jumping = false, strafingRight=false, strafingLeft=false;
	
	public GUIText runningDistanceText;
	private const string runningDistancePrefix = "Running Points: ";
	private const string runningDistanceSuffix = "!";
	
	private const float strafeSensitivity = 10f;
		private float startRunSpeed = 16f;
	public float runSpeed;
		private float strafeSpeed = 26f;
		private float jumpForce=8f;



	private float nextLane= -2.2f;
	private const float rightAngle = 90.0f;

	private Vector3 runningStartPos;

	
	private const float duckDrop = 0.75f;
		private const float duckTime = 0.7f;
	private int currentLaneID = 2;
	private int nextLaneID = 2;
	

	private const float m2ft = 3.280839895f;

	private const float strafeTime = 0.2f;

	private InputView tabletInput = InputView.CreateView();
	private Vector3 targetForward , inputVelocity, gravity;
	public bool bCollisionCrash=false;
	
	public GameObject strollerObject;
		public GameObject strollerBabyNode;
		public GameObject strollerCollisionObject;
	public BoxCollider strollerCollider;
		public BoxCollider strollerCollisionCollider;
		public DontGoThroughThings strollerSaferCollision;
		public GameObject playerHobo;
	private int oldDistance;
	void Start()
	{
				strollerBabyNode = GameObject.Find("StrollerBabyNode").gameObject;
				playerHobo = GameObject.Find("PlayerHobo").gameObject;
		runningStartPos=transform.position;
		runSpeed = startRunSpeed;

		targetForward = transform.forward;
	//	rigidbody.AddTorque(transform.forward*runSpeed);
	}
	
	public void createIdentity(GameObject parentGo){
		strollerObject = (GameObject) Instantiate(Resources.Load("PlayerAssets/Stroller", typeof(GameObject)));
				strollerCollider= strollerObject.AddComponent<BoxCollider>();
			
				//strollerCollider.size= new Vector3(1.1f,1.5f,1.5f);
				//strollerCollider.center= strollerCollider.center+ new Vector3(0f,0.1f,-0.2f);
				strollerCollider.size= new Vector3(2.2f,2.2f,3f);
				strollerCollider.center= strollerCollider.center+ new Vector3(0f,0f,-1f);
		//need collision box from 3ds max
				strollerCollisionObject = GameObject.Find("BoxCollisionCollider");

				strollerCollisionCollider= strollerCollisionObject.gameObject.AddComponent<BoxCollider>();
				strollerCollisionCollider.size= new Vector3(5f,6f,7f);
				strollerCollisionCollider.center= strollerCollider.center+ new Vector3(0f,-1.1f,2f);

				strollerObject.layer = GameState.safeCollideLayer;
				strollerCollisionObject.layer= 0;

				//	strollerCollisionObject.AddComponent<Rigidbody>();
				//	strollerSaferCollision = strollerCollisionObject.AddComponent<DontGoThroughThings>();
			
				//	strollerCollisionObject.rigidbody.useGravity = false;
				//strollerCollisionObject.isStatic = true;
				//	strollerCollisionObject.rigidbody.freezeRotation = true;
				//strollerCollisionObject.rigidbody.constraints = true;
				//strollerCollisionObject.rigidbody.isKinematic = true;

				//	strollerSaferCollision.layerMask.value=1;
				//strollerCollisionObject.transform.parent = strollerObject.transform.parent.transform;
	//	strollerCollider.gameObject.transform.Translate(strollerCollider.transform.position.x,-8f,strollerCollider.transform.position.z+6f);
		
		/*
		carCollisionBox = GameObject.Find("collisionBox");
		carCollisionBox.name="collisionBox"+GameState.carIndex;
		carCollider = carObject.gameObject.AddComponent<MeshCollider>();
		
		carCollider.sharedMesh = carObject.GetComponentInChildren<MeshFilter>().sharedMesh;
		collisionBoxCollider= carCollisionBox.AddComponent<BoxCollider>();
	*/
	}
	
		void FixedUpdate()
		{
				if(!rigidbody || rigidbody.isKinematic || GameState.IsPaused()||bCollisionCrash ){ return;}
				else{
						//print ("runSpeed = "+runSpeed);
						if (runSpeed < 50f) {
								runSpeed+=0.006f;
						}
		

				}
				inputVelocity = transform.forward * runSpeed;
				if(strafingRight&&transform.position.x>=GameState.lanes[nextLaneID]){
						EndStrafeRight();

				}
				if(strafingLeft&&transform.position.x<=GameState.lanes[nextLaneID]){
						EndStrafeLeft();

				}
				if(strafingRight){
						if(GameState.lanes[nextLaneID]>GameState.lanes[currentLaneID]) inputVelocity += transform.right*strafeSpeed;
				} 
				if(strafingLeft){
						if(GameState.lanes[nextLaneID]<GameState.lanes[currentLaneID]) inputVelocity += transform.right*-strafeSpeed;
				} 

				gravity = rigidbody.velocity.y * Vector3.up;
				//stops on mobiledelta time
				rigidbody.velocity = (inputVelocity*Time.deltaTime*80 + gravity);
				//rigidbody.velocity = inputVelocity + gravity;
		}
		void Update()
	{
		
		//Touch controls may become confused if this isn't called every frame
		//So I keep calling this in case we ever want to turn the controller back on
		tabletInput.Update();
		
			
		
	//	inputVelocity = Vector3.zero;
		
		if(tabletInput.GetRightStrafe()) StartStrafeRight();
		if(tabletInput.GetLeftStrafe()) StartStrafeLeft();
		if(tabletInput.GetJump()) Jump();
		if(tabletInput.GetDuck()) StartDuck();
		if(tabletInput.GetResetGame()) GameState.ResetGameState();
	   	
	}
	
		public void StartRunning() {

				playerHobo.animation.Play("running");

		}
		public void TouchGround() {

				playerHobo.animation.Play("touchGround");
				playerHobo.animation.PlayQueued ("running");
				jumping = false;
		}

		public void StartStrafeLeft()
	{	
		if(strafingLeft||GameState.baby[GameState.babyIndex].isTossed){
			return;
			
		} else{
			if(currentLaneID>0){
				GameState.reduceCatStuckEnergy ();
				nextLaneID--;
				nextLane= GameState.lanes[nextLaneID];		
				strafingLeft = true;
			}
			
		}	
		
	}
	void EndStrafeLeft()
	{
		currentLaneID--;
		//give exact position//vectorright = 1,0,0
		transform.Translate(GameState.lanes[currentLaneID]-transform.position.x,0,0);


		strafingLeft = false;
	}
		public void StartStrafeRight()
	{
		if(strafingRight||GameState.baby[GameState.babyIndex].isTossed){
			return;	
		}
		else{

			if(currentLaneID<3){
				GameState.reduceCatStuckEnergy ();
				nextLaneID++;
				nextLane= GameState.lanes[nextLaneID];
				strafingRight = true;
			} 
				
		}	
	}
	void EndStrafeRight()
	{
	
		currentLaneID++;
		transform.Translate(GameState.lanes[currentLaneID]-transform.position.x,0,0);

		strafingRight = false;
	}
	
	void StartDuck()
	{
				if (ducking||GameState.baby[GameState.babyIndex].isTossed){
						return;
				}
				ducking = true;
				if (jumping) {

						GameState.reduceCatStuckEnergy ();
						rigidbody.velocity -= Vector3.up * jumpForce*1.2f;
				}
				//	duckMovers.localPosition -= Vector3.up * duckDrop;
	//	upper.enabled = false;
		StartCoroutine( EndDuck() );
	}
	
	IEnumerator EndDuck()
	{
		yield return new WaitForSeconds(duckTime);
				//	duckMovers.localPosition += Vector3.up * duckDrop;
	//	upper.enabled = true;
		ducking = false;
	}
	
	public void Jump()
	{
				if (jumping || GameState.baby [GameState.babyIndex].isTossed) {
						return;
				}
		jumping = true;
		//rigidbody.AddTorque(Vector3.forward * 7f);
		//rigidbody.AddForce(Vector3.up * 7f);

				if (!GameState.bPaused) {
						GameState.reduceCatStuckEnergy ();
						playerHobo.animation.Play("jumping");
						rigidbody.velocity += Vector3.up * jumpForce;
				}
	}

	void DeadStop(GameObject collisionObject)
	{
		if(!GameState.baby[GameState.babyIndex].isTossed){
		bCollisionCrash=true;
	//	lower.enabled = upper.enabled = false;
		
				//	rigidbody.isKinematic = true;
				//rigidbody.AddForce(transform.forward*10f);
				print("DeadStop babyIDs = "+GameState.babyIndex);
			
				//rigidbody.useGravity = true;
				//rigidbody.freezeRotation = false;


				if (collisionObject.transform.name == "Car(Clone)"||collisionObject.transform.name =="carCollisionBox") {
						rigidbody.velocity += collisionObject.rigidbody.velocity*0.8f;
						GameState.baby [GameState.babyIndex].TossBaby (rigidbody.velocity * 5 + collisionObject.rigidbody.velocity, runSpeed);
				} else {
						GameState.baby [GameState.babyIndex].TossBaby (rigidbody.velocity * 5, runSpeed);
				}
				if (GameState.HUDinstance.runningScore > GameState.currentHighScore) {
				
						GameState.currentHighScore = GameState.HUDinstance.runningScore;
					GameState.HUDinstance.UpdateHighScore (GameState.HUDinstance.runningScore);
				}
				//GameState.baby[GameState.babyIndex-1].TossBaby(transform.forward, runSpeed);
		}
	}
	
	void OnTriggerEnter(Collider c)
	{

				if(c.tag=="Gold"&&!GameState.isCatInFace)
		{

						GameState.AddCoins(10);
						GameState.ParticleCoins.transform.position = c.gameObject.transform.position;
						GameState.ParticleCoins.particleSystem.Play ();
						c.gameObject.renderer.enabled = false;
						c.gameObject.collider.enabled = false;
						//GameState.ResetPoolObject(c.gameObject);

		}
		if(c.tag=="Coin"&&!GameState.isCatInFace)
		{

			GameState.AddCoins(1);
			GameState.ParticleCoins.transform.position = c.gameObject.transform.position;
			GameState.ParticleCoins.particleSystem.Play ();
						c.gameObject.renderer.enabled = false;
						c.gameObject.collider.enabled = false;
						//GameState.ResetPoolObject(c.gameObject);
						GameState.AudioControl.playGetCoin ();
			
		}
		
		if(c.tag=="Food"&&!GameState.isCatInFace)
		{
			GameState.AddFood(1);
			GameState.ParticleFood.transform.position = c.gameObject.transform.position;
			GameState.ParticleFood.particleSystem.Play ();
			GameState.baby [GameState.babyIndex].hunger+=5;
			GameState.baby [GameState.babyIndex].healBaby (5);
			Destroy(c.gameObject);
		}
        if (c.tag == "BoosterSpeed" && !GameState.isCatInFace)
        {
           
            GameState.ParticleFood.transform.position = c.gameObject.transform.position;
            GameState.ParticleFood.particleSystem.Play();
            Destroy(c.gameObject);
        }
	}
	public void resetState(){
				runSpeed = startRunSpeed;
				//	strollerObject.transform.rotation = Quaternion.identity;
				if (rigidbody) {
					rigidbody.velocity = Vector3.zero;
					rigidbody.angularVelocity=Vector3.zero;
				}
				print ("**ResetState**="+runSpeed);
	}
	void OnCollisionEnter(Collision c)
	{
		if (jumping) {
			TouchGround ();
			
		}

		
		if(!GameState.baby[GameState.babyIndex].isTossed){
			//	print (c.contacts [0].thisCollider.gameObject.name + "- !! - babyIndex =  " + GameState.babyIndex);
			print (c.contacts [0].thisCollider.name + "???? collided with " + c.contacts [0].otherCollider.name + ":" + c.contacts [0].otherCollider.gameObject.layer);
			
			if (c.contacts [0].thisCollider.name == "BoxCollisionCollider" && !GameState.baby [GameState.babyIndex].isTossed) {
				
				//				print (c.contacts [0].thisCollider.name + "- fatal collision with - " + c.gameObject.name);
				
				//temp anim, need hit
				playerHobo.animation.Play("touchGround");
				DeadStop (c.gameObject);
				
				
			} else if (c.contacts [0].otherCollider.name == "Car(Clone)" || c.contacts [0].otherCollider.name == "Bus(Clone)") {
				
				c.contacts [0].otherCollider.gameObject.layer = GameState.safeCollideLayer;
				
				if (nextLaneID > currentLaneID && jumping == false) {
					
					strafingRight = false;
					currentLaneID = nextLaneID;
					StartStrafeLeft ();
					
				} else if (nextLaneID < currentLaneID && jumping == false) {
					
					strafingLeft = false;
					currentLaneID = nextLaneID;
					StartStrafeRight ();
				} else {
					jumping = true;
				}
				
				
			}else if (c.contacts [0].otherCollider.name == "ScaffoldStart(Clone)") {
				jumping = true;
				
			}
			Vector3	contactDamageVector;
			float totalContactDamage;
			
			//parse first characters, directional convert part to location
			if (c.contacts [0].otherCollider.name == "BabyArmLeft(Clone)" ||
			    c.contacts [0].otherCollider.name == "BabyArmRight(Clone)" ||
			    c.contacts [0].otherCollider.name == "BabyLegLeft(Clone)" ||
			    c.contacts [0].otherCollider.name == "BabyLegRight(Clone)" ||
			    c.contacts [0].otherCollider.name == "BabyHead(Clone)" ||
			    c.contacts [0].otherCollider.name == "BabyTorso(Clone)") {
				contactDamageVector = c.gameObject.rigidbody.velocity + c.contacts [0].otherCollider.rigidbody.velocity;
				totalContactDamage = (contactDamageVector.x + contactDamageVector.y + contactDamageVector.z) * -0.5f;
				
				print ("what this does? " + c.contacts [0].otherCollider.name);
				GameState.baby [GameState.babyIndex].healthDrop (c.contacts [0].otherCollider.name, totalContactDamage);
				
			}
		}
		
	}
}
