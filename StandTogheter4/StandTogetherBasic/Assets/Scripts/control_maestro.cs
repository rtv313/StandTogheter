using UnityEngine;
using System.Collections;

public class control_maestro : MonoBehaviour {
		
	//public int number;
	public GameObject[] p_up;
	public Transform[] sp;
	public bool[] exist;
	private int seleccion;
	private int posicion;
	private float tiempo;
	
	void Start () {
		tiempo = 5.0f;
		Invoke("spawn", tiempo);
	}
	
	void Update () {
		posicion = Random.Range(0, 3);
	}

	void spawn(){
		seleccion = Random.Range(0, 2);

		Debug.Log("pos "+posicion +" seleccion "+ posicion);
		if (exist[posicion] == false){
			Instantiate(p_up[seleccion], sp[posicion].position, Quaternion.identity);
			Invoke ("spawn", tiempo);
			exist[posicion]=true;
			p_up[seleccion].GetComponent<destroy_p_up>().pos = posicion;
			//Debug.Log("spawn "+posicion+" p_up "+seleccion);
		} else if(exist[0] == false || exist[1] == false || exist[2] == false || exist[3] == false) {
			Invoke("spawn",5);
		}
		//Debug.Log(exist[0]+ " " + exist[1] + " " + exist[2] + " " + exist[3]);
	}
}
