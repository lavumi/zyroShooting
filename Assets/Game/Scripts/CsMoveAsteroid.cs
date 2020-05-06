using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CsMoveAsteroid : MonoBehaviour {
	float speed = 10;
	public GameObject expSmall;
	Vector3 direction;
	public Slider sliderhp;
	int HP = 10;
	//Vector3 playerpos = new Vector3 (0, 1, 0);
	int rotX, rotY, rotZ;
	// Use this for initialization
	void Start (){
		sliderhp.gameObject.SetActive (false);
		float sizeX = Random.Range (5.5f, 9.5f);
		float sizeY = Random.Range (5.5f, 9.5f);
		float sizeZ = Random.Range (5.5f, 9.5f);
		transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
		
		//float r = Random.Range(0.6f, 1);
		//transform.GetComponent<Renderer>().material.color = new Vector4(r, 0.8f, 0.8f, 1);


		direction.x = Random.Range (-1, 1);
		direction.y = Random.Range (-1, 1);
		direction.z = Random.Range (-1, 1);

		rotX = Random.Range(-90,90);
		rotY = Random.Range(-90,90);
		rotZ = Random.Range(-90,90);

		float x = Random.Range (-299, 299);
		float y = Random.Range (-299, 299);
		float z = Random.Range (-299, 299);
		transform.position = new Vector3(x, y, z);
		//transform.rotation = new Vector3(rotX, rotY, rotZ);

	}
	void HitMissile (Vector3 pos){
		sliderhp.gameObject.SetActive (false);
		HP--;
		sliderhp.value -= 0.12f;
		//Instantiate(expSmall,pos, Quaternion.identity);
		//AudioSource.PlayClipAtPoint (expSnd, transform.position);
		if (HP == 0) {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		float amtMove = speed*Time.smoothDeltaTime;
		//Vector3 direction = (new Vector3(0,1,0)- transform.localPosition);
		transform.Translate(direction *amtMove, Space.World);
		transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.smoothDeltaTime);

		if(transform.position.x >300||transform.position.y >300||transform.position.z >300||transform.position.x <-300||transform.position.y <-300||transform.position.z <-300){
			Destroy (gameObject);
		}
	}
}
