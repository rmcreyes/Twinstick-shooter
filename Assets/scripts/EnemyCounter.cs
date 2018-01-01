using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {

	// number of enemies
	public float enemiesDefeated;
	// text displaying how many enemies have been defeated
	public Text EnemyText;

	void Start () {
		enemiesDefeated = 0.0f;
		SetEnemyText ();
	}

	void Update () {
		SetEnemyText ();
	}

	void SetEnemyText() {
		EnemyText.text = "Enemies defeated: " + enemiesDefeated;
	}
}
