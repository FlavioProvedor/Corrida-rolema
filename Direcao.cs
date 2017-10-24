using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direcao : MonoBehaviour {
	public Text verifica;
	float horizontal;
	private float roda;
	// Use this for initialization
	void Start () {
		verifica.text = "";
		roda = 0.0f;
		horizontal = 0.0f;

	}

	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		verifica.text = horizontal.ToString ();

		if (Input.GetAxis ("Vertical") != 0.0f) {
			horizontal = Input.GetAxis ("Horizontal");
			roda += horizontal;
			transform.Rotate (new Vector3 (0.0f, 0.0f, horizontal) * 90 * Time.deltaTime);

		}
		else 
		{
			if (roda != 0.0f) 
			{
				horizontal = -horizontal;
			
				transform.Rotate (new Vector3 (0.0f, 0.0f, horizontal) * 150 * Time.deltaTime);
				roda -= horizontal;
			}
		}


	}
}
