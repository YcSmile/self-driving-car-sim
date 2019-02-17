using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using UnityStandardAssets.Vehicles.Car;
using System;
using System.Security.AccessControl;

using Google.Protobuf;
using LiDarMsg;

using SocketIO;

public class CommandServerMon : MonoBehaviour
{
	public CarRemoteControl CarRemoteControl;
	private SocketIOComponent _socket;
	private CarController _carController;
	private  SocketIOEvent soObj;

	// Use this for initialization
	void Start()
	{
		_socket = GameObject.Find("SocketIOMon").GetComponent<SocketIOComponent>();
		_socket.On("open", OnOpen);
		//_socket.On("manual", onManual);
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
		// EmitTelemetry (obj,null);
		//
		Debug.Log("is Manual");
	}
	void onClose(SocketIOEvent obj)
	{
		soObj = null;
		Debug.Log("Connet Dismisd");
	}


	// 发送数据
	void EmitTelemetry(SocketIOEvent obj,LiDarData hitPoint)
	{
		UnityMainThreadDispatcher.Instance().Enqueue(() =>
		{
			print("Attempting to Send...");
			// send only if it's not being manually driven
			// 手动模式下
			if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.S))) {
				// _socket.Emit("telemetry", new JSONObject());
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
				// 图像bytes转base64字符串
				// data["image"] = Convert.ToBase64String(CameraHelper.CaptureFrame(FrontFacingCamera));
				// 添加点云数据
				// float 转 bytes 
				data["Velodyne"] = Convert.ToBase64String(hitPoint.ToByteArray());

				_socket.Emit("telemetry", new JSONObject(data));
			}
		});
	}
}