using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CsMoveAsteroid1 : MonoBehaviour {

	public ParticleSystem expSmall;
	public Slider sliderhp;
	int HP = 10;
	void Start () {
		sliderhp.gameObject.SetActive (false);


	}
	void HitMissile (Vector3 pos){
		sliderhp.gameObject.SetActive (true);
		HP--;
		sliderhp.value -= 0.12f;
		Debug.Log ("MIssile hit");
		if (HP == 0) {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
