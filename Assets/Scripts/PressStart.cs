using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour
{
	public GameObject receiver;

	void start()
	{
	
		
	}
	void Update()
	{
	/*	if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel( Application.loadedLevel+1 );
		}*/
		if(Input.GetMouseButtonDown(0))
		{
			//MainMenu.
		}
	}
	private void SendMessage(object parameter)
	{
		if(receiver) receiver.SendMessage("OnButtonClicked", parameter, SendMessageOptions.DontRequireReceiver);
	}

}
