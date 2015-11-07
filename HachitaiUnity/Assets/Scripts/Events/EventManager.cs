using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	// -----------------------------------------------------------------
	public static UnityEvent TriggerT;
	public static UnityEvent TriggerE;
	public static UnityEvent TriggerA;
	public static UnityEvent TriggerM;

	// -----------------------------------------------------------------
	void Awake () {

		if (TriggerT == null)
			TriggerT = new UnityEvent ();
		
		if (TriggerE == null)
			TriggerE = new UnityEvent ();
		
		if (TriggerA == null)
			TriggerA = new UnityEvent ();
		
		if (TriggerM == null)
			TriggerM = new UnityEvent ();


		TriggerT.AddListener (() => {
			Debug.Log ("TriggerT");
		});
		TriggerE.AddListener (() => {
			Debug.Log ("TriggerE");
		});
		TriggerA.AddListener (() => {
			Debug.Log ("TriggerA");
		});
		TriggerM.AddListener (() => {
			Debug.Log ("TriggerM");
		});

	}

	// -----------------------------------------------------------------
	void Update () {

		if (Input.GetKeyUp (KeyCode.T) && TriggerT != null) {
			TriggerT.Invoke ();
		}

		if (Input.GetKeyUp (KeyCode.E) && TriggerE != null) {
			TriggerE.Invoke ();
		}

		if (Input.GetKeyUp (KeyCode.A) && TriggerA != null) {
			TriggerA.Invoke ();
		}

		if (Input.GetKeyUp (KeyCode.M) && TriggerM != null) {
			TriggerM.Invoke ();
		}

	}
}
