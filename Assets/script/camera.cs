using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour {
	Camera cam; 
	float tpp , tcp,zm  ;
	Vector2 ftp , stp ; 
 
	public float speedH = 1.0f;
	public float speedV = 1.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	public float zmfs = 0.1f ;
	Vector3 touchstart ;

	Text  text ; 

	// Use this for initialization
	void Start () {
		 cam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){

				touchstart = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			
		}
		if (Input.touchCount == 2) {
			/*Touch ft = Input.GetTouch (0);
			Touch st = Input.GetTouch (1);
			ftp = ft.position - ft.deltaPosition;
			stp = st.position - st.deltaPosition;
			tpp = (ftp - stp).magnitude;
			tcp = (ft.position - st.position).magnitude;
			zm = (ft.deltaPosition - st.deltaPosition).magnitude * zmfs; 
			if (tpp > tcp)
				cam.orthographicSize += zm; 
			if (tpp < tcp)
				cam.orthographicSize -= zm; */
			Touch tz = Input.GetTouch (0);
			Touch to = Input.GetTouch (1);

			Vector2 tzpp = tz.position - tz.deltaPosition; 
			Vector2 topp = to.position - to.deltaPosition; 

			float pm = (tzpp - topp).magnitude;
			float cm = (tz.position - to.position).magnitude; 

			float d = cm - pm; 
			zoom (d * 0.01f);


		}
		 else if ( Input.GetMouseButton(0)) {
			/*
			yaw += -speedH * Input.GetAxis ("Mouse Y");
			pitch += -speedV * Input.GetAxis ("Mouse X");
			Debug.Log ("ss\n"+"\n"+"\n");
			//	transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
			cam.transform.position = new Vector3 (pitch, yaw, 0.0f);
			*/
		
			Vector3 d = touchstart - Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Camera.main.transform.position += d;
			


		}
		 
			zoom (Input.GetAxis ("Mouse ScrollWheel"));
		

		//cam.orthographicSize = Mathf.Clamp (cam.orthographicSize, 2f, 10f);
		//text.text = "" +cam.orthographicSize; 
	}
	void zoom (float ino ){
		 
		 
		Camera.main.orthographicSize = Mathf.Clamp (Camera.main.orthographicSize - ino, 1f, 38f );
		
	}
}
