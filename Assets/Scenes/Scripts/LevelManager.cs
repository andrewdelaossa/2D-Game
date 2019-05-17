	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	private CameraController camera;

	public int pointPenaltyOnDeath;

	private float gravityStore;

	public HealthManager healthManager;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType <PlayerController> ();

		healthManager = FindObjectOfType<HealthManager> ();

		camera = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	public void RespawnPlayer ()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo () {
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		camera.isFollowing = false;
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		//Debug.Log ("Player Respawn");
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		yield return new WaitForSeconds (respawnDelay);
		//player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		healthManager.FullHealth();
		healthManager.isDead = false;
		camera.isFollowing = true;
		player.GetComponent<Renderer>().enabled = true;

		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}