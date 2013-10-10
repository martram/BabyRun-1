using UnityEngine;
using System.Collections;

public class Baby : MonoBehaviour
//public class Baby : ScriptableObject
{
	//from baby controller
	public TextMesh babyDist;
	
	private const float m2ft = 3.280839895f;
	private const float physScale = 200f;
	public float health = 100f;
	
	private const string cannonPrefix = "Baby Distance: ";
	private const string cannonSuffix = " ft";
	
	private bool tossed = false;
	private Vector3 tossStart;
	
	
	
	
	
	public float babyTimer;
	public string babyName;
	public int babyID;
	public int statusHealth;
	public int statusHead;
	public int statusLeftLeg;
	public int statusRightLeg;
	public int statusLeftArm;
	public int statusRightArm;
	public int statusTorso;
	public int hunger;
	public int sleepiness;
	public GameObject babyObjectPart1;
	public GameObject babyObjectPart2;
	public GameObject  babyObjectF;
	public GameObject babyObject;
	public Vector3 leftArmPos;
	public Vector3 rightArmPos;
	
	//public Baby(string babyNameIn, int babyIDin){
	
	/*	babyObjectPart1 = (GameObject) GameObject.Instantiate (babyObjectF, babyObject.transform.position, Quaternion.identity);
		babyObjectPart2 = (GameObject) GameObject.Instantiate (babyObjectF, babyObject.transform.position, Quaternion.identity);
	
		babyObjectPart1.transform.parent= babyObject.transform;
		babyObjectPart2.transform.parent= babyObject.transform;*/

	
	//	babyObject =(GameObject)Instantiate(Resources.Load("Baby"));
	//}
	// Use this for initialization
	
	
	void Start ()
	{
		
		
		
	print ("baby Start");
		babyTimer=0;
		statusHealth=100;
	  	statusHead=100;
		statusLeftLeg=100;
		statusRightLeg=100;
		statusLeftArm=100;
		statusRightArm=100;
		statusTorso=100;
		hunger=0;
		sleepiness=0;
		//from babycontroller
		//babyDist.text = "";
		
	}
	public void createIdentity(string babyNameIn, int babyIDin){
		
		babyName = babyNameIn;
		babyID = babyIDin;
		
		babyObjectF = GameObject.Find("Baby");
		
		babyObject = (GameObject) GameObject.Instantiate (babyObjectF, Vector3.zero, Quaternion.identity);
		
		
		leftArmPos = babyObject.transform.position;
		leftArmPos.x-=0.2f;
		rightArmPos = babyObject.transform.position;
		rightArmPos.x+=0.2f;
		babyObjectPart1 = (GameObject) GameObject.Instantiate (babyObjectF, leftArmPos, Quaternion.identity);
		babyObjectPart2 = (GameObject) GameObject.Instantiate (babyObjectF, rightArmPos, Quaternion.identity);

		babyObjectPart1.transform.parent= babyObject.transform;
		babyObjectPart2.transform.parent= babyObject.transform;
		
		
	}
	
	
	public void TossBaby(Vector3 dir)
	{
		if(tossed) return;

		tossed = true;
		tossStart = transform.position;
		
		//transform.parent = null;
		
		collider.enabled = true;
		gameObject.AddComponent<Rigidbody>();
		
		Vector3 forceVec = (Vector3.up + dir)*physScale;
		rigidbody.AddForce(forceVec*rigidbody.mass);
	}
	
	void OnCollisionEnter(Collision c)
	{		
		
		//health-=rigidbody.maxAngularVelocity;
		babyDist.text += " health/velocity : "+ rigidbody.maxAngularVelocity.ToString("F1");
		if(c.gameObject.tag=="Ground"){
			
			rigidbody.maxAngularVelocity = 0f;
			
		} 
		print ("speed of impact ?" +rigidbody.maxAngularVelocity);
		health-=rigidbody.maxAngularVelocity*2;
		print("health  = "+health);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//from babycontroller
		if(tossed)
		{
			float dist = Vector3.Distance(tossStart, transform.position) * m2ft;
		//	babyDist.text = cannonPrefix + dist.ToString("F1") + cannonSuffix;
		}
	//	print (babyObject.transform.position);		
		//babyObject.transform.Translate(10f,0,0);
		hunger++;
		sleepiness++;
	  	babyTimer++;
	}
}

