using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarriageController : MonoBehaviour
{
	public BabyController baby;
	public Transform duckMovers;
	public Collider upper, lower;
	
	private bool ducking = false, jumping = false, turning = false, strafingRight=false, strafingLeft=false, strafing=false;
	
	private const float strafeSensitivity = 10f;
	private float runSpeed = 12f;
	private float strafeSpeed = 18f;
	//private const float turnSpeed = Mathf.PI/2f;
	//faster turn speed
	private float turnSpeed = 8f;
	private float currentLane= -2.7f;
	private float nextLane= -2.7f;
	private const float rightAngle = 90.0f;
	
	private const float duckDrop = 0.75f;
	private const float duckTime = 1f;
	private int currentLaneID = 2;
	private int nextLaneID = 2;
	private float[] lanes = new float[4];

	private const float strafeTime = 0.2f;
	
	
	private int safeCollideLayer;
	private InputView tabletInput = InputView.CreateView();
	private Vector3 targetForward;
	
	void Start()
	{
		lanes[0]=-11.6f;
		lanes[1]=-6.8f;
		lanes[2]=-2.6f;
		lanes[3]=2.4f;
		safeCollideLayer = LayerMask.NameToLayer("Nonfatal Collision");
		targetForward = transform.forward;
		rigidbody.AddTorque(transform.forward*runSpeed);
	}
	
	void Update()
	{
		
		//Touch controls may become confused if this isn't called every frame
		//So I keep calling this in case we ever want to turn the controller back on
		tabletInput.Update();
		
		if( rigidbody.isKinematic || GameState.IsPaused() ){ return;}
		else{
			runSpeed+=0.0175f;
			//turnSpeed+=0.006f;
		}
		
		Vector3 inputVelocity = Vector3.zero;
		
	//	if(!turning)
			inputVelocity += transform.forward * runSpeed;
		
		//if(tabletInput.GetRightTurn()) StartTurn(rightAngle);
		//if(tabletInput.GetLeftTurn()) StartTurn(-rightAngle);
		if(tabletInput.GetRightStrafe()) StartStrafeRight();
		if(tabletInput.GetLeftStrafe()) StartStrafeLeft();
		if(tabletInput.GetJump()) GenerateLift();
		if(tabletInput.GetDuck()) StartDuck();
		
		//if(!turning) inputVelocity += transform.right*tabletInput.GetStrafeAmt()*strafeSensitivity;
		if(strafingRight&&transform.position.x>=lanes[nextLaneID]){
			EndStrafeRight();
			//print ("endstrafe called");
		}
		if(strafingLeft&&transform.position.x<=lanes[nextLaneID]){
			EndStrafeLeft();
			//print ("endstrafe called");
		}
		if(strafingRight){
			if(lanes[nextLaneID]>lanes[currentLaneID]) inputVelocity += transform.right*strafeSpeed;
		} 
		if(strafingLeft){
			if(lanes[nextLaneID]<lanes[currentLaneID]) inputVelocity += transform.right*-strafeSpeed;
		} 
		
		//Vector3 gravity = -0.75f* Vector3.up;
		Vector3 gravity = rigidbody.velocity.y * Vector3.up;
	/*	if(gravity.y<0){
			gravity= gravity*1.5;
		}
	if(rigidbody.position.y>0){*/
			
			rigidbody.velocity = inputVelocity + gravity;
	/*	print ("gravity = "+ gravity);
	}*/
		
	   
		transform.forward = Vector3.RotateTowards(transform.forward, targetForward, turnSpeed*Time.deltaTime, 0.0f);
		if( Vector3.Angle(transform.forward, targetForward) <= 0.1f ) turning = false;
	}
	
	/*void StartTurn(float angle)
	{
		if(turning) return;
		turning = true;
		
		targetForward = Quaternion.AngleAxis(angle, Vector3.up) * targetForward;
	}
	*/
	void StartStrafeLeft()
	{
//	print ("strafingleft : "+strafingLeft+" "+lanes[nextLaneID] + "   pos  "+ transform.position.x);	
	
		
		if(strafingLeft){
			return;
			
		} else{
			if(currentLaneID>0){
				nextLaneID--;
				nextLane= lanes[nextLaneID];
	//			print ("current "+lanes[currentLaneID]+ " next "+ lanes[nextLaneID]);
				
				strafingLeft = true;
			}
			
		}	
		
	}
	void EndStrafeLeft()
	{
		currentLaneID--;
		//give exact position//vectorright = 1,0,0
		transform.Translate(lanes[currentLaneID]-transform.position.x,0,0);
	//	print ("endLeft ="+transform.position.x+" should be "+lanes[currentLaneID]+" "+Vector3.right);
	//rigidbody.transform.Translate(lanes[currentLaneID],transform.right.y,transform.right.z);
//		transform.Translate(lanes[currentLaneID],transform.right.y,transform.right.z);
		//yield return new WaitForSeconds(strafeTime);

		strafingLeft = false;
	}
	void StartStrafeRight()
	{
	//print ("strafingright : "+strafingRight+" "+lanes[nextLaneID] + "   pos  "+ transform.position.x);	
			
		
		if(strafingRight){
			return;	
		}
		else{
			if(currentLaneID<3){
				nextLaneID++;
				nextLane= lanes[nextLaneID];
		//		print ("current "+currentLaneID+ " next "+ nextLaneID);
				strafingRight = true;
			} 
				
		}	
	
		
		//check logic, continue left
		
		
			//StartCoroutine( EndStrafeRight() );
	
	}
	//IEnumerator EndStrafeRight()
	void EndStrafeRight()
	{
	
		currentLaneID++;
		transform.Translate(lanes[currentLaneID]-transform.position.x,0,0);
	//transform.Translate(lanes[currentLaneID],transform.forward.y,transform.forward.z);
		//print ("endRight ="+transform.position.x+" should be "+lanes[currentLaneID]);
		strafingRight = false;
	}
	
	void StartDuck()
	{
		if(ducking) return;
		ducking = true;
		duckMovers.localPosition -= Vector3.up * duckDrop;
		upper.enabled = false;
		StartCoroutine( EndDuck() );
	}
	
	IEnumerator EndDuck()
	{
		yield return new WaitForSeconds(duckTime);
		duckMovers.localPosition += Vector3.up * duckDrop;
		upper.enabled = true;
		ducking = false;
	}
	
	void GenerateLift()
	{
		if(jumping) return;
		jumping = true;
		//rigidbody.AddTorque(Vector3.forward * 7f);
		//rigidbody.AddForce(Vector3.up * 7f);
		rigidbody.velocity += Vector3.up * 7f;
	}
	
	void DeadStop()
	{
		lower.enabled = upper.enabled = false;
		rigidbody.isKinematic = true;
		rigidbody.AddForce(transform.forward*10f);
		baby.TossBaby(transform.forward);
	}
	
	void OnTriggerEnter(Collider c)
	{
		if(c.tag=="Coin")
		{
			GameState.AddCoins(1);
			Destroy(c.gameObject);
		}
		
		if(c.tag=="Food")
		{
			GameState.AddFood(1);
			Destroy(c.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision c)
	{
		jumping = false;
		
		if(c.gameObject.layer!=safeCollideLayer)
		{
			print(c.contacts[0].thisCollider.name + " collided with " + c.gameObject.name + ":" + c.gameObject.layer);

			DeadStop();
				}
	}
}
