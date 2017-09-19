using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour {

	public GameObject spritecharacter;
	Animator anim;
	float direccionx;
	float direccionz;

	public int contadorcosa;

	int contador;

	public float altura = 0f;
	public float proporcion = 3.18f;

	void Start () {

		anim = spritecharacter.GetComponent<Animator>();

		direccionx = transform.position.x;
		direccionz = transform.position.z;

		contador = 0;
	}
	
	void Update () {

		contador++;

		if ( direccionx < transform.position.x ){
			anim.SetBool("movimiento", true);
			spritecharacter.transform.localScale = new Vector3(-proporcion,proporcion+altura,proporcion);
		} else if ( direccionx > transform.position.x ) {
			anim.SetBool("movimiento", true);
			spritecharacter.transform.localScale = new Vector3(proporcion,proporcion+altura,proporcion);
		} else if ( direccionx == transform.position.x && direccionz == transform.position.z){
			anim.SetBool("movimiento", false);
		} else if (direccionz != transform.position.z){
			anim.SetBool("movimiento", true);
		}

		if ( contador >= contadorcosa){
			direccionx = transform.position.x;
			direccionz = transform.position.z;
			contador = 0;
		}
		spritecharacter.transform.eulerAngles = new Vector3(-45f,180f,0f);

	}
}
