using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public GameObject Ship;
	private Vector3 offset;
	private float horizRotate= 0.0f;
	private float vertRotate = 0.0f;


	// Use this for initialization
	void Start () {
		//Gets the vector offset from the intial position of the camera relative to the ship
		offset = transform.position - Ship.transform.position;

	}

	// Update is called once per frame
	void Update () {
		transform.position = Ship.transform.position + offset;
		horizRotate =  1.0f * Input.GetAxis ("Mouse X");
		vertRotate = 1.0f * Input.GetAxis ("Mouse Y");
		if (horizRotate > 4.0f)
			horizRotate = 4.0f;
		if (horizRotate < -4.0f)
			horizRotate = -4.0f;
		if (vertRotate > 4.0f)
			vertRotate = 4.0f;
		if (vertRotate < -4.0f)
			vertRotate = -4.0f;
		print (horizRotate);

		//Rotate around the ship, fairly easy stuff
		transform.RotateAround (Ship.transform.position, Ship.transform.up,-horizRotate * 20 *Time.deltaTime);
		transform.RotateAround (Ship.transform.position, Ship.transform.right,vertRotate * 20 * Time.deltaTime);

		//Updates the new offset after rotation
		offset = transform.position - Ship.transform.position;
	}
}
