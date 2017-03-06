using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnShip : MonoBehaviour {

	//The maximum allowed turning speed which can be adjusted in the editor
	public float maxTurnSpeed = 10f;

	//The turning speed
	private float turnSpeed;

	void Update () {
		//Get input and multiply it by the maximum allowed turning speed
		turnSpeed = Input.GetAxis ("Horizontal") * maxTurnSpeed;

		//Rotate the ship based on the input around the vector (0,0,-1)
		transform.Rotate (Vector3.back * turnSpeed * Time.deltaTime);
	}
}
