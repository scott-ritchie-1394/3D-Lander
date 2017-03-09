﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrusters : MonoBehaviour {

	public float maxThrusterPower;       //maximum force applied by the thruster
	public float thrusterPowerIncrement; //controls how quickly the thruster reaches full thrust
	public float initialForce;           //the initial force, in the positive x direction applied to the ship
	public float thrusterDelay;          //the number of frames until the thruster kicks in at the start of the game
	public float maxFuel;
	public float fuelLeft;
	public float fuelUseRate;            //rate of fuel usage per second
	public float vel;
	public SpriteRenderer thrusterGlow;

	private Rigidbody ship;
	private float thrusterPower = 0;

	void Start () {
		ship = GetComponent<Rigidbody> ();  //finds the ship's rigidbody component
		ship.AddForce (initialForce, 0, 0); //adds initial force defined earlier
		fuelLeft = maxFuel;
	}

	void FixedUpdate () {
		if (fuelLeft > 0) {
			if (thrusterDelay <= 0) {
				if (Input.GetButton ("Jump")) {
					thrusterPower += thrusterPowerIncrement; //increments the thruster power as long as the space bar is pressed;
					fuelLeft -= fuelUseRate * Time.deltaTime;

					if (thrusterPower > maxThrusterPower)
						thrusterPower = maxThrusterPower;
				
					ship.AddForce (transform.up * thrusterPower);
					thrusterGlow.color = new Color(thrusterGlow.color.r, thrusterGlow.color.g, thrusterGlow.color.b, (thrusterPower / maxThrusterPower));
				} else {
					thrusterPower -= thrusterPowerIncrement; //decrements the thruster power as long as the space bar isn't pressed;

					thrusterGlow.color = new Color(thrusterGlow.color.r, thrusterGlow.color.g, thrusterGlow.color.b, 0f);

					if (thrusterPower < 0)
						thrusterPower = 0;
				}
			} else {
				thrusterDelay--;
			}
		} else {
			thrusterGlow.color = new Color(thrusterGlow.color.r, thrusterGlow.color.g, thrusterGlow.color.b, 0f);
		}
		vel = ship.velocity.magnitude;
	}
}
