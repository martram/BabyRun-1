using UnityEngine;
using System.Collections;
using System;

public class BabyLeg : MonoBehaviour
{
				public GameObject babyPart;
		private string typePart;

				public MeshCollider partCollider;
				public float partBreakForce= 47f;

			public	FixedJoint partJoint;
		private Quaternion partRotation;



			public BabyLeg ()
				{

				}

	public void createPart(bool bCat, Vector3 babyPartPosition, bool bFlipped){
		/*if(bCat){
			typePart = "Cat";
			
		}else{
			typePart= "Baby";
			
			
		}

		babyPart = (GameObject)GameObject.Instantiate (Resources.Load ("BabyParts/BabyArm" + typePart, typeof(GameObject)));*/
		partRotation = gameObject.transform.rotation;
		gameObject.AddComponent<BoxCollider> ().size=new Vector3(0.5f,0.5f,2.3f);;
	//	partCollider = gameObject.AddComponent<MeshCollider> ();
		//partCollider.sharedMesh = gameObject.GetComponent<MeshFilter> ().sharedMesh;	
		gameObject.collider.transform.localPosition = new Vector3(0f,0f,3f);
	//	gameObject.AddComponent<Rigidbody> ();

	//	print (System.DateTime.Now+" bflipped? "+bFlipped);
		name="BabyLegLeft";
		if(bFlipped){
			name="BabyLegRight";
			gameObject.transform.localScale = new Vector3 (-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			Mesh mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			int[] triangles = mesh.triangles;
			Array.Reverse(triangles);
			mesh.triangles = triangles;
		}
		
		
		
	}
	public void resetPart(Vector3 babyPartPosition){
			gameObject.collider.enabled = false;
			//gameObject.rigidbody.useGravity = false;
			//gameObject.rigidbody.isKinematic = true;

			gameObject.transform.parent = gameObject.transform.parent.transform;
			gameObject.transform.localPosition= babyPartPosition;


			gameObject.transform.rotation = partRotation;
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

