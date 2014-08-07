using UnityEngine;
using System.Collections;
using System;
 
public class Alert : MonoBehaviour
{

		public GameObject signPrevious;
		public GameObject signNext;
		public GameObject signCurrent;
		public GameObject signRunning;

		public void createAlertPrevious(){
				signPrevious = new GameObject ();
				signPrevious.name="AlertSignPrevious";

				signPrevious.AddComponent<GUITexture>();
				signPrevious.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/alert_sign", typeof(Texture));
				signPrevious.transform.localScale = new Vector3 (0.08f,0.08f,1f);
				signPrevious.transform.localPosition = new Vector3(0.2f,0.7f,0f);
		}
		public void createAlertNext(){
				signNext = new GameObject ();
				signNext.name="AlertSignNext";

				signNext.AddComponent<GUITexture>();
				signNext.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/alert_sign", typeof(Texture));
				signNext.transform.localScale = new Vector3 (0.08f,0.08f,1f);
				signNext.transform.localPosition = new Vector3(0.54f,0.7f,0f);
		}

		public void createAlertCurrent(){
				signCurrent = new GameObject ();
				signCurrent.name="AlertSignCurrent";

				signCurrent.AddComponent<GUITexture>();
				signCurrent.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/alert_sign", typeof(Texture));
				signCurrent.transform.localScale = new Vector3 (0.08f,0.08f,1f);
				signCurrent.transform.localPosition = new Vector3(0.32f,0.7f,0f);
		}

		public void createAlertRunning(){
				signRunning = new GameObject ();
				signRunning.name="AlertSignRunning";

				signRunning.AddComponent<GUITexture>();
				signRunning.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/alert_sign", typeof(Texture));
				signRunning.transform.localScale = new Vector3 (0.08f,0.08f,1f);
				signRunning.transform.localPosition = new Vector3(0.8f,0.1f,0f);
		}
}


