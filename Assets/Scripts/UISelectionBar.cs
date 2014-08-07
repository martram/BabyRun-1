using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UISelectionBar : MonoBehaviour
{
	public static List<GameObject> selectedObject;
	public static List<GameObject>  unselectedObject;

	public GameObject selectionBar;


		// Use this for initialization
		void Start ()
		{

		}
	public void createDots(){
		removeDots();
		selectedObject= new List<GameObject> ();
		unselectedObject= new List<GameObject> ();
		selectionBar= new GameObject("SelectionBar");
		int i;
		int numLiveBaby=0;
		
		for(i=0;i<GameState.baby.Count;i++){
			GameObject dot = new GameObject("dot");
			print ("selectedObject exist?"+selectedObject.Count);
			selectedObject.Add (dot);
			
			
			//selectedObject = new GameObject("Selected");
			selectedObject[i].transform.parent = selectionBar.transform;
			selectedObject[i].AddComponent<GUITexture>();
			selectedObject[i].guiTexture.texture =  (Texture)Resources.Load ("GUI/selection_icon_selected", typeof(Texture));
		
			//unselectedObject = new GameObject("Unselected");
			GameObject unselectedDot = new GameObject();
			unselectedObject.Add (unselectedDot);
			unselectedObject[i].transform.parent = selectionBar.transform;
			unselectedObject[i].AddComponent<GUITexture>();
			unselectedObject[i].guiTexture.texture =  (Texture)Resources.Load ("GUI/selection_icon_unselected", typeof(Texture));
			selectedObject[i].transform.localScale = new Vector3 (0.04f,0.04f,1f);
			unselectedObject[i].transform.localScale = new Vector3 (0.04f,0.04f,1f);
			if(!GameState.baby[i].deadBaby){//*babynum live instead
		
				selectedObject[i].transform.localPosition = new Vector3 (0.5f+(i-GameState.getLiveBabyIndex())*0.1f, 0.8f, 0);
				unselectedObject[i].transform.localPosition = new Vector3 (0.5f+(i-GameState.getLiveBabyIndex())*0.1f, 0.8f, 0);
				numLiveBaby++;
			}

		}
		selectCurrent();

	}
	public void removeDots(){
		Destroy(selectionBar);
		int i;
		if(selectedObject!=null){
		for(i=0;i<selectedObject.Count;i++){
		
				Destroy(selectedObject[i]);
				Destroy(unselectedObject[i]);
			
		}
		}


	}
	public void selectCurrent(){
		int i;
		for(i=0;i<selectedObject.Count;i++){
			selectedObject[i].guiTexture.enabled=false;
			unselectedObject[i].guiTexture.enabled=true;
		}

		selectedObject[GameState.babyIndex].guiTexture.enabled=true;
		unselectedObject[GameState.babyIndex].guiTexture.enabled=false;
		
	}
	

}

