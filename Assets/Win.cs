using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public GameObject win;
	public GameObject man;
	public GameObject trainGone;
	void Start(){
		GameEngine.Instance.funcOnButtonBegin += OnResetGame;
	}
	void OnTriggerEnter(Collider collider){
		print("collide");
        win.SetActive(true);
        man.SetActive(false);
        win.GetComponent<Animator>().Play("YouWinHead");
        trainGone.GetComponent<Animator>().Play("TrainGone");
    }
    public void OnResetGame(){
    	win.SetActive(false);
    	man.SetActive(true);
    	trainGone.GetComponent<Animator>().Play("TrainIdle");
    }
}
