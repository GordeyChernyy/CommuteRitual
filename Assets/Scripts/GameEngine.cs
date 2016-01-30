using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {
	public static GameEngine Instance {get; private set;}
	public delegate void Handler();
	public event Handler funcOnTouchBegin;
	public event Handler funcOnTouchEnd;

	void Awake () {
		Instance = this;
	}
	public void OnTouchBegin(){
		if(funcOnTouchBegin != null){
			funcOnTouchBegin();
		}
	}
	public void OnTouchEnd(){
		if(funcOnTouchEnd != null){
			funcOnTouchEnd();
		}
	}
}
