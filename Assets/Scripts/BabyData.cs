using System;

[Serializable()]
		public class BabyData
		{



		//serializable baby data
		public bool bIsItABoy = false;
		public int race = 0;
		public bool bCat=false;
		public System.DateTime timeOfBirth;
		public string babyName;
		public int babyID;
		public bool deadBaby = false;
		public float statusHealth=100;
		public float statusHead=100;
		public float statusLegLeft=100;
		public float statusLegRight=100;
		public float statusArmLeft=100;
		public float statusArmRight=100;
		public float statusTorso=100;
		public static float maxHunger = 1000;
		public float hunger=maxHunger;
		public static float maxSleepiness=1000;
		public float sleepiness=maxSleepiness;
		public static float maxHappiness=1000;
		public float happiness=maxHappiness;
		public float poop=0;
		public int foodEatenCounter=0;
		public float diseaseCounter=0;
		public string armLeftPart;
		public string armRightPart;
		public string legLeftPart;
		public string legRightPart;
		public string headPart;
		public string torsoPart;
		public bool bArmLeftAttached;
		public bool bArmRightAttached;
		public bool bLegLeftAttached;
		public bool bLegRightAttached;
		public bool bHeadAttached;

				public BabyData ()
				{

				}
		}
