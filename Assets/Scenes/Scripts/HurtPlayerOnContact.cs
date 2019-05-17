using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			HealthManager.HurtPlayer(damageToGive);
		}
	}
}
