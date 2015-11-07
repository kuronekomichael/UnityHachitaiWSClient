using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Net;

public class WebSocketClient : MonoBehaviour {
	
	// -----------------------------------------------------------------
	public string WSAddress = "ws://52.192.81.231:3000/";
	public int    Room      = 0;

	WebSocket ws;

	Queue  messageQueue;
	
	// -----------------------------------------------------------------
	void Start () {
		
		Connect ();

		messageQueue = Queue.Synchronized (new Queue ());
		
	}

	// -----------------------------------------------------------------
	void Update () {

		if (messageQueue.Count > 0) {
			lock (messageQueue.SyncRoot) {
				try {
					string mes = (string) messageQueue.Dequeue ();

					ParseMessage (mes);
					
				} catch (System.Exception e) {
					Debug.Log (e.ToString ());
				}
			}
		}
	}

	// -----------------------------------------------------------------
	/// <summary>
	///
	/// </summary>
	void OnApplicationQuit () {
		Disconnect ();
	}

	// -----------------------------------------------------------------
	/// <summary>
	///
	/// </summary>
	void Connect () {
		
		ws = new WebSocket (WSAddress);
		
		ws.OnOpen += (sender, e) => {
			Debug.Log ("<color=lime>WebSocket Open</color>");
		};
		
		ws.OnMessage += (sender, e) => {

			lock (messageQueue.SyncRoot) {
				try {
					messageQueue.Enqueue (e.Data.ToString ());
				} catch (System.Exception ex) {
					Debug.Log (ex.ToString ());
				}
			}

			//Debug.Log ("<color=cyan>WebSocket Message Type: " + e.Type + ", Data: " + e.Data + "</color>");
		};
		
		ws.OnError += (sender, e) => {
			Debug.Log ("<color=red>WebSocket Error Message: " + e.Message + "</color>");
		};
		
		ws.OnClose += (sender, e) => {
			Debug.Log ("<color=orange>WebSocket Close</color>");
		};
		
		ws.Connect ();
		
	}

	// -----------------------------------------------------------------
	/// <summary>
	///
	/// </summary>
	void Disconnect () {
		if (ws.IsAlive) {
			ws.Close ();
		}
		ws = null;
	}

	// -----------------------------------------------------------------
	/// <summary>
	///
	/// </summary>
	/// <param name="message"></param>
	void Send (string message) {
		ws.Send (message);
	}

	// -----------------------------------------------------------------
	/// <summary>
	/// WebSockeckメッセージをパースし、イベントを発生させます
	/// </summary>
	/// <param name="mess">WebSocketメッセージ</param>
	void ParseMessage (string mess) {

		// 数字,数字という文字列であるか
		if (System.Text.RegularExpressions.Regex.IsMatch (
			mess, 
			@"^(-1|([1-9]?[0-9])),([0-3])$",
			System.Text.RegularExpressions.RegexOptions.ECMAScript)
		) {

			string[] str = System.Text.RegularExpressions.Regex.Split (mess, ",");

			// Roomナンバーと一致したら
			if (str [0] == Room.ToString ("0")) {

				if (str [1] == "0" && EventManager.TriggerT != null) {
					EventManager.TriggerT.Invoke ();
				}

				if (str [1] == "1" && EventManager.TriggerE != null) {
					EventManager.TriggerE.Invoke ();
				}

				if (str [1] == "2" && EventManager.TriggerA != null) {
					EventManager.TriggerA.Invoke ();
				}

				if (str [1] == "3" && EventManager.TriggerM != null) {
					EventManager.TriggerM.Invoke ();
				}
			}

		} else {
			//Debug.Log ("Invalid Message.");
		}

	}
	
}