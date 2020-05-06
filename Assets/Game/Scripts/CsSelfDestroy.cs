using UnityEngine;
using System.Collections;

public class CsSelfDestroy : MonoBehaviour {
	float destime = 0.5f;
	// Use this for initialization
	void Start () {
		StartCoroutine("SelfDestroy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator SelfDestroy(){
		yield return new WaitForSeconds(destime);
		Destroy(gameObject);
	}
}



