using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class responder : MonoBehaviour {

	private int	idTema;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text infoRespostas;

	public string[] perguntas;		// ARMAZENA TODAS AS PERGUNTAS
	public string[] alternativaA;	// ARMAZENA TODAS AS ALTERNATIVAS A
	public string[] alternativaB;	// ARMAZENA TODAS AS ALTERNATIVAS B
	public string[] alternativaC;	// ARMAZENA TODAS AS ALTERNATIVAS C
	public string[] alternativaD;	// ARMAZENA TODAS AS ALTERNATIVAS D
	public string[] corretas;		// ARMAZENA TODAS AS CORRETAS

	private int idPergunta;

	private float acertos;
	private float questoes;
	private float media;
	private int	  notaFinal;

	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt("idTema");
		idPergunta = 0;
		questoes = perguntas.Length;

		pergunta.text = perguntas[idPergunta];
		respostaA.text = alternativaA[idPergunta];
		respostaB.text = alternativaB[idPergunta];
		respostaC.text = alternativaC[idPergunta];
		respostaD.text = alternativaD[idPergunta];
	
		infoRespostas.text = "Respondendo "+ (idPergunta + 1).ToString ()+ " de "+questoes.ToString()+" perguntas.";
	
	}
	
	public void resposta(string alternativa)
	{
		if(alternativa == "A") 
		{
			if(alternativaA[idPergunta] == corretas[idPergunta]) 
			{
				acertos += 1;
			}
		}
	
		else if(alternativa == "B") 
		{
			if(alternativaB[idPergunta] == corretas[idPergunta]) 
			{
				acertos += 1;
			}	 
		}
		else if(alternativa == "C") 
		{
			if(alternativaC[idPergunta] == corretas[idPergunta]) 
			{
				acertos += 1;
			}
		}
		else if(alternativa == "D") 
		{
			if(alternativaD[idPergunta] == corretas[idPergunta]) 
			{
				acertos += 1;
			}
		}
	
	
		proximaPergunta();
	
	
	}



	void proximaPergunta()
	{
		idPergunta += 1;

		if (idPergunta <= (questoes - 1)) {
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];

			infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
		} else {
			// o que fazer se terminar as perguntas
			media = 10 * (acertos / questoes);	// calcula a media com base no percentual de acertos
			notaFinal = Mathf.RoundToInt (media); // arredonda a nota para o proximo inteiro, segundo a regra da matematica.

			if (notaFinal > PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ()))
				;
			{
				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int)acertos);

			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int)acertos);

			Application.LoadLevel ("notaFinal");


		}


	}
	
	
	
	
}



