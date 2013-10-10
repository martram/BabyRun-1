using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	private const float speed = 0.3f;
	public bool bCollided=false;

	void Update()
	{
		if(GameState.paused==false && bCollided==false){
			transform.Translate(speed,0f,0f);
			//transform.Translate(Vector3.right);
			if(transform.localPosition.z<=-601||transform.localPosition.z>=51){
			//	print ("position set??"+transform.position);
				transform.Translate(-625f,0,0);
			}
		}
		
	}
	
	
	/*void OnCollisionEnter(Collision c)
	{		
		print ("car collided with "+c);
		bCollided=true;
	//	ConstantForce.
		Vector3 forceVec = (Vector3.up+ c.gameObject.transform.forward)*200f;
			rigidbody.AddForce(forceVec*rigidbody.mass);
	//		rigidbody.maxAngularVelocity;
	
	}*/
}
