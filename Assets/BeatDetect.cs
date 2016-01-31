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
	int recordedCount = 0;
	int matchedCount = 0;
	int userRecordedCount = 0;
	int buttonLap = 0;
	float canvasW = 5;
	ArrayList beatObjects = new ArrayList();

	bool once = true;
	void Awake(){
		targetBeat = new int[300];
		usersBeat = new int[300];
	}

	void Start () {
		StartCoroutine("Beat");
		GameEngine.Instance.funcOnButtonBegin += SetRecord;
		GameEngine.Instance.funcOnTouchBegin += CreateBeatObj;
		CalculateMsPerCount();
		// print("msPerCount "+secPerCount);
	}
	public void CalculateMsPerCount(){
		secPerCount = 60.0f*bpmCount/bpm;
	}
	public void SetRecord(){
		foreach(GameObject g in beatObjects){
			Destroy(g);
		}
		clearRecordData();
		clearUserData();
		recordedCount = 0;
		userRecordedCount = 0;
		matchedCount = 0;
		if(buttonLap == 1){buttonLap = 0;}
		isRecord = true;
		// print("isRecord" + isRecord);
	}
	void clearRecordData(){
		for ( int i = 0; i < targetBeat.Length; i++)
		{
		   targetBeat[i] = 0;
		}
	}
	void clearUserData(){
		for ( int i = 0; i < usersBeat.Length; i++)
		{
		   usersBeat[i] = 0;
		}

	}
	public void CreateBeatObj(){
		if(isRecord){
			float size = Map(counter, 0, 169, 0, 15);
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
        	GameEngine.Instance.OnBeat();
       		NewBeat();
			rythm.Play ();
  		 }
	}
	public float Map( float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
	void NewBeat(){
		// print("recordedCount = "+recordedCount);
		// print("userRecordedCount = "+userRecordedCount);
		// print("matchedCount = "+matchedCount);
		matchedCount = 0;
		clearUserData();
		userRecordedCount = 0;
		counter = 0;
		if(buttonLap == 1 && isRecord){
			buttonLap = 0;
			isRecord = false;
		}
		if(isRecord){
			buttonLap ++;
		}
	}
	void Update(){
		// print("matchedCount = "+matchedCount);
		counter++;
		float size = Map(counter, 0, 169, 0, 15);
		arrow.transform.localPosition = new Vector3 (size, 0, 0);
		if(isRecord){ // record
			if(GameEngine.Instance.isTouch){
				targetBeat[counter] = 1;
				recordedCount++;
			}else{
				targetBeat[counter] = 0;
			}
		} else if(recordedCount>0){ // user data
			if(GameEngine.Instance.isTouch){
				usersBeat[counter] = 1;
				if(usersBeat[counter] == targetBeat[counter]){
					matchedCount++;
					GameEngine.Instance.isMatch = true;
				} else{
					GameEngine.Instance.isMatch = false;
				}
				userRecordedCount++;
			}else{
				usersBeat[counter] = 0;
				GameEngine.Instance.isMatch = false;
			}
		}
	}
}
