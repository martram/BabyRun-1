using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour
{
	public GameObject receiver;
	private Rect buttonRunRect;
	private Rect buttonMenuRect;
	void start()
	{
		buttonRunRect = new Rect(100, 50, 100, 50);
	}
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel( Application.loadedLevel+1 );
		}
	}
	private void SendMessage(object parameter)
	{
		if(receiver) receiver.SendMessage("OnButtonClicked", parameter, SendMessageOptions.DontRequireReceiver);
	}
	void OnGUI()
	{
		GUIStyle buttonStyle = new GUIStyle( GUI.skin.button );
		buttonStyle.wordWrap = true;
		buttonStyle.alignment = TextAnchor.UpperCenter;

		if( GUI.Button(buttonRunRect, "Run", buttonStyle) )
		{
			SendMessage("Run");
		}
		if( GUI.Button(buttonRunRect, "Menu", buttonStyle) )
		{
			SendMessage("Menu");
		}
		if( GUI.Button(buttonRunRect, "Get More Babies", buttonStyle) )
		{
			SendMessage("Get More Babies");
		}
		if( GUI.Button(buttonRunRect, "Manage Your Babies", buttonStyle) )
		{
			SendMessage("Manage Your Babies");
		}
		if( GUI.Button(buttonRunRect, "Buy Stuff",buttonStyle) )
		{
			SendMessage("Buy Stuff");
		}
	/*	if( GUI.Button(buttonRunRect, "\n"+buttonText, buttonStyle) )
		{
			SendMessage(buttonText);
		}*/
	}
}
