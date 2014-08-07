using UnityEngine;
using System.Collections;

public class BabyArmTentacle : MonoBehaviour
		{
				public GameObject babyArm;

				public MeshCollider babyTorsoCollider, babyArmLeftCollider, babyArmRightCollider, babyLegLeftCollider, babyLegRightCollider, babyHeadCollider;
				private float armLeftBreakForce= 47f;

				FixedJoint babyHeadJoint,babyArmLeftJoint,babyArmRightJoint,babyLegLeftJoint,babyLegRightJoint;

		public BabyArmTentacle ()
				{
						babyArm = (GameObject)GameObject.Instantiate (Resources.Load ("BabyParts/BabyArmLeft", typeof(GameObject)));
						//	leftArmRotation = babyArmLeft.transform.rotation;
						//	babyArmLeft.transform.parent = babyObject.transform;
						babyArmLeftCollider = babyArm.AddComponent<MeshCollider> ();
						babyArmLeftCollider.sharedMesh = babyArm.GetComponent<MeshFilter> ().sharedMesh;	
						babyArmLeftCollider.collider.enabled = false;
						babyArm.AddComponent<Rigidbody> ();
						babyArmLeftJoint = babyArm.AddComponent<FixedJoint> ();
						//	babyArmLeftJoint.connectedBody = this.transform.parent.rigidbody;
						babyArmLeftJoint.breakForce = armLeftBreakForce;
						babyArm.rigidbody.useGravity = false;
						babyArm.layer = GameState.safeCollideLayer;

				}
		}


