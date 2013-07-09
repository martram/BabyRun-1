using UnityEngine;
using System.Collections;

public abstract class InputView
{
	public static InputView CreateView()
	{
		if(Application.platform==RuntimePlatform.Android) return new InputViewAndroid();
		else return new InputViewDesktop();
	}
	
	public abstract float GetStrafeAmt();
	public abstract bool GetLeftTurn();
	public abstract bool GetRightTurn();
	public abstract bool GetJump();
	public abstract bool GetDuck();
	
	public abstract bool GetTossBaby();
	
	public abstract void Start();
	
	public abstract void Update();
}
