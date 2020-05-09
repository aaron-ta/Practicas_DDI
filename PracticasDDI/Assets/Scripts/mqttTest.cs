using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

namespace MqttTest
{
	public class mqttTest : MonoBehaviour {
		public string brokerIpAddress = "192.168.1.69";
		public int brokerPort = 1883;
		public string temperatureTopic = "casa/sala/temperatura";
		public string lightTopic = "casa/sala/luz";
		private MqttClient client;
		public Text displayText;
		public GameObject directionalLight;
		public Slider slider;
		string lastMessage;
		volatile bool lightState = false;
		// Use this for initialization
		void Start () {
			directionalLight = GameObject.Find("Directional Light");
			// create client instance 
			client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
			
			// register to message received 
			client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
			
			string clientId = Guid.NewGuid().ToString(); 
			client.Connect(clientId); 
			
			// subscribe to the topic "/home/temperature" with QoS 2 
			client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
			client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  

		}
		void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
		{ 
			Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
			if(e.Topic.Equals(lightTopic))
			{
				if(lastMessage.Equals("lights on"))
				{
					lightState = true;
				}
				else if(lastMessage.Equals("lights off"))
				{
					lightState = false;
				}
			}
			if(e.Topic.Equals(temperatureTopic))
			{
				if(lastMessage.Equals("check temperature"))
				{
					publish(temperatureTopic, "Current temperature: " + slider.value.ToString() + " degrees");
				}
			}
		}

		public void publish(string topic, string message){
			Debug.Log("Publish: " + topic + "~ " + message);
			client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
		}

		void Update()
		{
			displayText.text = lastMessage;
			if (lightState != directionalLight.activeSelf)
				directionalLight.SetActive(lightState);
		}

		void OnGUI(){
			if ( GUI.Button (new Rect (20,40,80,20), "Level 1")) {
				Debug.Log("sending...");
				client.Publish("casa/sala/luz", System.Text.Encoding.UTF8.GetBytes("lights on"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
				Debug.Log("sent");
			}
		}

		void OnApplicationQuit()
		{
			client.Disconnect();
		}
	}
}