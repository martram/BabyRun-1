using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour
{
	public GameObject receiver;
	public string buttonText;
	
	private Rect buttonResetRect;
	private Rect buttonPauseRect;
	GUIStyle buttonStyle;
	
	void Start()
	{
		Bounds bounds = renderer.bounds;
		Vector3 buttonResetPos;
		buttonResetPos.x=100;
		buttonResetPos.y=100;
		buttonResetPos.z=0;
		
		Vector3 buttonPausePos;
		buttonPausePos.x=300;
		buttonPausePos.y=100;
		buttonPausePos.z=0;
		//Vector3 buttonPos = Camera.main.WorldToScreenPoint( new Vector3(bounds.min.x, bounds.max.y, bounds.min.z) );
		buttonResetPos.y = Screen.height - buttonResetPos.y;
		buttonPausePos.y = Screen.height - buttonPausePos.y;
		buttonResetPos.x = Screen.width - buttonResetPos.x;
		buttonPausePos.x = Screen.width - buttonPausePos.x;

		Vector3 buttonMax = Camera.main.WorldToScreenPoint( bounds.max );
		Vector3 buttonMin = Camera.main.WorldToScreenPoint( bounds.min );
	
		Vector3 buttonSize = buttonMax-buttonMin;
	
		
		buttonResetRect = new Rect(buttonResetPos.x, buttonResetPos.y, buttonSize.x, buttonSize.y);
		buttonPauseRect = new Rect(buttonPausePos.x, buttonPausePos.y, buttonSize.x, buttonSize.y);
		
		renderer.enabled = false;
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

		if( GUI.Button(buttonResetRect, "Reset", buttonStyle) )
		{
			SendMessage("Reset");
		}
		if( GUI.Button(buttonPauseRect, "Pause",buttonStyle) )
		{
			SendMessage("Pause");
		}
	/*	if( GUI.Button(buttonRect, "\n"+buttonText, buttonStyle) )
		{
			SendMessage(buttonText);
		}*/
	}
}
