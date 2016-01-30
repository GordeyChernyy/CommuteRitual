using UnityEngine;
using System.Collections;

public class BeatDetect : MonoBehaviour {
	bool isRecord = false;
	int[] targetBeat;
	int[] usersBeat;
	public int bpm;
	public int bpmCount;
	public float secPerCount;
	int counter = 0;
	int beatCount = 0;
	public GameObject beatObject;
	public GameObject canvas;
	float canvasW = 800;
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
		isRecord = true;
		print("isRecord" + isRecord);
	}
	public void CreateBeatObj(){
		float size = canvasW*counter/secPerCount;
		GameObject obj = Instantiate(beatObject, new Vector3(size, 0, 0) );
		obj.transform.SetParent(canvas.transform);
		beatObjects.Add(obj);
	}
	// Update is called once per frame
	private IEnumerator Beat()
	{
   		while(true)
    	{
        	yield return new WaitForSeconds(secPerCount); // wait half a second
       		NewBeat();
        	print("tunc!");
  		 }
	}
	void NewBeat(){
		counter = 0;
		isRecord = false;
		print(targetBeat);
	}
	void Update(){
		print("counter = "+counter);
		counter++;
		if(isRecord){
			if(GameEngine.Instance.isTouch){
				targetBeat[counter] = 1;
			}else{
				targetBeat[counter] = 0;
			}
		}
	}
}
