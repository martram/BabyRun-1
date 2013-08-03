using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputViewAndroid : InputView
{
	private const float minSwipeTime = 0f;
	private const float maxSwipeTime = 1f;
	
	private const float minSwipeDist = 0.25f;
	private const float maxSwipeDist = 1f;
	
	private const float tossThres = 0.5f;
	
	private bool swipeUp, swipeDown, swipeLeft, swipeRight;
	
	private Dictionary<int, float> touchTime = new Dictionary<int, float>();
	private Dictionary<int, Vector2> touchDist = new Dictionary<int, Vector2>();
	
	//InputView Methods
	
	override public float GetStrafeAmt()
	{
		return Input.acceleration.x;
	}
		override public bool GetLeftStrafe()
	{
		return swipeLeft;
	}
	
	override public bool GetRightStrafe()
	{
	return swipeRight;
	}
	/*override public bool GetLeftTurn()
	{
		return swipeLeft;
	}
	
	override public bool GetRightTurn()
	{
		return swipeRight;
	}*/
	
	override public bool GetJump()
	{
		return swipeUp;
	}
		
	override public bool GetDuck()
	{
		return swipeDown;
	}
	
	override public bool GetTossBaby()
	{
		return false;
	}
	
	override public void Start(){;}
	
	override public void Update()
	{
		//Handles back button
		if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		
		swipeUp = swipeDown = swipeLeft = swipeRight = false;
		
		for(int i = 0; i<Input.touchCount; i++)
		{
			Touch t = Input.GetTouch(i);
			switch(t.phase)
			{
			case TouchPhase.Began:
				OnTouchBegin(t);
				break;
			case TouchPhase.Moved:
			//case TouchPhase.Stationary:
				CheckSwipe(t);
				break;
			case TouchPhase.Ended:
			case TouchPhase.Canceled:
				OnTouchEnd(t);
				break;
			}
		}
	}
	
	//Touch Processing Methods
	
	private Vector2 ScaleTouchPos(Vector2 pos)
	{
		return new Vector2(pos.x/Screen.width, pos.y/Screen.height);
	}

	public void OnTouchBegin(Touch t)
	{
		touchTime.Add(t.fingerId, Time.timeSinceLevelLoad);
		touchDist.Add(t.fingerId, t.position);
	}
	
	public void OnTouchEnd(Touch t)
	{
		CheckSwipe(t);		
		touchTime.Remove(t.fingerId);
		touchDist.Remove(t.fingerId);
	}
	
	private void CheckSwipe(Touch t)
	{
		float time = Time.timeSinceLevelLoad - touchTime[t.fingerId];

		if(IsInRange(time, minSwipeTime, maxSwipeTime))
		{		
			Vector2 dist = ScaleTouchPos(t.position - touchDist[t.fingerId]);
			CheckSwipe(dist.y, ref swipeUp);
			CheckSwipe(-dist.y, ref swipeDown);
			CheckSwipe(-dist.x, ref swipeLeft);
			CheckSwipe(dist.x, ref swipeRight);
		}
	}
	
	private void CheckSwipe(float distance, ref bool flag)
	{
		if(IsInRange(distance, minSwipeDist, maxSwipeDist))
		{
			print("Swipe!");
			flag = true;
		}
		else print("Bad Swipe dist " + distance + "!\n");
	}
	
	private bool IsInRange(float val, float min, float max)
	{
		if(val<min) return false;
		if(val>max) return false;
		return true;
	}
	
	private void print(object o)
	{
		Debug.Log(o);
	}
}
