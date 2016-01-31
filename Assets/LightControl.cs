using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {
	// Use this for initialization
	public Animator animator;

	void Start () {
		animator = gameObject.GetComponent<Animator>();
		GameEngine.Instance.funcOnTouchBegin += TurnOn;
		GameEngine.Instance.funcOnTouchEnd += TurnOff;
	}
	
	public void TurnOn() {
		animator.Play("TrainLightOn");
	}
	public void TurnOff () {
		animator.Play("TrainLightOff");
	}
}
