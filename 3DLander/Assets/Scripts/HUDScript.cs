using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	public ShipThrusters shipThrusters;
	public Text fuelText;
	public Text velocityText;
	private float maxFuel;
	private float fuelLeft;
	private float velocity;
	
	// Use this for initialization
	void Start () {
		maxFuel = shipThrusters.maxFuel;
	}
	
	// Update is called once per frame
	void Update () {
		fuelLeft = shipThrusters.fuelLeft;
		fuelText.text = string.Format ("Fuel: {0}%", System.Math.Round((fuelLeft/maxFuel * 100f),1));
		velocity = shipThrusters.vel;
		velocityText.text = string.Format ("Velocity: {0}", System.Math.Round(velocity,2));
	}
}
