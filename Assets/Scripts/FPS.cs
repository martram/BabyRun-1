using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	public class FPS : MonoBehaviour
		{
				//FPS
				float updateInterval=0.5f;
				private float accum = 0.0f;
				private int frames = 0;
				private float timeleft;
				public GUIText guiTextFPS;
				public FPS ()
				{
				}
				void Start(){
						//fps
						timeleft = updateInterval;



				}
				void Update(){
						timeleft -= Time.deltaTime;
						accum += Time.timeScale / Time.deltaTime;
						++frames;
						if (timeleft <= 0) {
								guiTextFPS.text = "" + (accum / frames).ToString ("f2");
								timeleft = updateInterval;
								accum = 0;
								frames = 0;
						}

				}
		}
