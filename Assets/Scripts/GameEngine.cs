using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {
	public static GameEngine Instance {get; private set;}
	public delegate void Handler();
	public event Handler funcOnTouchBegin;
	public event Handler funcOnTouchEnd;
	public event Handler funcOnButtonBegin;
	public event Handler funcOnButtonEnd;
	public event Handler funcOnBeat;

	public bool isTouch = false;
	public bool isButton = false;
	public bool isMatch = false;
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
	public void OnButtonBegin(){
		if(funcOnButtonBegin != null){
			funcOnButtonBegin();
		}
	}
	public void OnButtonEnd(){
		if(funcOnButtonEnd != null){
			funcOnButtonEnd();
		}
	}
	public void OnBeat(){
		if(funcOnBeat != null){
			funcOnBeat();
		}
	}
}
