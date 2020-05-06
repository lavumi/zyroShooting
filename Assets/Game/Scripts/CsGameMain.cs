using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CsGameMain : MonoBehaviour {
	public Transform asteroid;
	bool canFire = true;
	public Transform missile;
	GameObject headpointer;
	bool pause = true;
	public Text debugtext1,debugtext2,debugtext3;
	public Text Pausetxt;
	public Camera Maincam;
	public GameObject expSmall;
	public Text textbtm;
	public GameObject shoottrack;
	public GameObject planestrait, planecircle;
	public Color c1 = Color.red;
	public Color c2 = Color.yellow;
	public Button Firebutton;
	bool _pressed = false;

	// Use this for initialization
	void Start () {
		headpointer =GameObject.Find("Head");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		if(headpointer.transform.eulerAngles.x>10&&headpointer.transform.eulerAngles.x<90){
			Time.timeScale = 0;
			pause = true;
			Pausetxt.text = "PAUSED";
		}
		else{
			Time.timeScale = 1;
			pause = false;
			Pausetxt.text = " ";
		}
		debugtext1.text = Screen.width.ToString();
		debugtext2.text = Screen.height.ToString();


		if(!pause){
			//makeEnemy();
			makePlane();
			//ShootMissile();
			//fireRay();
			if(_pressed){
				fireRay ();
			}
		}


	}

	void makeEnemy(){
		if(Random.Range(0, 1000)>800){
			Instantiate (asteroid);
		}
	}
	void makePlane(){
		if(Random.Range(0, 1000)>990){
			Instantiate (planecircle);
		}
		else if(Random.Range(0, 1000)>990){
			//	Instantiate (planestrait);
		}
	}



	public void Fireclick(){
		_pressed = true;

	}
	public void fireclickup(){
		_pressed = false;
		StartCoroutine("EraseRayser");
	}




	//MAKE RAYSER
	void fireRay(){
		Debug.Log ("fireray in");
		Ray ray = Maincam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
		RaycastHit hit;
		
		//if(Input.GetMouseButtonDown(0)||Cardboard.SDK.CardboardTriggered){
			
			//Ray ray = Maincam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit))
			{
			Debug.Log ("fireratinin");
				textbtm.text = hit.transform.tag;
				if(hit.transform.tag == "ASTEROID"){
					shoottrack.GetComponent<LineRenderer>().SetColors(c2, c1);
					shoottrack.GetComponent<LineRenderer>().SetPosition(0,new Vector3(0,1,0));
					shoottrack.GetComponent<LineRenderer>().SetPosition(1,hit.point);
					hit.collider.SendMessage("HitMissile", transform.position,SendMessageOptions.DontRequireReceiver);
					Instantiate(expSmall,hit.transform.position, Quaternion.identity);
				}
				if(hit.transform.tag == "WALL"){
					shoottrack.GetComponent<LineRenderer>().SetColors(c2, c2);
					shoottrack.GetComponent<LineRenderer>().SetPosition(0,new Vector3(0,1,0));
					shoottrack.GetComponent<LineRenderer>().SetPosition(1,hit.point);
					
				}
			}
		//}
	}
	IEnumerator EraseRayser(){
		yield return new WaitForSeconds (0.1f);
		shoottrack.GetComponent<LineRenderer>().SetPosition(1,new Vector3(0,1,0));
	}
	//END RAYSER


	// MISSILE PART
	/*
	void ShootMissile(){
		if(Input.GetButton("Fire1") && canFire){
			StartCoroutine("MakeMissile");
		}
		/*
		if(Cardboard.SDK.CardboardTriggered){
			StartCoroutine("MakeMissile");
		}


	}
	public void shootmissbtn(){
		StartCoroutine("MakeMissile");
	}
	IEnumerator MakeMissile(){
		canFire = false;
		Vector3 shadowheadforward;
		shadowheadforward.x = headpointer.transform.forward.x;
		shadowheadforward.y = 0;
		shadowheadforward.z = headpointer.transform.forward.z;
		Vector3 firepoint = Vector3.Cross(shadowheadforward, new Vector3(0,1,0));
		firepoint.Normalize();
		Instantiate(missile, new Vector3(firepoint.x*0.5f,1, firepoint.z*0.5f), Quaternion.identity);
		Instantiate(missile, new Vector3(-firepoint.x*0.5f,1, -firepoint.z*0.5f), Quaternion.identity);
		yield return new WaitForSeconds(0.02f);
		canFire = true;
	}
	*/
	//MISSILE END
	

}
