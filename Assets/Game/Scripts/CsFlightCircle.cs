using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CsFlightCircle : MonoBehaviour {
	public float speed = 25;
	// Use this for initialization
	void Start () {
		float x = Random.Range (-100, 100);
		float y = Random.Range (40, 50);
		float z = Random.Range (50, 100);
		transform.position = new Vector3(x, y, z);
		transform.LookAt(new Vector3(0,transform.position.y,0));
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawLine(transform.position, new Vector3(0, 0,0));

		if(transform.position.z<5)
		{
			transform.Rotate (new Vector3(0,-1,0));
		}
		float amtMove = speed * Time.smoothDeltaTime;
		transform.Translate (new Vector3 (0,0,1)*amtMove);
		if(transform.position.z>100){
			Destroy(gameObject);
		}


	}
}
