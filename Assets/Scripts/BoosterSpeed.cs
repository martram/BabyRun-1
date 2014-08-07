using UnityEngine;
using System.Collections;

public class BoosterSpeed : MonoBehaviour
{

	private const float speed = 80f;
	public const float speedBoost = 1.5f;
	public const float tempMultiplierBoost = 2f;


	void Update()
	{
				transform.Rotate(Vector3.forward* speed * Time.deltaTime);
	}
}

