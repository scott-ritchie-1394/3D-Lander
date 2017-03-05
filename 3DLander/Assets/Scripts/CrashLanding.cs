//Will Dudenhoeffer
//CS 4173 Group Project 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrashLanding : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Do things on Collision
	void OnCollisionEnter (Collision Collider) {
		if (Collider.gameObject.name == "Ground") {
			print ("Boom.");
		} else if (Collider.gameObject.name == "LandingPad") {
			print ("Yay.");
		}
	}
}
