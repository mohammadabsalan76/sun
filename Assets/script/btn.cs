using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn : MonoBehaviour {
	public Button btn_partab1; 
	// Use this for initialization
	public void btn_partab(){
		
		setvalue ();
		//ball_move.start = true;
	}
	public void btn_reload(){
		
		Application.LoadLevel ("1");
		ball_move.start = false;
		ball_move.get_value = false;
	
	}

	public void setvalue(){
		
		ball_move.get_value = true;
	}

	public void btn_right(){

		 
		ball_move.flag_right = true;

	}
	public void btn_left(){

		 
		ball_move.flag_left = true;

	}
	public void btn_down(){
 
		ball_move.flag_down = true;

	}
	public void btn_up(){
 
		ball_move.flag_up = true;

	}
}
