using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour
{
	public GameObject receiver;
	public string buttonText;

	public Rect buttonSelectRect;
	GUIStyle buttonStyle;
	
	void Start()
	{
		Bounds bounds = renderer.bounds;
		Vector3 buttonSelectPos;
		buttonSelectPos.x=100;
		buttonSelectPos.y=100;
		buttonSelectPos.z=0;
		
		
		//Vector3 buttonPos = Camera.main.WorldToScreenPoint( new Vector3(bounds.min.x, bounds.max.y, bounds.min.z) );
		buttonSelectPos.y = Screen.height - buttonSelectPos.y;
		
		buttonSelectPos.x = Screen.width - buttonSelectPos.x;


		Vector3 buttonMax = Camera.main.WorldToScreenPoint( bounds.max );
		Vector3 buttonMin = Camera.main.WorldToScreenPoint( bounds.min );
	
		Vector3 buttonSize = buttonMax-buttonMin;
	
		
				buttonSelectRect = new Rect(buttonSelectPos.x, buttonSelectPos.y, buttonSize.x, buttonSize.y);
	
		
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

		
				if( GUI.Button(buttonSelectRect, "Select",buttonStyle) )
		{
						SendMessage("Select");
		}

}
}
