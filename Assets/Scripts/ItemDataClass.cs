using UnityEngine;
using System;
using System.Collections;
[Serializable]
public class ItemDataClass
{

		public int[] itemsId = new int[GameState.numItems] ;
		public string[] description= new string[] {"Coins for the poor" ,"Food for the hungry", "A cat's arm", "A baby's arm", "A baby's leg", "A tentacle"};
		public int[] numPossessed = new int[GameState.numItems];
		public string[] itemsName = new string[] {"Coin" ,"Food", "Cat Arm", "Baby Arm", "Baby Leg", "Tentacle Arm"};
		public string[] itemsObjectName = new string[] { "Coin", "BabyFood","BabyArmCat", "BabyArmBaby", "BabyLegBaby", "BabyHeadBaby"};
		
		public string[] itemsGroupName = new string[] {"Collectible","Collectible","Arm", "Arm", "Leg", "Arm"};
		public string[] itemsTypeName = new string[] {"Coin","Food","Cat", "Baby", "Baby", "Baby"};
		public string[] itemsClassName = new string[] {"CollectibleAssets", "CollectibleAssets", "BabyParts", "BabyParts", "BabyParts", "BabyParts"};

		public ItemDataClass ()
		{
				for (int x=0; x < GameState.numItems; x++) {
						itemsId [x] = x;
						numPossessed[x] = 0;
				}
		}
}


/*public class ItemClass{
		public static int id=0;
		public static string itemName;
		public static GameObject mesh;
		public static string description;
		public static int numPossessed;
		public ItemClass(){
				id = GameState.idx;
				GameState.idx++;

				//	public ItemClass(int ide, string nam, GameObject mes, string des, int num){
			//	id=ide;
			//	name=nam;
			//	mesh=mes;
			//	description = des;
			//	numPossessed = num;
		}
}*/