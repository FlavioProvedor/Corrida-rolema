using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public int velocidade;
	public int veloGiro;
	float horizontal;
	float vertical;
	public Text verifica;


	// Use this for initialization
	void Start () {
		horizontal = 0.0f;
		vertical = 0.0f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Input.GetAxis ("Vertical")!=0.0f){
			andar ();
			if (Input.GetAxis ("Horizontal") != 0.0f) {
				girar ();
			}
		}


	}

	void girar()
	{
		horizontal = Input.GetAxis ("Horizontal");
		Vector3 giro = new Vector3 (0.0f, horizontal, 0.0f);
		transform.Rotate (giro * veloGiro * Time.deltaTime);
	}
	void andar()
	{
		vertical = Input.GetAxis ("Vertical");
		Vector3 moviment = new Vector3 (0.0f, 0.0f, -vertical);
		transform.Translate (moviment*velocidade * Time.deltaTime);
	}

}
