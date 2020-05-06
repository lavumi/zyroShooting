using UnityEngine;
using System.Collections;

public class CsMissile : MonoBehaviour {
	GameObject headpointer;
	//GameObject FireL;
	//GameObject FireR;
	public bool leftfire = true;
	int speed = 999;
	// Use this for initialization
	void Start () {
		headpointer =GameObject.Find("Head");
		transform.Rotate (headpointer.transform.forward);
		//FireL.transform.position = headpointer.transform.position;
		//FireR.transform.position = headpointer.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		float amtMove = speed*Time.smoothDeltaTime;
		Vector3 direction =headpointer.transform.forward;
		transform.Translate(direction*amtMove);
		
		if(transform.position.x>99||transform.position.y>99||transform.position.z>99||transform.position.x<-99||transform.position.y<-99||transform.position.z<-99){
			Destroy (gameObject);
		}

	}


	
	void OnTriggerEnter(Collider coll){
		if(coll.transform.tag =="ASTEROID")
		{
			coll.SendMessage("HitMissile", transform.position,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}


}
