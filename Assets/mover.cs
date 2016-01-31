using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public float force;
	public float move;
	float xPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print("match = "+ GameEngine.Instance.isMatch);
		if(GameEngine.Instance.isMatch){
			xPos += move;
		}
		xPos -= force;
		transform.localPosition = new Vector3(xPos, 0, 0);
	}
}
