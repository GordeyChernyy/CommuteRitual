using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	bool isOnce = true;
	public AudioSource touchWave;
	// Use this for initialization
	void Start () {
		GameEngine.Instance.funcOnTouchBegin += Play;
		GameEngine.Instance.funcOnTouchEnd += Stop;
	}
	public void Play(){
		touchWave.Play ();
	}
	public void Stop(){
		touchWave.Stop ();
	}
}
