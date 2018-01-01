using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletBehaviour : MonoBehaviour {

	// speed at which pellets can travel
	public float pelletSpeed;
	// how long a pellet stays on screen before being destroyed
	public float lifeSpan;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		// the pellet's velocity will be directed towards the mouse's position,
		// at the speed specified
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 shotDir = mousePos - transform.position;
		rb.velocity = shotDir * pelletSpeed;
		rb.AddForce (rb.velocity, (ForceMode2D.Force));

		// pellet destroys itself after its lifespan expires
		Destroy (gameObject, lifeSpan);
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		// if the pellet collides with a piece of terrain
		if (other.tag == "terrain") {
			// the pellet destroys itself
			Destroy (gameObject);
		} 
		else {
			return;
		}
	}
	

}
