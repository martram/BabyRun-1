using UnityEngine;
using System.Collections;


public class Food : MonoBehaviour
{
	private const float speed = 80f;

	void Update()
	{
				transform.Rotate(Vector3.forward* speed * Time.deltaTime);
	}
}
