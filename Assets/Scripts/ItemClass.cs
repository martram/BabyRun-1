using System;
using UnityEngine;
public class ItemClass
{

		public  int itemId;
		public  string itemName;
		public  GameObject meshObject;
		public  string description;
		public  int numPossessed;

		public ItemClass ()
		{

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