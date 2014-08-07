using UnityEngine;
using System.Collections;
using System;

public class BabyArm : MonoBehaviour
{
				public GameObject babyPart;
		private string typePart;

				public MeshCollider partCollider;
				public float partBreakForce= 47f;

			public 	FixedJoint partJoint;
		private Quaternion partArmRotation;



			public BabyArm ()
				{

				}

	public void createPart(bool bCat, Vector3 babyPartPosition, bool bFlipped){
	
		partArmRotation = gameObject.transform.rotation;
		gameObject.AddComponent<BoxCollider> ().size=new Vector3(1.8f,0.5f,0.5f);;
	//	partCollider = gameObject.AddComponent<MeshCollider> ();
		//partCollider.sharedMesh = gameObject.GetComponent<MeshFilter> ().sharedMesh;	
		
		// gameObject.AddComponent<Rigidbody> ();
		name= "BabyArmLeft";
	//	print (System.DateTime.Now+" bflipped? "+bFlipped);
		if(bFlipped){
			name= "BabyArmRight";
			gameObject.transform.localScale = new Vector3 (-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			Mesh mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			int[] triangles = mesh.triangles;
			Array.Reverse(triangles);
			mesh.triangles = triangles;
		}
	}
	public void resetPart(Vector3 babyPartPosition){
			gameObject.collider.enabled = false;
	 if(gameObject.rigidbody!=null){
			Destroy(gameObject.rigidbody);

		}

		//	gameObject.rigidbody.useGravity = false;
		//	gameObject.rigidbody.isKinematic = true;
	
			gameObject.transform.parent = gameObject.transform.parent.transform;
			gameObject.transform.localPosition= babyPartPosition;


			gameObject.transform.rotation = partArmRotation;
			gameObject.layer = GameState.safeCollideLayer;
			gameObject.renderer.enabled = true;


		}
	
	
	public void createJoint(){
		
		if (!partJoint) {
			partJoint = gameObject.AddComponent<FixedJoint> ();
			partJoint.connectedBody = gameObject.transform.parent.gameObject.transform.parent.rigidbody;
			
			partJoint.breakForce = partBreakForce;
		}
	
	}
	 

}

