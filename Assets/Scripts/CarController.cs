using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	private const float speed = 1f;

	void Update()
	{
		transform.Translate(speed,0f,0f);
		//transform.Translate(Vector3.right);
		if(transform.localPosition.z<=-601||transform.localPosition.z>=51){
		//	print ("position set??"+transform.position);
			transform.Translate(-625f,0,0);
		}
		
	}
}
