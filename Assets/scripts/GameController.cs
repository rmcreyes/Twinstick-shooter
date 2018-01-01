using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// time increment between spawning enemies
	public float spawnTimer;
	// time increment between spawning health pickups
	public float healthTimer;

	// enemy to spawn
	public GameObject enemy;
	// health pickup
	public GameObject health;
	// transform component of healthspawn gameObject
	public Transform healthSpawn;

	private bool healthInvoked;
	// first spawn happens after 5 seconds
	private float nextEnemySpawn = 5.0f;

	// player character
	private GameObject hero;
	// dumby variable to check if a health pickup exists on screen
	private GameObject isThereHealth;
	// array of red portal enemy spawn points
	private GameObject[] enemySpawns;

	void Start() {
		// instantiate enemyspawns with the positions of all enemy spawn points
		enemySpawns = GameObject.FindGameObjectsWithTag ("Respawn");
		healthInvoked = false;
	}

	void Update() {
		hero = GameObject.FindGameObjectWithTag ("Player");
		isThereHealth = GameObject.FindGameObjectWithTag ("health");

		if (isThereHealth == null && healthInvoked == false) {
			healthInvoked = true;
			Invoke ("SpawnHealth", healthTimer);
			Invoke ("SetHealthTimer", healthTimer);
		}

		// respawn enemies if spawnTimer runs out or if the hero is destroyed
		if ((Time.time >= nextEnemySpawn) && (hero != null)) {
			nextEnemySpawn += spawnTimer;
			spawnTimer *= 0.98f;
			SpawnWave ();
		}
		else {
			return;
		}
	}

	void SpawnWave() {
		// instantiate a random number of enemies
		int enemyCount = Random.Range (1, enemySpawns.Length + 1);

		// for each enemy to spawn,
		for (int i = 0; i < enemyCount; i++) {
			// pick a random enemy spawn point to spawn from
			int enemySpawn = Random.Range (0, enemySpawns.Length);

			Instantiate (enemy, enemySpawns [enemySpawn].transform.position,
				enemySpawns [enemySpawn].transform.rotation);
		}
	}

	void SpawnHealth() {
		// instantiate a health pickup at the health spawn location
		Instantiate (health, healthSpawn.position, healthSpawn.rotation);
	}

	void SetHealthTimer() {
		healthInvoked = false;
	}





}
