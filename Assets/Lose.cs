using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {
	public GameObject loose;
	public GameObject trainGone;
	void Start(){
		GameEngine.Instance.funcOnButtonBegin += OnResetGame;
	}
	void OnTriggerEnter(Collider collider){
		print("collide");
        loose.SetActive(true);
        loose.GetComponent<Animator>().Play("YouLoseAnimation");
        trainGone.GetComponent<Animator>().Play("TrainLose");
    }
    public void OnResetGame(){
    	loose.SetActive(false);
    }
}
