using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;

	public static int playerHealth;

	Text text;

	private LevelManager levelManager;

	public bool isDead;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		playerHealth = maxPlayerHealth;

		isDead = false;
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer();
			isDead = true;
		}

		text.text = "Health:         " + playerHealth;
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}