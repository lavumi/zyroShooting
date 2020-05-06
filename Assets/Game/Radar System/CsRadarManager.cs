using UnityEngine;
using UnityEngine.UI;

public class CsRadarManager : MonoBehaviour {

	public RenderTexture MiniMapTexture;
	public Material MiniMapMaterial;
	public GameObject radarview;
	public GameObject headpointer;
	public Text debugtext;
	public float index=554;
	// Use this for initialization

	void Start(){

		radarview.transform.localScale = new Vector3(Screen.width, Screen.width/2, Screen.height);

	}

	void Awake () {
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(Event.current.type == EventType.Repaint)
			Graphics.DrawTexture(new Rect(10, 10, Screen.width/7, Screen.width/7),MiniMapTexture, MiniMapMaterial);
	}
	void Update(){
		//radarview.transform.localScale = new Vector3(Screen.width, index, Screen.height);
	}
}
