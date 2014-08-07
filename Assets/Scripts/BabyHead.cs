using UnityEngine;
using System.Collections;
using System;

public class BabyHead : MonoBehaviour
{
				public GameObject babyPart;
		private string typePart;

				public MeshCollider babyArmPartCollider;
				public float partBreakForce= 67f;

				public FixedJoint partJoint;
		private Quaternion partRotation;



			public BabyHead ()
				{

				}

	public void createPart(bool bCat, Vector3 babyPartPosition, bool bFlipped){
		/*if(bCat){
			typePart = "Cat";
			
		}else{
			typePart= "Baby";
			
			
		}

		babyPart = (GameObject)GameObject.Instantiate (Resources.Load ("BabyParts/BabyArm" + typePart, typeof(GameObject)));*/
		name="BabyHead";
		partRotation = gameObject.transform.rotation;
		 gameObject.AddComponent<BoxCollider> ().size=new Vector3(2f,2.3f,2.6f);;
	// babyArmPartCollider = gameObject.AddComponent<MeshCollider> ();
		// babyArmPartCollider.sharedMesh = gameObject.GetComponent<MeshFilter> ().sharedMesh;	
		
	 //	gameObject.AddComponent<Rigidbody> ();
		
	}
	public void resetPart(Vector3 babyPartPosition){
			gameObject.collider.enabled = false;
				if(	gameObject.rigidbody!=null){

						gameObject.rigidbody.useGravity = false;
						gameObject.rigidbody.isKinematic = true;
				}
	 	 	

			gameObject.transform.parent = gameObject.transform.parent.transform;
				//	gameObject.transform.position = Vector3.zero;
			gameObject.transform.localPosition= babyPartPosition;


			gameObject.transform.rotation = partRotation;
			gameObject.layer = GameState.safeCollideLayer;
			gameObject.renderer.enabled = true;

				//createJoint ();
		}

	
	public void createJoint(){
		
		
		print ("HEAD1 gameObject.rigidbody = "+gameObject.rigidbody);
		if (!partJoint) {
			partJoint = gameObject.AddComponent<FixedJoint> ();
			partJoint.connectedBody = gameObject.transform.parent.gameObject.transform.parent.rigidbody;
			
			partJoint.breakForce = partBreakForce;
			print ("HEAD2 gameObject.rigidbody = "+gameObject.rigidbody);
		}

		
	}

}

