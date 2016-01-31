using UnityEngine;
using System.Collections;

public class WinLoose : MonoBehaviour {
	public GameObject win;
	void OnTriggerEnter(Collider collider){
		print("collide");
        win.SetActive(true);
        win.GetComponent<Animator>().Play("YouWinHead");
    }
}
