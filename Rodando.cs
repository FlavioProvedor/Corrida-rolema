using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script tem por objetivo fazer as notas rodarem
public class Rodando : MonoBehaviour {

	// Não terão campos a serem inicializados
	void Start () {
		
	}
	
	//Faz as notas girarem
	void FixedUpdate () {
		transform.Rotate (0, 4, 0);
	}

}
