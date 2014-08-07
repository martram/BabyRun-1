using UnityEngine;
using System.Collections;
using System;
 
public class HUDbabyAvatar : MonoBehaviour
		{
		private Color[] damageColorArray= {new Color(0.1f,0.1f,0.1f,0.1f)
				,new Color(0.7f,0f,0f,0.5f)
				,new Color(0.6f,0.28f,0f,0.5f)
				,new Color(0.6f,0.38f,0f,0.5f)
				,new Color(0.6f,0.48f,0f,0.5f)
				,new Color(0.6f,0.6f,0f,0.5f)
				,new Color(0.5f,0.5f,0.5f,0.5f)};
		public GameObject GUIbabyAvatar;
		public GameObject GUIbabyHealth;
		public GameObject GUIbabyHead;
		public GameObject GUIbabyTorso;
		public GameObject GUIbabyArmLeft;
		public GameObject GUIbabyArmRight;
		public GameObject GUIbabyLegLeft;
		public GameObject GUIbabyLegRight;
		private float colorRange;
		private int colorRangeInt;

		private GUITexture GUIbabyHeadTexture = new GUITexture();

	public void createHUDavatar(){

		GUIbabyAvatar= new GameObject("GUIbabyAvatar");
		
		GUIbabyHead = new GameObject("GUIbabyHead");
		GUIbabyHead.transform.parent = GUIbabyAvatar.transform;
		GUIbabyHead.AddComponent<GUITexture>();
		GUIbabyHead.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarHead", typeof(Texture));
		GUIbabyHead.transform.localPosition = new Vector3 (0, 0.6f, 0);
		
		
		GUIbabyArmLeft = new GameObject("GUIbabyArmLeft");
		GUIbabyArmLeft.transform.parent = GUIbabyAvatar.transform;
		GUIbabyArmLeft.AddComponent<GUITexture>();
		GUIbabyArmLeft.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarArm", typeof(Texture));
		GUIbabyArmLeft.transform.localPosition = new Vector3 (-0.45f, 0.25f, 0);
		
		GUIbabyArmRight = new GameObject("GUIbabyArmRight");
		GUIbabyArmRight.transform.parent = GUIbabyAvatar.transform;
		GUIbabyArmRight.transform.localScale = new Vector3 (-1f, 1f, 1f);
		GUIbabyArmRight.AddComponent<GUITexture>();
		GUIbabyArmRight.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarArm", typeof(Texture));
		GUIbabyArmRight.transform.localPosition = new Vector3 (0.45f, 0.25f, 0);
		
		GUIbabyLegLeft = new GameObject("GUIbabyLegLeft");
		GUIbabyLegLeft.transform.parent = GUIbabyAvatar.transform;
		GUIbabyLegLeft.AddComponent<GUITexture>();
		GUIbabyLegLeft.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarLeg", typeof(Texture));
		GUIbabyLegLeft.transform.localPosition = new Vector3 (-0.35f, -0.6f, 0);
		
		GUIbabyLegRight = new GameObject("GUIbabyLegRight");
		GUIbabyLegRight.transform.parent = GUIbabyAvatar.transform;
		GUIbabyLegRight.transform.localScale = new Vector3 (-1f, 1f, 1f);
		GUIbabyLegRight.AddComponent<GUITexture>();
		GUIbabyLegRight.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarLeg", typeof(Texture));
		GUIbabyLegRight.transform.localPosition = new Vector3 (0.35f, -0.6f, 0);
		
		GUIbabyTorso = new GameObject("GUIbabyTorso");
		GUIbabyTorso.transform.parent = GUIbabyAvatar.transform;
		GUIbabyTorso.AddComponent<GUITexture>();
		GUIbabyTorso.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarTorso", typeof(Texture));
		GUIbabyTorso.transform.localPosition = new Vector3 (0f, -0.1f, 0);
		
		
		
		GUIbabyHealth = new GameObject("GUIbabyHealth");
		GUIbabyHealth.transform.parent = GUIbabyAvatar.transform;
		GUIbabyHealth.AddComponent<GUITexture>();
		GUIbabyHealth.guiTexture.texture =  (Texture)Resources.Load ("interfaceAssets/babyAvatarHealth", typeof(Texture));
		GUIbabyHealth.transform.localScale = new Vector3 (4f, 4f, 4f);
		
		
		GUIbabyAvatar.transform.localScale = new Vector3 (0.1f,0.1f,1f);
		GUIbabyAvatar.transform.localPosition = new Vector3 (0.85f, 0.15f, 1f);

	}
	
		public void setAvatarColor(string babyPart, float status){
					//	GameObject tempAsset=GUIbabyTorso;

		
		colorRange = ((float)status) * 0.06f;
		//print (colorRange + " colorRange before  "+status);
		if (colorRange < 0) {
			colorRange = 0;
        }
        /*else if (colorRange > 1f) {
            colorRange = 1f;
        }*/
		//print (colorRange + " colorRange after "+status);
		colorRangeInt = (int)Math.Round(colorRange);
        print(colorRangeInt+" test color " + colorRange);

		switch (babyPart) {
		case "Head":
			//		tempAsset = GUIbabyHead;
			GUIbabyHead.guiTexture.color = damageColorArray[colorRangeInt];
			break;
		case "ArmLeft":
			//			tempAsset = GUIbabyArmLeft;
			GUIbabyArmLeft.guiTexture.color = damageColorArray[colorRangeInt];
			break;
		case "ArmRight":
			//		tempAsset = GUIbabyArmRight;
			GUIbabyArmRight.guiTexture.color = damageColorArray[colorRangeInt];
			break;
		case "LegLeft":
			//			tempAsset = GUIbabyLegLeft;
			GUIbabyLegLeft.guiTexture.color = damageColorArray[colorRangeInt];
			break;
		case "LegRight":
			//		tempAsset = GUIbabyLegRight;
			GUIbabyLegRight.guiTexture.color = damageColorArray[colorRangeInt];
			break;
		case "Torso":
			//	tempAsset = GUIbabyTorso;
			GUIbabyTorso.guiTexture.color = damageColorArray[colorRangeInt];
			break;
			
		case "Health":
			//	tempAsset = GUIbabyHealth;
			GUIbabyHealth.guiTexture.color = damageColorArray[colorRangeInt];
			break;
			
		}
		
		//tempAsset.guiTexture.color = damageColorArray[colorRangeInt];
		/*	GUIbabyHead.guiTexture.color = damageColorArray[6];
				GUIbabyArmLeft.guiTexture.color = damageColorArray[1];
				GUIbabyArmRight.guiTexture.color = damageColorArray[2];
				GUIbabyLegLeft.guiTexture.color = damageColorArray[3];
				GUIbabyLegRight.guiTexture.color = damageColorArray[4];
				GUIbabyTorso.guiTexture.color = damageColorArray[5];*/



				}
		}


