using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direcao : MonoBehaviour {

	public GameObject player;
	private float lado;
	private float quantoRodou;
	private Vector3 gira;
	private Girar virar;

	// Use this for initialization
	void Start () {
		setVirar ();
		lado = virar.getLado ();
		quantoRodou = virar.getQuantoRodou ();


	}

	// FixedUpdate evento em determinado intervalo de tempo
	void FixedUpdate ()
	{
		//Girar o pedal ou retornar a posição inicial
		if (virar.getRodando ()) {
			if ((quantoRodou < virar.getLimite ()) && (quantoRodou > -virar.getLimite ())) {
				girarPedal (lado);
			} 
		}else {
			if (quantoRodou != 0) {
					girarPedal(-lado);
				}		
		}
	

		
		setVirar ();
		quantoRodou = virar.getQuantoRodou ();
		lado = virar.getLado ();


	}//Fim do FixedUpdate


	//Carregando as informações de lado e quanto rodou da classe PlayerController
	public void setVirar()
	{
		virar = player.GetComponent<PlayerController>().virar;
	}

	/**
	 * Girando o pedal de acordo com o lado
	 * @param lad	Float que indica o sentido de giro (positivo ou negativo)
	 */
	private void girarPedal(float lad)
	{
		gira = new Vector3 (0.0f, 0.0f, lad); 
		transform.Rotate (gira * 90 * Time.deltaTime);
	}

}
