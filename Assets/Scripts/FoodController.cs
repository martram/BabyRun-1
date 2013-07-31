using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour
{
	private const float speed = 1f;

	void Update()
	{
		transform.RotateAroundLocal(Vector3.up, speed * Time.deltaTime);
	}
}
