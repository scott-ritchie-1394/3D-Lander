using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HUDScript : MonoBehaviour {

	public ShipThrusters shipThrusters;
	public Text fuelText;
	public Text velocityText;
	public CrashLanding crashLanding;
	public Text badLandingText;
	public Text goodLandingText;
	public Button restartButton;
	public Button quitButton;
	private GameObject restartButtonGo;
	private GameObject quitButtonGo;
	private float maxFuel;
	private float fuelLeft;
	private float velocity;
	private bool goodLanding;
	private bool badLanding;
	private bool hasSetLandingText = false;
	private float moveButtonAmount = 1000f;
	
	// Use this for initialization
	void Start () {
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(StartGame);
		Button btn2 = quitButton.GetComponent<Button>();
		btn2.onClick.AddListener(QuitGame);
		maxFuel = shipThrusters.maxFuel;
		restartButtonGo = GameObject.Find("restartButton");
		quitButtonGo = GameObject.Find("quitButton");
		MoveButtonUp(restartButtonGo);
		MoveButtonUp(quitButtonGo);
	}
	
	// Update is called once per frame
	void Update () {
		goodLanding = crashLanding.goodLanding;
		badLanding = crashLanding.badLanding;
		fuelLeft = shipThrusters.fuelLeft;
		fuelText.text = string.Format ("Fuel: {0}%", System.Math.Round((fuelLeft/maxFuel * 100f),0));
		velocity = shipThrusters.vel;
		if(goodLanding || badLanding)
			velocity = 0f;
		velocityText.text = string.Format ("Velocity: {0}", System.Math.Round(velocity,2));
		
		if(hasSetLandingText == false && goodLanding == true)
		{
			MoveButtonDown(restartButtonGo);
			MoveButtonDown(quitButtonGo);
			goodLandingText.text = "Good Landing!";
			hasSetLandingText = true;
		}
		else if(hasSetLandingText == false && badLanding == true)
		{
			MoveButtonDown(restartButtonGo);
			MoveButtonDown(quitButtonGo);
			badLandingText.text = "Bad Landing!";
			hasSetLandingText = true;
		}
	}
	
	void MoveButtonDown(GameObject go)
	{
		Vector3 pos = go.transform.position;
		pos.x -= moveButtonAmount;
		go.transform.position = pos;
	}
	
	void MoveButtonUp(GameObject go)
	{
		Vector3 pos = go.transform.position;
		pos.x += moveButtonAmount;
		go.transform.position = pos;
	}
	void StartGame()
	{
		SceneManager.LoadScene ("Level_1",LoadSceneMode.Single);
	}
	
	void QuitGame()
	{
		Application.Quit();
	}
}
