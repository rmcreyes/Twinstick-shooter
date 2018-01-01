using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	// enemy's health, enemy is destroyed when health reaches 0
	public float health;
	// speed at which the enemy can travel at
	public float speed;

	// first frame of explosion animation
	public GameObject expl1;
	// second frame of explosion animation
	public GameObject expl2;

	private Rigidbody2D rb;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		GameObject hero = GameObject.FindGameObjectWithTag ("Player");

		// do nothing when hero has been destroyed
		if (hero == null) {
			return;
		}
		// if hero has not been destroyed yet,
		else {
			Vector3 heroPos = hero.transform.position;
			Vector3 relativePos = heroPos - transform.position;
			Vector2 relativeDir = Vector3.Normalize (relativePos);
			// add a force to the enemy going towards the hero
			rb.AddForce (relativeDir * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "pellet") {
			// if the enemy has only 1hp,
			if (health == 1.0f) {
				// destroy the pellet
				Destroy (other.gameObject);
				// destroy the enemy
				Destroy (gameObject);

				// increment the enemiesDefeated by accessing the field in enemyCounter script
				GameObject enemyCount = GameObject.Find ("enemyCounter");
				EnemyCounter enemyCounter = enemyCount.GetComponent<EnemyCounter> ();
				enemyCounter.enemiesDefeated += 0.5f;

				// instantiate and destroy the first frame of an explosion
				GameObject clone1 = (GameObject)Instantiate (expl1, transform.position, transform.rotation);
				Destroy (clone1, 0.1f);

				// instantiate and destroy the second frame of an explosion
				GameObject clone2 = (GameObject)Instantiate (expl2, transform.position, transform.rotation);
				Destroy (clone2, 0.2f);
			
			// if the enemy has more than 1hp,
			} else {
				// destroy the pellet
				Destroy (other.gameObject);
				// decrease the enemy's hp by 1
				health = health - 1.0f;
			}
		}
	}
}
