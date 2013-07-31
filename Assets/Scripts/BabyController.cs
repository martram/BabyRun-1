using UnityEngine;
using System.Collections;

public class BabyController : MonoBehaviour
{
	public TextMesh cannonDist;
	
	private const float m2ft = 3.280839895f;
	private const float physScale = 600f;
	private const float health = 100f;
	
	private const string cannonPrefix = "Baby Distance: ";
	private const string cannonSuffix = " ft";
	
	private bool tossed = false;
	private Vector3 tossStart;
	
	void Start()
	{
		cannonDist.text = "";
	}
	
	void Update()
	{
		if(tossed)
		{
			float dist = Vector3.Distance(tossStart, transform.position) * m2ft;
			cannonDist.text = cannonPrefix + dist.ToString("F1") + cannonSuffix;
		}
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
		cannonDist.text += " health/velocity : "+ rigidbody.maxAngularVelocity.ToString("F1");
		if(c.gameObject.tag=="Ground"){
			
			rigidbody.maxAngularVelocity = 0f;
			
		} 
	}
}
