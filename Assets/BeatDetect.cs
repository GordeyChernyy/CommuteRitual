using UnityEngine;
using System.Collections;

public class BeatDetect : MonoBehaviour {
	bool isRecord = false;
	public AudioSource rythm;
	int[] targetBeat;
	int[] usersBeat;
	public int bpm;
	public int bpmCount;
	public float secPerCount;
	int counter = 0;
	int beatCount = 0;
	public GameObject beatObject;
	public GameObject canvas;
	public GameObject arrow;
	int buttonLap = 0;
	float canvasW = 5;
	ArrayList beatObjects = new ArrayList();

	bool once = true;
	void Awake(){
		targetBeat = new int[500];
		usersBeat = new int[500];
	}

	void Start () {
		StartCoroutine("Beat");
		GameEngine.Instance.funcOnButtonBegin += SetRecord;
		GameEngine.Instance.funcOnTouchBegin += CreateBeatObj;
		CalculateMsPerCount();
		print("msPerCount "+secPerCount);
	}
	public void CalculateMsPerCount(){
		secPerCount = 60.0f*bpmCount/bpm;
	}
	public void SetRecord(){
		foreach(GameObject g in beatObjects){
			Destroy(g);
		}
		isRecord = true;
		print("isRecord" + isRecord);
	}
	public void CreateBeatObj(){
		if(isRecord){
			float size = Map(counter, 0, 85, 0, 20);
			GameObject obj = Instantiate(beatObject);
			obj.transform.SetParent(canvas.transform);
			obj.transform.localPosition = new Vector3(size, 0, 0);
			beatObjects.Add(obj);
		}
	}
	// Update is called once per frame
	private IEnumerator Beat()
	{
   		while(true)
    	{
        	yield return new WaitForSeconds(secPerCount); // wait half a second
       		NewBeat();
			rythm.Play ();
        	print("tunc!");
  		 }
	}
	public float Map( float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
	void NewBeat(){
		counter = 0;

		if(buttonLap == 1 && isRecord){
			buttonLap = 0;
			isRecord = false;
		}
		if(isRecord){
			buttonLap ++;
		}
		print(targetBeat);
	}
	void Update(){
		print("counter = "+counter);
		counter++;
		float size = Map(counter, 0, 85, 0, 20);
		arrow.transform.localPosition = new Vector3 (size, 0, 0);
		if(isRecord){
			if(GameEngine.Instance.isTouch){
				targetBeat[counter] = 1;
			}else{
				targetBeat[counter] = 0;
			}
		}
	}
}
