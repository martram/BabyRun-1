using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
	public int meteorSize;
	private Rigidbody goRigidbody;
	void Start(){
		
		goRigidbody=	gameObject.AddComponent<Rigidbody>();
		
		goRigidbody.mass = 190f;
		goRigidbody.useGravity = true;
	}
	
	
	public void createIdentity(int carID){
		meteorSize = Random.Range (0,1);
	/*	if (vehicleType == 0) {
			//bus
			carObject = (GameObject) Instantiate(Resources.Load("Vehicules/Bus", typeof(GameObject)));
			speed = 39f+Random.Range(0,4);
			GameState.createCoinsRow(Random.Range(6,11), true, 5.5f, carObject );
			
		} else {
			//car
			carObject = (GameObject) Instantiate(Resources.Load("Vehicules/Car", typeof(GameObject)));
			speed = 47f+Random.Range(0,4);
			
		}
		
		
		
		//	transform.Rotate(45,0,1);
		
		carCollisionBox = GameObject.Find("collisionBox");
		carCollisionBox.name="carCollisionBox";
		//	carCollisionBox.name="collisionBox"+GameState.carIndex;
		carCollider = carObject.gameObject.AddComponent<MeshCollider>();
		carCollider.sharedMesh = carObject.GetComponentInChildren<MeshFilter>().sharedMesh;
		carObject.layer = GameState.safeCollideLayer;
		//collisionBoxCollider= gameObject.AddComponent<BoxCollider>();
		collisionBoxCollider= carCollisionBox.AddComponent<BoxCollider>();
		ID=carID;
		
		collisionBoxCollider.center = carCollisionBox.GetComponentInChildren<MeshFilter>().sharedMesh.bounds.center;
		collisionBoxCollider.size =  carCollisionBox.GetComponentInChildren<MeshFilter>().sharedMesh.bounds.size;
		
		carCollisionBox.transform.parent = gameObject.transform;
		
		gameObject.AddComponent<AudioSource> ();
		
		carRunning = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Sounds/car_running", typeof(AudioClip)));
		carHonking = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Sounds/car_horn", typeof(AudioClip)));*/
		//loop? carRunning.
		//	collisionBoxCollider.size= new Vector3(3,0.8f,5);
	}
	
	public void destroySelf(){
		Destroy (transform.root.gameObject);
		Destroy (this);
		
	}
	
	void FixedUpdate()
	{
		
		if(this.transform.position.z<GameState.PC.transform.position.z-180){
			destroySelf ();
		}
		
	/*	if (GameState.bPaused == false && bCollided == false) {
			
			//stops on mobiledelta time
			rigidbody.velocity = new Vector3 (0f, 0f, -speed * Time.deltaTime * 80);
			//	rigidbody.velocity = new Vector3(0f,0f,-speed);
			if (!isRunning) {
				PlayCarRunning ();
			}
			
		} else {
			StopCarRunning ();
		}
		*/
		
		
	}
	
	
	void OnCollisionEnter(Collision c)
	{		
	/*	
		if (c.contacts [0].otherCollider.gameObject.layer != GameState.safeCollideLayer&&c.contacts [0].otherCollider.gameObject.name !="street_center(Clone)") {
			if (c.contacts [0].otherCollider.gameObject.name != "WoodBarrier(Clone)") {
				rigidbody.freezeRotation = false;
				rigidbody.velocity = new Vector3 (0f, 0f, -speed / 2);
				speed = 0f;
				bCollided = true;
				
				rigidbody.useGravity = true;
				rigidbody.isKinematic = false;
				
			} else {
				speed = speed * 0.9f;
				c.contacts [0].otherCollider.gameObject.rigidbody.AddForce (Random.Range(0.8f,0.8f)-0.8f,Random.Range(0.8f,speed*4),Random.Range(0.8f,2.9f));
				
				//rigidbody.velocity = new Vector3 (0f, 0f, -speed);
				
			}
		}
		
		*/

		
	}
}

