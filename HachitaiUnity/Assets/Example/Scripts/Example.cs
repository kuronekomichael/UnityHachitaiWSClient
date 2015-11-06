using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

	public GameObject BallRef;

	private Vector3   StartPosition;
	

	void Start () {


		StartPosition = BallRef.transform.position;


		float pow = 10.0f;

		// WebSocketメッセージが来た時の処理の登録
		// Tボタンが押された時
		EventManager.TriggerT += (sender, e) => {
			BallRef.GetComponent <Rigidbody> ().AddForce (Vector3.forward * pow);
		};
		// Eボタンが押された時
		EventManager.TriggerE += (sender, e) => {
			BallRef.GetComponent <Rigidbody> ().AddForce (Vector3.right   * pow);
		};
		// Aボタンが押された時
		EventManager.TriggerA += (sender, e) => {
			BallRef.GetComponent <Rigidbody> ().AddForce (Vector3.back    * pow);
		};
		// Mボタンが押された時
		EventManager.TriggerM += (sender, e) => {
			BallRef.GetComponent <Rigidbody> ().AddForce (Vector3.left    * pow);
		};


	}
	
	void Update () {

		if (Input.GetKeyUp ("r")) {
			Reset ();
		}

	}

	void Reset () {

		BallRef.GetComponent <Rigidbody> ().velocity        = Vector3.zero;
		BallRef.GetComponent <Rigidbody> ().angularVelocity = Vector3.zero;
		BallRef.transform.position = StartPosition;

	}
	
}
