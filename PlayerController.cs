using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public	float 	aceleracao; 	//velocidade sera atribuida manualmente na tela do unity
	public	float 	veloGiro;		//velocidade sera atribuida manualmente na tela do unity
	private	float 	quantoRodou;	//Valor para medir o quanto o pedal rodou
	private	bool 	andando;		//Verifica status do carro
	private bool 	frente;			//verifica sentido do carro;
	private float	andar;			//Valor atribuido por Input.getAxis("Vertical")
	private	float 	lado;			//Valor atribuido por Input.getAxis("Horizontal")
	public Girar 	virar;			//variavel que carregag os dados de PlayerController
	public float	limite;			//limite em graus para a volta da direção
	private	Vector3 giro;			//vaalor utilizado para girar o carro

	public Text 	alto;
	public Text		baixo;


	// Valores iniciais para os private
	void Start () {
		andar 		= 0.0f;
		quantoRodou = 0.0f;
		lado		= 0.0f;
		virar = new Girar ();
		virar.setLimite (limite); //Limite é public será informado na interface Unity.
		andando = false;
		frente = true;
	}
	
	//Utilizado FixedUpdate para controlar o tempo em que as ações
	//descritas serão executadas.
	void FixedUpdate () 
	{
		girar ();
		anda ();


		 // Auterando o lado de acordo com a tecla pressionada 
		if (Input.GetKey (KeyCode.A)) {
				lado = -1.0f;
				virar.setRodando (true);
			} else {
				if (Input.GetKey (KeyCode.D)) {
					lado = 1.0f;
					virar.setRodando (true);
				} 
				else
					virar.setRodando (false);
			}

		if (quantoRodou > virar.getLimite ())//este bloco garante que o limite nao seja extrapolado
			quantoRodou = virar.getLimite();
		if (quantoRodou < -(virar.getLimite()))			
			quantoRodou = -(virar.getLimite());
		if (quantoRodou < virar.getLimite () && quantoRodou > -virar.getLimite ()&& virar.getRodando())
			quantoRodou += lado;
		if(!(Input.anyKey))  //se nao há tecla precionada, carro nao esta rodando.
			virar.setRodando (false);
		if (quantoRodou != 0 && !(virar.getRodando ())) {
			if (quantoRodou <= virar.getLimite () && quantoRodou >= -virar.getLimite ())
				if (lado > 0 && quantoRodou > 0 || lado < 0 && quantoRodou < 0)
					quantoRodou += -lado;
				else
					lado = -lado;
			}
		if (quantoRodou == 0)
				lado = 0;

		baixo.text = (virar.getRodando ()).ToString ();



		virar.setLado (lado);
		virar.setQuantoRodou (quantoRodou);

		alto.text ="rodou "+quantoRodou.ToString ();
		//baixo.text ="lado "+lado.ToString ();
	}//Fim do FixedUpdate

	void girar()
	{
		if (andando) {
			quantoRodou = Input.GetAxis ("Horizontal");
			if (!frente) {
			giro = new Vector3 (0.0f, -quantoRodou, 0.0f);
			}
			else
			giro = new Vector3 (0.0f, quantoRodou, 0.0f);
				
			transform.Rotate (giro * veloGiro * Time.deltaTime);
		}
	}
	void anda()
	{
		//Auterar esta classe, valores não estão satisfazendo o movimento
		andar = Input.GetAxis ("Vertical");
		if (andar != 0) {
			Vector3 moviment = new Vector3 (0.0f, 0.0f, -andar);
			transform.Translate (moviment * aceleracao * Time.deltaTime);
			andando = true;
			if (andar >= 0)
				frente = true;
			else
				frente = false;
				
		} else{
			andando = false;
		}

	}


}

