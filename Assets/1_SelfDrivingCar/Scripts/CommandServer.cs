using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SocketIO;
using UnityStandardAssets.Vehicles.Car;
using System;
using System.Security.AccessControl;

using Google.Protobuf;
using LiDarMsg;

public class CommandServer : MonoBehaviour
{
	public CarRemoteControl CarRemoteControl;
	public Camera FrontFacingCamera;
	private SocketIOComponent _socket;
	private CarController _carController;
	private  SocketIOEvent soObj;

	// Use this for initialization
	void Start()
	{
		_socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
		_socket.On("open", OnOpen);
		_socket.On("steer", OnSteer);
		_socket.On("manual", onManual);
		_socket.On("close", onClose);
		_carController = CarRemoteControl.GetComponent<CarController>();
		// 获得组件
		// 事件更新
		LidarSensor.HitPointsTrans += MsgUpdate;
		soObj = null;
		

	}

	public void MsgUpdate(float time, LiDarData hitPoint){
		if(soObj != null){
			Debug.Log("SendMesg");
			EmitTelemetry(soObj,hitPoint);
		}
	}
	// 添加事件

	// Update is called once per frame
	void Update()
	{

	}

	void OnOpen(SocketIOEvent obj)
	{
		Debug.Log("Connection Open");
		// EmitTelemetry(obj);
		soObj = obj;
	}

	// 
	void onManual(SocketIOEvent obj)
	{
		//EmitTelemetry (obj,null);
		CarRemoteControl.Acceleration = 0;
		//
		Debug.Log("is Manual");
	}
	void onClose(SocketIOEvent obj)
	{
		soObj = null;
		CarRemoteControl.SteeringAngle = 0;
		CarRemoteControl.Acceleration = 0;
		Debug.Log("Connet Dismisd");
	}

	// 接收到控制信息
	void OnSteer(SocketIOEvent obj)
	{
		JSONObject jsonObject = obj.data;
		//    print(float.Parse(jsonObject.GetField("steering_angle").str));
		CarRemoteControl.SteeringAngle = float.Parse(jsonObject.GetField("steering_angle").str);
		CarRemoteControl.Acceleration = float.Parse(jsonObject.GetField("throttle").str);
		// EmitTelemetry(obj);
	}

	// 发送数据
	void EmitTelemetry(SocketIOEvent obj,LiDarData hitPoint)
	{
		UnityMainThreadDispatcher.Instance().Enqueue(() =>
		{
			print("Attempting to Send...");
			// send only if it's not being manually driven
			// 手动模式下
			if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))) {
				_socket.Emit("telemetry", new JSONObject());
			}
			else {
				// Collect Data from the Car
				// 从车上收集信息
				Dictionary<string, string> data = new Dictionary<string, string>();
				// json数据
				// 角度
				data["steering_angle"] = _carController.CurrentSteerAngle.ToString("N4");
				data["throttle"] = _carController.AccelInput.ToString("N4");
				data["speed"] = _carController.CurrentSpeed.ToString("N4");
				
				data["Velodyne"] = Convert.ToBase64String(hitPoint.ToByteArray());

				_socket.Emit("telemetry", new JSONObject(data));
			}
		});
	}
}