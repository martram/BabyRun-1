using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputViewDesktop : InputView
{	
	//InputView Methods

	override public float GetStrafeAmt()
	{
		return Input.GetAxis("Mouse X");
	}
	override public bool GetLeftStrafe()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow)) return true;
		if(Input.GetKeyDown(KeyCode.A)) return true;
		return false;
	}
	
	override public bool GetRightStrafe()
	{
		if(Input.GetKeyDown(KeyCode.RightArrow)) return true;
		if(Input.GetKeyDown(KeyCode.D)) return true;
		return false;
	}
	/*override public bool GetLeftTurn()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow)) return true;
		if(Input.GetKeyDown(KeyCode.A)) return true;
		return false;
	}
	
	override public bool GetRightTurn()
	{
		if(Input.GetKeyDown(KeyCode.RightArrow)) return true;
		if(Input.GetKeyDown(KeyCode.D)) return true;
		return false;
	}*/
	
	override public bool GetJump()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow)) return true;
		if(Input.GetKeyDown(KeyCode.W)) return true;
		return false;
	}
	
	override public bool GetDuck()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow)) return true;
		if(Input.GetKeyDown(KeyCode.S)) return true;
		return false;
	}
	override public bool GetResetGame(){
			if(Input.GetKeyDown(KeyCode.Space)) return true;	
			return false;
	}
	override public bool GetTossBaby()
	{
		return false;
	}



	override public void Start(){;}

	override public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();


	
	}
}
