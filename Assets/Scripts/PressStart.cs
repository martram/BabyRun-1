using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour
{
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel( Application.loadedLevel+1 );
		}
	}
}
