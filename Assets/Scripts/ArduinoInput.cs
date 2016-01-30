using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour {
	SerialPort serialPort;
	float[] lastRot = { 0, 0, 0 };
	float xPos = 0;
	float xPosStep = 0.07f;

	void Awake(){
		serialPort = new SerialPort ("/dev/cu.usbmodem14121", 9600);
	}
	// Use this for initialization
	void Start () {
		serialPort.Open ();
		serialPort.ReadTimeout = 25;
		serialPort.ReadBufferSize = 1024;
//		serialPort.NewLine = "\r\n";
	}
	
	// Update is called once per frame
	void Update () {
		if (serialPort.IsOpen) {
			try{
				string line = serialPort.ReadLine();
				string[] data = line.Split(',');
				float x = int.Parse(data[0]);
				float y = int.Parse(data[1]);
				print(line);
				if(x==1){
					xPos += xPosStep; 
				}
//				transform.Rotate(
//					x-lastRot[0], 
//					y-lastRot[1], 
//					0, 
//					Space.Self
//				);
//				lastRot[0] = x;  //Set new values to last time values for the next loop
//				lastRot[1] = y;
			}
			catch(System.Exception){
				throw;
			}
			float a;
//			print (serialPort.ReadByte ());
		}
		if(xPos>7){
			xPos = -7;
		}
		transform.position = new Vector3(xPos, 0, 0);
	}
	public float Map( float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
