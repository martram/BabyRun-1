using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonMenu : MonoBehaviour{
		public ButtonMenu ()	{

		}
		void Start(){

				this.gameObject.transform.localScale = new Vector3 (100f, 50f, 1f);	

		}
		void OnHover(){

				this.gameObject.transform.localScale = new Vector3 (100f, 50f, 1f);	

		}
				void OnClick(){

				this.gameObject.transform.localScale = new Vector3 (100f, 50f, 1f);	
				switch (this.tag) {
				case "Run":
						GameState.swapCamera ();
						GameState.resetGameScene ();
						break;
				case "GetMoreBabies":
						print ("GetMoreBabies");
						MainMenu.bInGetMoreBabies = true;
						break;
				case "Cemetery":
						print ("Cemetery");
						MainMenu.bInCemetery = true;
						break;
				case "CemeteryRevive":
						if (GameState.baby [GameState.babyIndex].deadBaby) {
								if (GameState.coins >= 0) {
										//hard cash?
										GameState.deadBabyNum--;
										GameState.coins -= 0;
										GameState.HUDinstance.UpdateCoins ();
										GameState.baby [GameState.babyIndex].reviveBaby ();
										GameState.showBabiesMainMenu ();
								} else {
										print ("Not enough coins!");
								}
						} else {
								print ("No dead baby to revive!");
						}
						break;
				case "CemeteryBack":
						MainMenu.bInCemetery = false;
						break;
							
				case "BuySuff":
						GameState.showItemsMainMenu ();
						MainMenu.bInBuySuff = true;
						break;
				case "BuySuffBack":
						GameState.hideItemsMainMenu ();

						MainMenu.bInBuySuff = false;
						break;
					
				case "Procreate":
						print ("GameState.bProcreating");
						GameState.bProcreating = true;
						break;
				case "ProcreateBack":
						MainMenu.bInGetMoreBabies = false;
						break;
				case "ProcreateSubmit":
						break;
				case "Quit":
						print ("quit and save");
						GameState.saveBabiesToData ();
						Application.Quit ();
						break;


				}

		}
}


