using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int p1_score;
	public int p2_score;

	public TextMesh puntuacionP1;
	public TextMesh puntuacionP2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void actualizarPuntajeP1(int nuevoScore){

		p1_score += nuevoScore * 100;

		puntuacionP1.text=p1_score.ToString();



	}

	void actualizarPuntajeP2(int nuevoScore){

		p2_score += nuevoScore * 100;

		puntuacionP2.text=p2_score.ToString();

	}
}
