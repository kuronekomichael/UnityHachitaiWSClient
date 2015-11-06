using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventManager : SingletonMonoBehaviour <EventManager> {

	// -----------------------------------------------------------------
	public int   Room = -1;

	public static event EventHandler TriggerT;
	public static event EventHandler TriggerE;
	public static event EventHandler TriggerA;
	public static event EventHandler TriggerM;

	// -----------------------------------------------------------------
	public static void OnTriggerT () {
		if (TriggerT != null) {
			TriggerT (null, EventArgs.Empty);
		}
	}

	public static void OnTriggerE () {
		if (TriggerE != null) {
			TriggerE (null, EventArgs.Empty);
		}
	}

	public static void OnTriggerA () {
		if (TriggerA != null) {
			TriggerA (null, EventArgs.Empty);
		}
	}

	public static void OnTriggerM () {
		if (TriggerM != null) {
			TriggerM (null, EventArgs.Empty);
		}
	}

	// -----------------------------------------------------------------
	public void Awake () {
		
		if (this != Instance) {
			Destroy (this);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
		
	}

	// -----------------------------------------------------------------
	void Start () {

		TriggerT += (sender, e) => {
			Debug.Log ("TriggerT");
		};
		TriggerE += (sender, e) => {
			Debug.Log ("TriggerE");
		};
		TriggerA += (sender, e) => {
			Debug.Log ("TriggerA");
		};
		TriggerM += (sender, e) => {
			Debug.Log ("TriggerM");
		};

	}

	// -----------------------------------------------------------------
	void Update () {

		if (Input.GetKeyUp (KeyCode.T)) {
			TriggerT (this, EventArgs.Empty);
		}

		if (Input.GetKeyUp (KeyCode.E)) {
			TriggerE (this, EventArgs.Empty);
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			TriggerA (this, EventArgs.Empty);
		}

		if (Input.GetKeyUp (KeyCode.M)) {
			TriggerM (this, EventArgs.Empty);
		}

	}
}
