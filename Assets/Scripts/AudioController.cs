using UnityEngine;
using System.Collections;


public class AudioController : MonoBehaviour
{
		private  AudioClip menuMusic = new AudioClip();
		private  AudioClip gameMusic = new AudioClip();
		private  AudioClip shopMusic = new AudioClip();
		private  AudioClip carRunning = new AudioClip();
		private  AudioClip carHonking = new AudioClip();
		private  AudioClip getCoinSound = new AudioClip();



		public AudioController ()
		{


		}
		public void init(){
				gameMusic = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Music/music_game", typeof(AudioClip)));
				menuMusic = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Music/music_menu", typeof(AudioClip)));
				shopMusic = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Music/music_game", typeof(AudioClip)));
				getCoinSound = (AudioClip)AudioClip.Instantiate (Resources.Load ("Audio/Sounds/get_coin", typeof(AudioClip)));

		
		
		}
		public void playGameMusic(){

				//prog?
				audio.clip = gameMusic;
				audio.Play ();
		}
			
		public  void playMenuMusic(){

				//funk-jazzy-electro
		 		audio.clip = menuMusic;
				audio.Play ();
			//	GameState.playMenuMusic (MenuMusic);
				//audio source is localized..vector3
				//	AudioSource.PlayClipAtPoint(MenuMusic,Vector3.zero);


		}

		public void playShopMusic(){
				//classical-elevator
				audio.clip = shopMusic;
				audio.Play ();

		}

	
		public void playGetCoin(){


				audio.clip = getCoinSound;

				audio.Play ();
		}
}


