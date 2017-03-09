//Will Dudenhoeffer
//CS 4173 Group Project 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrashLanding : MonoBehaviour {
	//public bools reporting landing state
	public bool goodLanding = false;
	public bool badLanding = false;
	public float safeVel;

	bool hasExploded = false;
	bool hasLanded = false;

	//Initialize GameObjects
	Rigidbody EyeRigidBody;
	GameObject ShipL;
	GameObject ShipR;
	GameObject ShipF;
	GameObject Cockpit;
	GameObject Eye;
	GameObject ShipRC;
	GameObject ShipLC;
	public ParticleSystem Boom;
	GameObject Ship;
	GameObject Glow;

	// Use this for initialization
	void Awake () {
		//find all needed gameObjects
		Ship = GameObject.Find("Ship");
		ShipL = GameObject.Find("SaucerL");
		ShipR = GameObject.Find("SaucerR");
		ShipF = GameObject.Find("SaucerF");
		Cockpit = GameObject.Find("Cockpit");
		Eye = GameObject.Find("EyeBall");
		ShipRC = GameObject.Find ("SaucerR/Sphere");
		ShipLC = GameObject.Find ("SaucerL/Sphere");
		Glow = GameObject.Find ("Glow");
 	}

	
	// Do things on Collision
	void OnCollisionEnter (Collision Collider) { //Crash and Burn
		bool safeAngle = ((transform.rotation.z > -30)&&(transform.rotation.z < 30));
		bool safeSpeed = (Collider.relativeVelocity.magnitude < safeVel);

		if ((Collider.gameObject.tag == "Pad") && safeAngle && safeSpeed) {
			//print ("Yay.");
			Destroy (Glow);
			goodLanding = true;
			hasLanded = true;
		} else if(!hasLanded) {
			//print ("Boom.");
			badLanding = true;
			//Break Cockpit and Legs, as well as ship 'core'
			Destroy (Cockpit);
			Destroy (ShipF);
			Destroy (Glow);
			//Enable Physics on Ship halves and Eye
			Rigidbody ShipLRigidBody = ShipL.AddComponent<Rigidbody>();
			Rigidbody ShipRRigidBody = ShipR.AddComponent<Rigidbody>();
			EyeRigidBody = Eye.AddComponent<Rigidbody>();
			//EXPLOSIONS
			if (!hasExploded) {
				Boom.Play ();
				hasExploded = true;
			}
			//Stop EyeBob
			Object EyeScript = Eye.GetComponent("EyeBob");
			Destroy (EyeScript);
			//shoot eye up
			EyeRigidBody = Eye.GetComponent<Rigidbody>();
			EyeRigidBody.AddForce (0, 100, 0);
			//Pop Eye
			//bloodSpatter
			//Fade out color and transparency of Ship Bits
			iTween.FadeTo(ShipRC, 0.0f, 1.0f);
			iTween.FadeTo(ShipLC, 0.0f, 1.0f);
		
		}
	}

	void destroy() {
		Destroy (gameObject);
	}
}
