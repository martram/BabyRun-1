using UnityEngine;    // For Debug.Log, etc.

using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections.Generic;

// === This is the info container class ===
[Serializable ()]
public class SaveSystem : ISerializable {

						// === Values ===
						// Edit these during gameplay
		public int numCoins = GameState.coins;
		public int numFood = GameState.food;
		public int procreatingTimer = GameState.procreatingTimer;
		public bool bProcreating = GameState.bProcreating;
		public bool bDoneProcreating = GameState.bDoneProcreating;

		public int highScore = GameState.currentHighScore;
		public List<BabyData> babyData = GameState.babyData;

		public  int babyIndex= GameState.babyIndex;
		public  int babyNum = GameState.babyNum;
		public  ItemDataClass itemData = GameState.itemData;


		//public List<Baby> babyList = GameState.baby;
	
						// === /Values ===

						// The default constructor. Included for when we call it during Save() and Load()
		public SaveSystem () {}

						// This constructor is called automatically by the parent class, ISerializable
						// We get to custom-implement the serialization process here
		public SaveSystem (SerializationInfo info, StreamingContext ctxt)
		{
				// Get the values from info and assign them to the appropriate properties. Make sure to cast each variable.
				// Do this for each var defined in the Values section above
				numCoins = (int)info.GetValue ("numCoins", typeof(int));
				numFood = (int)info.GetValue ("numFood", typeof(int));
				procreatingTimer =  (int)info.GetValue ("procreatingTimer", typeof(int));
				bProcreating =  (bool)info.GetValue ("bProcreating", typeof(bool));
				bDoneProcreating =  (bool)info.GetValue ("bDoneProcreating", typeof(bool));

				highScore = (int)info.GetValue ("highScore", typeof(int));
				babyData = (List<BabyData>)info.GetValue ("babyData", typeof(List<BabyData>));
				itemData =  (ItemDataClass)info.GetValue ("itemData", typeof(ItemDataClass));
				babyIndex= (int)info.GetValue ("babyIndex", typeof(int));
				babyNum = (int)info.GetValue ("babyNum", typeof(int));

			
		}

		// Required by the ISerializable class to be properly serialized. This is called automatically
		public void GetObjectData (SerializationInfo info, StreamingContext ctxt)
		{
				// Repeat this for each var defined in the Values section
				info.AddValue ("numCoins", (numCoins));
				info.AddValue ("numFood", (numFood));
				info.AddValue ("procreatingTimer", (procreatingTimer));
				info.AddValue ("bProcreating", (bProcreating));
				info.AddValue ("bDoneProcreating", (bDoneProcreating));
				info.AddValue ("highScore", highScore);
				info.AddValue ("itemData", itemData);
				info.AddValue ("babyData", babyData);
				info.AddValue ("babyIndex", babyIndex);
				info.AddValue ("babyNum", babyNum);
		}
}

				// === This is the class that will be accessed from scripts ===
				public class SaveLoad {

		public static SaveSystem data;
		public static string currentFilePath = "SaveData.mtx";    // Edit this for different save files
		public static Boolean bFileExist = false;

		// Call this to write data
		public static void Save ()  // Overloaded
		{
				Save (currentFilePath);
		}
		public static void Save (string filePath)
		{
				SaveSystem data = new SaveSystem ();
			
				Stream stream = File.Open (filePath, FileMode.Create);
				BinaryFormatter bformatter = new BinaryFormatter ();
				bformatter.Binder = new VersionDeserializationBinder (); 
				bformatter.Serialize (stream, data);
	
				stream.Close ();
		}

		// Call this to load from a file into "data"
		public static void Load ()  { Load(currentFilePath);  }   // Overloaded
		public static void Load (string filePath)
		{
				data = new SaveSystem ();
				//SaveSystem data = new SaveSystem ();
				if (System.IO.File.Exists(filePath)) {
						bFileExist = true;

				Stream stream = File.Open (filePath, FileMode.Open);
			


				
				BinaryFormatter bformatter = new BinaryFormatter ();
				bformatter.Binder = new VersionDeserializationBinder (); 
				data = (SaveSystem)bformatter.Deserialize (stream);

				stream.Close ();
				}
				// Now use "data" to access your Values
		}

}

				// === This is required to guarantee a fixed serialization assembly name, which Unity likes to randomize on each compile
				// Do not change this
				public sealed class VersionDeserializationBinder : SerializationBinder 
				{ 
						public override Type BindToType( string assemblyName, string typeName )
		{ 
				if (!string.IsNullOrEmpty (assemblyName) && !string.IsNullOrEmpty (typeName)) { 
						Type typeToDeserialize = null; 

						assemblyName = Assembly.GetExecutingAssembly ().FullName; 

						// The following line of code returns the type. 
						typeToDeserialize = Type.GetType (String.Format ("{0}, {1}", typeName, assemblyName)); 

						return typeToDeserialize; 
				} 

				return null; 
		}
}

