using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class temaJogo : MonoBehaviour {

	public Button btnPlay;
	public Text txtNomeFase;


	public GameObject 	InfoFase; 
	public Text 		txtInfoFase;
	public GameObject	estrela1;
	public GameObject	estrela2;
	public GameObject	estrela3;

	public string[] 		nomeTema;
	public int 				numeroQuestoes;

	private int 			idTema;

	// Use this for initialization
	void Start () {
		idTema = 0;
		txtNomeFase.text = nomeTema [idTema];
		txtInfoFase.text = "Você acertou X de X questões!";
		InfoFase.SetActive(false);
		estrela1.SetActive(false);
		estrela2.SetActive(false);
		estrela3.SetActive(false);
		btnPlay.interactable = false;

	}
	

	public void selecioneTema(int i) 
	{
		idTema = i;
		PlayerPrefs.SetInt("idTema", idTema);
		txtNomeFase.text = nomeTema[idTema];
			
		int notaFinal = PlayerPrefs.GetInt("notaFinal"+idTema.ToString());
		int acertos = PlayerPrefs.GetInt("acertos"+idTema.ToString());

		if(notaFinal == 10) 
		{
			estrela1.SetActive(true);
			estrela2.SetActive(true);
			estrela3.SetActive(true);
		} 
		else if(notaFinal >= 7) 
		{
			estrela1.SetActive(true);
			estrela2.SetActive(true);
			estrela3.SetActive(false);
		}
		else if(notaFinal >= 5) 
		{
			estrela1.SetActive(true);
			estrela2.SetActive(false);
			estrela3.SetActive(false);
		}


		txtInfoFase.text = "Você acertou "+acertos.ToString()+" de "+numeroQuestoes.ToString()+" questões!";
		InfoFase.SetActive(true);
		btnPlay.interactable = true;
	
	}


	public void jogar()
	{
		Application.LoadLevel("F"+idTema.ToString());
	}









}