using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour {
	SerialPort serialPort;
	float[] lastRot = { 0, 0, 0 };
	float xPos = 0;
	bool isTouch;
	bool isButton;
	float xPosStep = 0.07f;
	bool onceTouch = true;
	bool onceTouch2 = true;
	bool onceButton = true;
	bool onceButton2 = true;

	void Awake(){
		isTouch = false;
		isButton = false;
		serialPort = new SerialPort ("/dev/cu.usbmodem14121", 9600);
	}
	void Start () {
		serialPort.Open ();
		serialPort.ReadTimeout = 25;
//		serialPort.ReadBufferSize = 1024;
	}

	void Update () {
		if (serialPort.IsOpen) {
			try{
				string line = serialPort.ReadLine();
				string[] data = line.Split(',');
				if(int.Parse(data[0]) ==1){
					onceTouch2 = true;
					TouchBegin();
					GameEngine.Instance.isTouch = true;
				}else{
					onceTouch = true;
					TouchEnd();
					GameEngine.Instance.isTouch = false;
				}
				if(int.Parse(data[1]) ==1){
					onceButton2 = true;
					ButtonBegin();
					GameEngine.Instance.isButton = true;
				}else{
					onceButton = true;
					ButtonEnd();
					GameEngine.Instance.isButton = false;
				}
			}
			catch(System.Exception){
				throw;
			}
		}
	}
	void TouchBegin(){
		if (onceTouch) {
			GameEngine.Instance.OnTouchBegin ();
			onceTouch = false;
		}
	}
	void TouchEnd(){
		if (onceTouch2) {
			GameEngine.Instance.OnTouchEnd ();
			onceTouch2 = false;
		}
	}
	void ButtonBegin(){
		if (onceButton) {
			GameEngine.Instance.OnButtonBegin ();
			onceButton = false;
		}
	}
	void ButtonEnd(){
		if (onceButton2) {
			GameEngine.Instance.OnButtonEnd ();
			onceButton2 = false;
		}
	}
	public float Map( float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
