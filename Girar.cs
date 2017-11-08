/**
 * Esta classe tem por armazena valores referentes
 * ao lado que o objeto está rodando e o quanto ja rodou
*/

public class Girar 
{

	private float lado;
	private float quantoRodou;
	private  float limite;
	private bool rodando;

	/**
	 * O construtor inicializa os campos a direção do giro
	 * e o quanto ja rodou
	 * @param sentido	lado que o objeto esta rodando
	 * @param rotacao	O quanto o objeto ja rodou
	 * @param lim	limite em graus para rotação
	 **/
	public Girar(float sentido, float rotacao,float lim)
	{
		setLado(sentido);
		setQuantoRodou(rotacao);
		setLimite (lim);
		setRodando (false);
	}
	//Construtor sem argumento
	public Girar()
	{
		setLado(0.0f);
		setQuantoRodou(0.0f);
		setLimite (0.0f);
	}
	//Gets e Sets para lado e quantoRodou
	public float getQuantoRodou()
	{
		return quantoRodou;
	}
	public void setQuantoRodou(float rotacao)
	{
		quantoRodou = rotacao;
	}
	public float getLado()
	{
		return lado; 
	}
	public void setLado(float sentido)
	{
		lado = sentido;
	}
	public float getLimite()
	{
		return limite; 
	}
	public void setLimite(float fim)
	{
		limite = fim;
	}

	public void setRodando(bool valor)
	{
		rodando = valor;
	}
	public bool getRodando()
	{
		return rodando; 
	}
}
