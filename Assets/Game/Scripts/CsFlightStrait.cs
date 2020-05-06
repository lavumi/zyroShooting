using UnityEngine;
using System.Collections;

public class CsFlightStrait : MonoBehaviour {
	public float speed = 25;
	// Use this for initialization
	void Start () {

		float x = Random.Range (50, 100);
		float y = Random.Range (40, 50);
		float z = Random.Range (50, 100);

		transform.position = new Vector3(x, y, z);
		transform.LookAt(new Vector3(0,transform.position.y,0));
	}
	
	// Update is called once per frame
	void Update () {
		float amtMove = speed * Time.smoothDeltaTime;
		transform.Translate (new Vector3 (0,0,1)*amtMove);
		if(transform.position.x<-100){
			Destroy(gameObject);
		}
	}
}
