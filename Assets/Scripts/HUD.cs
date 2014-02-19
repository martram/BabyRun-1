using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HUD : MonoBehaviour
{
	public GUISkin menuSkin;
	//defined in unity
	public float areaWidth;
	public float areaHeight;
	public GameObject receiver;

	public string buttonText;

	void Start()
	{
	}
	
	private void SendMessage(object parameter)
	{
		print ("receiver received! " + parameter);
		if(receiver) receiver.SendMessage("OnButtonClicked", parameter, SendMessageOptions.DontRequireReceiver);
	}
	
	void OnGUI()
	{
		GUI.skin = menuSkin;

		float screenY=((Screen.height*0.5f)-(areaHeight*0.5f));
		float screenX=((Screen.width*0.8f)+(areaWidth*0.5f));
		GUILayout.BeginArea(new Rect(screenX,screenY, areaWidth,areaHeight));

		if(GUILayout.Button ("Pause"))
		{
			//	GameState.
			SendMessage("Pause");
			print("pausing");
	
		}
		//why no reset
		if(GUILayout.Button ("Reset"))
		{

			SendMessage("Reset");
			print("reseting");
	
		}
		GUILayout.EndArea();
	/*	if( GUI.Button(buttonRect, "\n"+buttonText, buttonStyle) )
		{
			SendMessage(buttonText);
		}*/
	}
}
