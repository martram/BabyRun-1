using UnityEngine;
using System.Collections;

public class CarriageController : MonoBehaviour
{
	public BabyController baby;
	public Transform duckMovers;
	public Collider upper, lower;
	
	private bool ducking = false, jumping = false, turning = false, strafingRight=false, strafingLeft=false;
	
	private const float strafeSensitivity = 10f;
	private float runSpeed = 10.5f;
	private float strafeSpeed = 14f;
	//private const float turnSpeed = Mathf.PI/2f;
	//faster turn speed
	private float turnSpeed = 4f;
	
	private const float rightAngle = 90.0f;
	
	private const float duckDrop = 0.75f;
	private const float duckTime = 1f;
	

	private const float strafeTime = 0.2f;
	
	private int safeCollideLayer;
	private InputView tabletInput = InputView.CreateView();
	private Vector3 targetForward;
	
	void Start()
	{
		safeCollideLayer = LayerMask.NameToLayer("Nonfatal Collision");
		targetForward = transform.forward;
	}
	
	void Update()
	{
		
		//Touch controls may become confused if this isn't called every frame
		//So I keep calling this in case we ever want to turn the controller back on
		tabletInput.Update();
		
		if( rigidbody.isKinematic || GameState.IsPaused() ){ return;}
		else{
			runSpeed+=0.015f;
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
		if(strafingRight) inputVelocity += transform.right*strafeSpeed;
		if(strafingLeft) inputVelocity += transform.right*-strafeSpeed;
		
		Vector3 gravity = rigidbody.velocity.y * Vector3.up;
		rigidbody.velocity = inputVelocity + gravity;
		
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
	
		
		if(strafingLeft) return;
		strafingLeft = true;
		StartCoroutine( EndStrafeLeft() );
	}
	IEnumerator EndStrafeLeft()
	{
	
		
		yield return new WaitForSeconds(strafeTime);
	
		strafingLeft = false;
	}
	void StartStrafeRight()
	{
	
		
		if(strafingRight) return;
		strafingRight = true;
		StartCoroutine( EndStrafeRight() );
	}
	IEnumerator EndStrafeRight()
	{
	
		
		yield return new WaitForSeconds(strafeTime);
	
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
		rigidbody.velocity += Vector3.up * 7f;
	}
	
	void DeadStop()
	{
		lower.enabled = upper.enabled = false;
		rigidbody.isKinematic = true;
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
			DeadStop();
			//print(c.contacts[0].thisCollider.name + " collided with " + c.gameObject.name + ":" + c.gameObject.layer);
		}
	}
}
