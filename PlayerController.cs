using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//bloco de atributos referentes ao controle do carrinho (movimento)
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
	public float testGiro;

	//Bloco de atributos para User Interface (texto em tela)
	public Text 	alto;
	public Text		baixo;

	//Bloco referente aos atributos do evento de pontuação(som, acressimo)
	public AudioClip pegaMoeda;
	private AudioSource som;
	private float pontuacao;

	// Valores iniciais para os private
	void Start () {
		andar 		= 0.0f;
		quantoRodou = 0.0f;
		lado		= 0.0f;
		virar = new Girar ();
		virar.setLimite (limite); //Limite é public será informado na interface Unity.
		andando = false;
		frente = true;
		som = GetComponent<AudioSource> ();
		pontuacao = 0;

		baixo.text = "Pontuação : " + pontuacao;
		alto.text = "Corrida iniciada!";
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
				} else
					virar.setRodando (false);
			}

		//este bloco garante que o limite nao seja extrapolado
		if (quantoRodou > virar.getLimite ())
			quantoRodou = virar.getLimite();
		if (quantoRodou < -(virar.getLimite()))			
			quantoRodou = -(virar.getLimite());
		if (quantoRodou < virar.getLimite () && quantoRodou > -virar.getLimite ()&& virar.getRodando())
			quantoRodou += lado;
		if (!(Input.anyKey)) { //se nao há tecla precionada, carro nao esta rodando.
			virar.setRodando (false);
			andando = false;
		}
		

		if (quantoRodou != 0 && !(virar.getRodando ())) {
			//if (quantoRodou <= virar.getLimite () && quantoRodou >= -virar.getLimite ())
				if (lado > 0 && quantoRodou > 0 || lado < 0 && quantoRodou < 0)
					quantoRodou += -lado;
				else
					lado = -lado;
			}

		if (quantoRodou == 0)
				lado = 0;



	//Adicionando valores  encapsulados na referencia Virar.
		virar.setLado (lado);
		virar.setQuantoRodou (quantoRodou);



	}//Fim do FixedUpdate

	void girar()
	{
		if (andando && virar.getRodando()) {
			float test = testGiro*lado;
			if (!frente) {
				giro = new Vector3 (0.0f,-test, 0.0f);
			}
			else
				
				giro = new Vector3 (0.0f, test, 0.0f);
				
			transform.Rotate (giro * veloGiro * Time.deltaTime);
		}
	}
	void anda()
	{
		float fator;
		andando = true;
		if (andar >= 0) {
			frente = true;
			fator = aceleracao * 1.0f;
		}
		else {
			frente = false;
			fator = aceleracao * 0.6f;;
		}


		andar = Input.GetAxis ("Vertical");
		if (andar != 0) {
			Vector3 moviment = new Vector3 (0.0f, 0.0f, -andar);
			transform.Translate (moviment * (fator) * Time.deltaTime);

		} else{
			andando = false;
		}

	}

	/*
	 * Eventos de colisão com 
	 * 	notas (2,50,100)
	 * 	marcainicial
	 * 	marcafinal
	 * */
	void OnTriggerEnter(Collider nota){
		Destroy(nota.gameObject);

		//adicionando valor a pontuação de acordo com a cedula coletada
		if (nota.gameObject.CompareTag ("doisReais"))
			MudaPonto (2);
		else if (nota.gameObject.CompareTag ("cinquentaReais"))
			MudaPonto (50);
		else if (nota.gameObject.CompareTag ("cemReais"))
			MudaPonto (100);
		



		//cubo no inicio da corrida que tira o texto (CORRIDA INICIADA) da tela
		if (nota.gameObject.CompareTag ("Up"))
			alto.text = "";
		//cubo no fim da corrida que faz que o carrinho pare e a corrida se encerre.
		if (nota.gameObject.CompareTag ("Dinheiro")) {
			aceleracao = 0;
			alto.text="CORRIDA FINALIZADA!";

		}



	}

	//Adicionando pontuação, reproduziindo som e mudando texto de pontuação
	void MudaPonto(int ponto){
		pontuacao += ponto;
		som.PlayOneShot (pegaMoeda,0.2f);
		baixo.text = "Pontuação : " + pontuacao;

	}

}
