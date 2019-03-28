using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ball_move : MonoBehaviour {
	public Rigidbody2D rb ;
	public Rigidbody2D partabe;
	public GameObject ball ;
	public GameObject rad ; 
	public GameObject rad2 ; 
	public GameObject CAMERA ; 
	public Text v0; 
	public Text Alpha; 
	public Text per; 
	public Text XX; 
	public Text YY; 
	public Text TT; 
	public Text speed; 
	public Text total_khat; 
	public Text HH; 
	public Text RR; 


	  float upspeed = 1 ; 
	float time = 0;
	float  flag = 0; 
		float  flag_rad = 0.16f; 
	  public   float x =  0; 
	  public  float y = 0 ; 
	public static bool start = false ; 
	public static bool get_value = false ; 
	public static bool flag_up = false ; 
	public static bool flag_down = false ; 
	public static bool flag_right = false ; 
	public static bool flag_left = false ; 

	string total = "";
	ArrayList  xs = new ArrayList ();
	ArrayList  ys = new ArrayList ();
	ArrayList  ts = new ArrayList ();
 
	bool tick = true ; 
	// Use this for initialization
	void Start () {
	//	partabe = GetComponent<Rigidbody2D> ();
	//	rb = GetComponent<Rigidbody2D> ();
	

		Debug.Log( "a2  "+(float)( System.Math.Sin (((45*2) * System.Math.PI) / 180)) );
		//Debug.Log( "a3 "+ a3 );


	}
	 
	
	// Update is called once per frame
	void Update () {


		if (get_value) {
			xs = new ArrayList ();
			ys = new ArrayList ();
			ts = new ArrayList ();
			float X=0f;
			float Y=0 ; 
			double A= 45;
			double G =9.80f ; 
			double X0 =  0f;
			double V0 = 20;
			double T =0; 
			//double DO = 2 ;
			float R = 0 ;
			float H = 0 ;
			float per = 0.1f ; 

			A = double.Parse(Alpha.text)  ;

			V0 = double.Parse(v0.text);
			if (!this.per.text.Trim().Equals ("")) {
				per = float.Parse (this.per.text);
			}

			rb.transform.position = new Vector2 (0f ,0f );
			CAMERA.transform.position = new Vector3 ( 12.92f , 6.1f  ,-1);

			X0 = rb.transform.position.x;
		 X  = rb.transform.position.x;
			tick = true ;
			if (tick) {


				float tanA;
				if (A==90){
				/*	//vy=V0sinA-gT
					float Vy = (float)((V0* 1)-G*T);
					//vx=V0cosA
					float Vx = 0;
					tanA = Vy / Vx;
				*/
					A = 89.9;
					tanA =(float)( System.Math.Tan ((A * (System.Math.PI / 180)))); 
				}else{
					tanA =(float)( System.Math.Tan ((A * (System.Math.PI / 180)))); 
				}
				float cosA = (float)(System.Math.Cos ((A * System.Math.PI) / 180)); 
				float sinA = (float)(System.Math.Sin ((A * System.Math.PI) / 180)); 
				float sin2A = (float)(System.Math.Sin (((A*2) * System.Math.PI) / 180)); 
				float V02 = (float)(System.Math.Pow (V0,2)); 
				float a2 = (float)(2 * (System.Math.Pow (V0, 2)));
				float a3 = (float)(System.Math.Pow ((cosA), 2));
				float a4 = (float)(a2 * a3);
				//H=V0^2 sin^2 A/2g
				H =(float)((V02)*(System.Math.Pow (sinA,2))/(2*G));
				this.HH.text = H+"";
				//R=V0^2sin 2A/g
				R =(float)(((V02)*(sin2A))/G) ; 
				this.RR.text = R + "";
				Debug.Log( "a2  "+a2);
				Debug.Log( "a3 "+ a3 );
				Debug.Log( "a4 "+a4  );
				Debug.Log( "cos "+A +" = " +cosA  );
				Debug.Log( "tan  "+A+" = " + tanA  );

				for (double i = 0; i <= 300; i += per) {
					
					T = i;
					// x = X0+V0tcosA
						X = (float)(X0 + (V0 * T * cosA ));
				  
					// y = (-gx^2/(2V0^2cos^2A))+xtanA   
					float a1 = (float)((-1 * G) * (System.Math.Pow (X, 2)));

					float a5 = (float)(X * (tanA));
					Y = (float)(a1 / a4) + a5;
//					Debug.Log ("tan 45  " + System.Math.Tan ((45 * (System.Math.PI / 180))));
					if (Y > -3.47) {
						Debug.Log ("t = " + T);
						Debug.Log ("x = " + X);
						Debug.Log ("y = " + Y);
			
	
						//total += a2 + "\n";
						xs.Add (X);
						ys.Add (Y);
						ts.Add (T);
						Debug.Log ("a1  " + a1);
						Debug.Log ("a5 " + a5); 
						 
					} else {
						break;
					}
				}
				Debug.Log (total); 
				bool f = true; 
				if (f) {
					total_khat.text = xs.Count+"";
					StartCoroutine(Example());
					get_value = false; 
					f = false;
				}

				  tick = false;


				Debug.Log (total);
			}


		}
		if (Input.GetMouseButtonDown (0)) { 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit; 
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "khat") {
					Debug.Log ("X = "+ hit.transform.position.x);
					Debug.Log ("Y = "+ hit.transform.position.y);
					XX.text = "" +hit.transform.position.x;
					YY.text = "" +hit.transform.position.y;
					TT.text = "" +hit.transform.name;

				}
			}
		}

		if ((   Input.GetKey(KeyCode.UpArrow) ) || flag_up   ) {
			if(CAMERA.transform.position.y< 665f){

			CAMERA.transform.position =  new Vector3(CAMERA.transform.position.x ,CAMERA.transform.position.y+1,-10);
			}
			flag_up = false;

		}

		if ((   Input.GetKey(KeyCode.DownArrow) )  || flag_down) {
			if (CAMERA.transform.position.y> 6.1f) {
				
				CAMERA.transform.position = new Vector3 (CAMERA.transform.position.x, CAMERA.transform.position.y - 1, -10);

			}
			flag_down = false;
		}


		/*if(Time.timeScale != 0 && flag >= 1){
			StartCoroutine ("countmytime");

		}*/

		if ((   Input.GetKey(KeyCode.LeftArrow) )  || flag_left ) {
			//rb.velocity = new Vector2(-upspeed,rb.velocity.y);
			if (CAMERA.transform.position.x > 12.92f) {
				
				CAMERA.transform.position = new Vector3 (CAMERA.transform.position.x - 1, CAMERA.transform.position.y, -10);
			}
			flag_left = false;
		}
		if ((   Input.GetKey(KeyCode.RightArrow) ) || flag_right  ) {
			//rb.velocity = new Vector2(upspeed,rb.velocity.y);
			if (CAMERA.transform.position.x < 2117f ) {
				
				CAMERA.transform.position = new Vector3 (CAMERA.transform.position.x + 1, CAMERA.transform.position.y, -10);
			}
			flag_right = false;

		}

		//ball.transform.rotation = rad.transform.rotation; 
		if(start == true ){ partab ();  }
	 


	}
	IEnumerator countmytime(){
		yield return new WaitForSeconds (0f);
		 time += 1;
	}
	IEnumerator Example()
	{
		print(Time.time);
		rb.GetComponent<Rigidbody2D> ().simulated = false; 
		ball.GetComponent<FixedJoint2D> ().enabled = false; 

		partabe.GetComponent<Rigidbody2D>().gravityScale = -1 ;
		for (int i = 0; i< xs.Count  ; i++) {
			if((float)ys[i]   >-3.47){
				
			//total+=xs[i]+""+ ys[i];
				if(i==2 ){
					
				}
				yield return new WaitForSeconds( float.Parse (this.speed.text));
				rb.transform.position = new Vector2 ((float)xs[i], (float)ys[i]);

				Instantiate (rad2, rb.transform.position, rb.transform.rotation ).gameObject.name=""+ts[i];
				if ((float)xs [i] > 12.92f && (float)ys[i] <6.1f ) {
					CAMERA.transform.position = new Vector3 ((float)xs[i], 6.1f,-1);

				}
				if ((float)xs [i] < 12.92f && (float)ys[i] >6.1f ) {
					
					CAMERA.transform.position = new Vector3 (12.92f, (float)ys[i],-1);

				}
				if ((float)xs [i] > 12.92f && (float)ys[i] >6.1f ) {

					CAMERA.transform.position = new Vector3 ((float)xs[i], (float)ys[i],-1);

				}
				if ((float)xs [i] < 12.92f && (float)ys[i] <6.1f ) {

					//CAMERA.transform.position = new Vector3 ((float)xs[i], (float)ys[i],-1);

				}

				 
		 }
			 
		} 
		print(Time.time);
	}

	public void partab(){


		 
			flag++; 
	// partabe.velocity = new Vector2 (partabe.position.x ,partabe.position.y+0.1f);
		partabe.GetComponent<Rigidbody2D>().gravityScale = -1 ;
		ball.GetComponent<FixedJoint2D> ().enabled = false; 


			if (flag < 40 && flag > 5) {
				rb.transform.position = new Vector2 (rb.position.x - x, rb.position.y + y);
			 
				
				 
			flag_rad++; 
				if (flag_rad > 3) {
					Instantiate (rad, rb.transform.position, rad.transform.rotation);
					flag_rad = 0; 
				}
			}
			if (flag >= 40 && flag < 199) {
				rb.transform.position = new Vector2 (rb.position.x - x , rb.position.y - y );
				flag_rad++;
				if (flag_rad > 3) {
					Instantiate (rad2, rb.transform.position, rad.transform.rotation);
					flag_rad = 0; 
				}
			if (rb.position.y <= -4.296f) {
					flag = 201;
				rb.GetComponent<Rigidbody2D> ().simulated = false; 
				}
			
			}
		//ball.GetComponent<FixedJoint2D> ().enabled = true; 



	}

	public static double Ctg(double radians)
	{
		double degrees = (180 /System.Math.PI) * radians;
		return (degrees);
	}
}
