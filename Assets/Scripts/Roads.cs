using UnityEngine;
using System.Collections;

public class Roads : MonoBehaviour
{
	
	

	private Vector3 walkwayPosLeft = new Vector3 (-11.8f,0f,0f);
	private Vector3  walkwayPosRight = new Vector3 (0f,0f,0f);
	private Vector3 roadSideLeftPos = new Vector3 (-35f,0f,0f);
	private Vector3  roadSideRightPos =  new Vector3 (0f,0f,0f);
	private Vector3  streetCenterPos = new Vector3 (0f,0f,0f);
	
	public GameObject walkwayStraightLeft, walkwayStraightRight, streetCenter, roadSideLeft, roadSideRight, roadGrassStraight;
	
	public MeshCollider  roadSideColliderLeft,roadSideColliderRight, walkwayStraightColliderLeft,walkwayStraightColliderRight;
	public BoxCollider streetCenterCollider;
	
	
	void Start ()
	{
		roadGrassStraight = (GameObject) Instantiate(Resources.Load("RoadParts/street_center", typeof(GameObject)));
		//streetCenter = roadGrassStraight.GetType();
	streetCenter =GameObject.Find("street_straight");
			streetCenter.name="street_center";
		
	
	//	print("children"+ streetCenter);
	//	streetCenter = roadGrassStraight.GetComponent("street_straight");
		//streetCenter = roadGrassStraight.GetComponentInChildren<GameObject>();
		
		roadSideLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side", typeof(GameObject)));
		roadSideLeft.transform.parent= roadGrassStraight.transform;
		
	 	roadSideRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/road_side", typeof(GameObject)));
		roadSideRight.transform.parent= roadGrassStraight.transform;
		
		walkwayStraightLeft = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_straight", typeof(GameObject)));
		walkwayStraightLeft.transform.parent= roadGrassStraight.transform;
	 	
		walkwayStraightRight = (GameObject) GameObject.Instantiate(Resources.Load("RoadParts/walkway_straight", typeof(GameObject)));
		walkwayStraightRight.transform.parent= roadGrassStraight.transform;
		//hugecollision?
	streetCenterCollider= roadGrassStraight.AddComponent<BoxCollider>();
		streetCenterCollider.size= new Vector3(500,999,3);
		//meshcolliders
	//streetCenterCollider = streetCenter.AddComponent<MeshCollider>();
	//	streetCenterCollider.sharedMesh = streetCenter.GetComponent<MeshFilter>().sharedMesh;
	
		/*roadSideColliderLeft = roadSideLeft.gameObject.AddComponent<MeshCollider>();
		roadSideColliderLeft.sharedMesh = roadSideLeft.GetComponentInChildren<MeshFilter>().sharedMesh;
		
		roadSideColliderRight = roadSideRight.gameObject.AddComponent<MeshCollider>();
		roadSideColliderRight.sharedMesh = roadSideRight.GetComponentInChildren<MeshFilter>().sharedMesh;
		
		walkwayStraightColliderLeft = walkwayStraightLeft.AddComponent<MeshCollider>();
		walkwayStraightColliderLeft.sharedMesh = walkwayStraightLeft.GetComponentInChildren<MeshFilter>().sharedMesh;
			
		walkwayStraightColliderRight = walkwayStraightRight.AddComponent<MeshCollider>();
		walkwayStraightColliderRight.sharedMesh = walkwayStraightRight.GetComponentInChildren<MeshFilter>().sharedMesh;*/
		
		
		
		walkwayStraightLeft.transform.Translate(walkwayPosLeft);
		roadSideLeft.transform.Translate(roadSideLeftPos);
		
		GameState.parentThisShit(roadGrassStraight);
		GameState.setRoadPosition(this);
		
		//streetCenter.transform.translate();
		
	}
	//not called?
	void OnCollisionEnter(Collision c)
	{		
	//	babyDist.text += " health/velocity : "+ rigidbody.maxAngularVelocity.ToString("F1");
		
	 	if(c.gameObject.tag=="Stroller"&& rigidbody.maxAngularVelocity>0){
			
			
			print (this.name.Remove(5));
		//	GameState.currentRoadIndex = this.name.Remove(5);
			
		
		}  
		
		
		print ("oncollision called in road******************");
		
		print ("road collision with = "+c.collider+ " c = "+c);
		
		
	
		
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}

