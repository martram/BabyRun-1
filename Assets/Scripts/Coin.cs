using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
		private const float speed = 30f;
	public int ID;
		private  AudioClip getCoinSound = new AudioClip();
	void Update()
	{
		//wrong axis?translate works
				//gameObject.transform.RotateAround(Vector3.up, speed * Time.deltaTime);

				//	transform.RotateAround(Vector3.up, speed * Time.deltaTime);
				//change spawn axis...
					transform.Rotate(Vector3.forward* speed * Time.deltaTime);
				//	transform.localRotation *=  Quaternion.AngleAxis(speed*Time.deltaTime, Vector3.forward);
			
	}
		//not called
	void OnCollisionEnter(Collision c)
	{			
	 
		print ("COIN oncollision called ******************");
	
				PlayGetCoin ();
	}
		public void PlayGetCoin(){
				gameObject.AddComponent<AudioSource> ();

				getCoinSound = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Sounds/get_coin", typeof(AudioClip)));

				audio.clip = getCoinSound;

			//	audio.Play ();
			
		}
}
