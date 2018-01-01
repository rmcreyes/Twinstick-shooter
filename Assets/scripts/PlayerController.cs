using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// speed at which the hero moves
	public float speed;
	// knockback scaling the hero suffers when colliding with an enemy
	public float knockback;
	// rate at which the hero fires pellets
	public float fireRate;
	// hero's health; hero is destroyed when it reaches 0
	public float health;

	// hero fires this when left click is held down
	public GameObject pellet;
	// child of hero; where pellets are fired from
	public Transform shotspawn;
	// first frame of explosion animation
	public GameObject expl1;
	// second frame of explosion animation
	public GameObject expl2;
	// text displayed to show health
	public Text HealthText;
	// text displayed when game ends
	public Text FinishedText;

	private Rigidbody2D rb;
	// next time hero can fire a pellet
	private float nextFire = 0.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		SetHealthText ();

		FinishedText.text = "";
	}

	void FixedUpdate () {
		// accept horizontal and vertical input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// create a vector2 out of the inputs
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		// add a force based on the vector2
		rb.AddForce (movement * speed);
	}
		
	void Update() {
		// mousePos is the location on the screen where the mouse is hovering
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		// on every frame, have the hero's direction rotate to the relative location of the mouse to itself
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);

		// if the left click is held down,
		if (Input.GetMouseButton(0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			// create a pellet at the shotspawn's position, headed in the direction of the mouse
			Instantiate (pellet, shotspawn.position,
				Quaternion.LookRotation (Vector3.forward, mousePos - shotspawn.position));
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "health") {
			// increment health by 5 hp
			health += 10.0f;
			SetHealthText ();
			// destroy the health pickup
			Destroy (other.gameObject);
		}
		if (other.tag == "enemy") {
			// if hero has more than 1 hp,
			if (health > 1.0f) {
				// suffer knockback in the opposite direction of the enemy
				Vector2 enemyPos = other.transform.position;
				rb.AddForce (enemyPos * -knockback);
				// decrease hp
				health = health - 1.0f;
				SetHealthText ();
			} 

			// if hero has 1 or less hp,
			else {
				health = 0.0f;
				SetHealthText ();
				// destroy the hero
				Destroy (gameObject);

				// instantiate and destroy first frame of an explosion
				GameObject clone1 = (GameObject)Instantiate (expl1, transform.position, transform.rotation);
				Destroy (clone1, 0.1f);
				//instantiate and destroy second frame of an explosion
				GameObject clone2 = (GameObject)Instantiate (expl2, transform.position, transform.rotation);
				Destroy (clone2, 0.2f);

				// display end result screen
				FinishedText.text = "THANKS FOR PLAYING!\nCheck out my other projects at github.com/rmcreyes";
			}
		}
	}

	void SetHealthText() {
		HealthText.text = "Health: " + health.ToString ();
	}
}
