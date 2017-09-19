using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	// Especificar en el editor cual control es 1 o 2
	
	public bool player1;
	public bool player2;
	
	// Movimiento player1 
	
	private bool up;
	private bool down;
	private bool right;
	private bool left;
	
	// Movimiento player2
	
	private bool up_p2;
	private bool down_p2;
	private bool right_p2;
	private bool left_p2;
	
	// Veocidad del movimiento
	
	public float speed;
	
	// Llamado
	
	//public GameObject call;
	
	// Estados
	
	private Vector3 pos1;
	private Vector3 pos2;
	private Vector3 pos3;
	private Vector3 pos4;
	private Vector3 pos5;
	
	// Color flash
	
	//private Color colorStart = Color.white;
	//private Color colorEnd = Color.green;
	private Color duration;
	
	// power ups
	
	public GameObject player_material;
	public bool invulnerable;
	private float flashing_progress;


	void Start () {



		// Para que no se mueva desde el principio
		
		up = false;
		down = false;
		right = false;
		left = false;
		
		up_p2 = false;
		down_p2 = false;
		right_p2 = false;
		left_p2 = false;
		
		invulnerable = false;
		flashing_progress= 0.0f;

		obtenerCiudadanos ciudadanos = gameObject.GetComponent<obtenerCiudadanos>();
	}
	

	void Update () {


		// Listener de eventos
		
		CharacterController move_control = GetComponent<CharacterController>();
		if (player1 == true){
			if (Input.GetKeyDown (KeyCode.LeftControl)){
				//Instantiate (call, new Vector3( transform.position.x + 0.0f, transform.position.y -3.0f,transform.position.z -0.1f), Quaternion.identity);
			}
			/*
			if (Input.GetKeyDown("w")){
				up=true;
			} else if(Input.GetKeyDown("s")){
				down=true;
			} else if(Input.GetKeyDown("a")){
				left = true;
			} else if(Input.GetKeyDown("d")){
				right = true;
			}
			
			
			if (Input.GetKeyUp("w")){
				up=false;
			} else if(Input.GetKeyUp("s")){
				down=false;
			} else if(Input.GetKeyUp("a")){
				left= false;
			} else if(Input.GetKeyUp("d")){
				right=false;
			}

			*/

			if ( Time.timeScale != 0){
				if (Input.GetKey("w")){
					up= true;
				} else if (!Input.GetKey("w")){
					up= false;
				}
				if (Input.GetKey("s")){
					down= true;
				} else if (!Input.GetKey("s")){
					down= false;
				}
				if (Input.GetKey("a")){
					left= true;
				} else if (!Input.GetKey("a")){
					left= false;
				}
				if (Input.GetKey("d")){
					right= true;
				} else if (!Input.GetKey("d")){
					right= false;
				}
			}
		
		} else if (player2 == true){



			if ( Time.timeScale != 0){
				if (Input.GetKey(KeyCode.UpArrow)){
					up_p2= true;

				} else if (!Input.GetKey(KeyCode.UpArrow)){
					up_p2= false;
				}
				if (Input.GetKey(KeyCode.DownArrow)){
					down_p2= true;
				} else if (!Input.GetKey(KeyCode.DownArrow)){
					down_p2= false;
				}
				if (Input.GetKey(KeyCode.RightArrow)){
					right_p2= true;
				} else if (!Input.GetKey(KeyCode.RightArrow)){
					right_p2= false;
				}
				if (Input.GetKey(KeyCode.LeftArrow)){
					left_p2= true;
				} else if (!Input.GetKey(KeyCode.LeftArrow)){
					left_p2= false;
				}
			}
		}
		
		if (Time.timeScale == 0){
			up=false;
			up_p2=false;
			down=false;
			down_p2=false;
			right=false;
			right_p2=false;
			left=false;
			left_p2=false;
		}

		//   Movimiento
		
		// Para p1
		if (player1 == true){
			if (up == true){
				move_control.Move(new Vector3(0.0f,0.0f,speed));
			} else if(down == true){
				move_control.Move(new Vector3(0.0f,0.0f,-speed));
			} else if(right == true){
				move_control.Move(new Vector3(speed,0.0f,0.0f));
			} else if(left == true){
				move_control.Move(new Vector3(-speed,0.0f,0.0f));
			}
		}

		// Para p2

		if (player2 == true){
			if (up_p2 == true){
				Debug.Log("MOV PLAYER2"+ up_p2+ down_p2);
				move_control.Move(new Vector3(0.0f,0.0f,speed));
			} else if(down_p2 == true){
				move_control.Move(new Vector3(0.0f,0.0f,-speed));
			} else if(right_p2 == true){
				move_control.Move(new Vector3(speed,0.0f,0.0f));
			} else if(left_p2 == true){
				move_control.Move(new Vector3(-speed,0.0f,0.0f));
			}
		}

		// P - ups
		
		if (invulnerable == true){
			float flashing_progress = Mathf.PingPong (Time.time, 0.3f) / 0.3f;
			player_material.renderer.material.color = Color.Lerp(Color.gray,Color.white,flashing_progress);

		}





	}


	void OnTriggerEnter (Collider c){
		
		if ( c.tag == "invulnerabilidad"){
			invulnerable = true;
			Invoke("invulnerabilidad_fin", 5);
			c.SendMessage("destruccion");
			c.GetComponent<informarRespawn>().SendMessage("llamarSpawn");
			Destroy(c.gameObject);
			obtenerCiudadanos ciudadanos = gameObject.GetComponent<obtenerCiudadanos>();

			ciudadanos.invulnerable=true;
			}

		if (c.tag == "velocidad"){
			speed *= 2.0f;
			Invoke("velocidad_fin",5);
			obtenerCiudadanos ciudadanos = gameObject.GetComponent<obtenerCiudadanos>();
			ciudadanos.velocidadActivada = true;
			c.GetComponent<informarRespawn>().SendMessage("llamarSpawn");
			ciudadanos.SendMessage ("cambiarVelocidadCiudadanos", 35);
			Destroy(c.gameObject);

		}
	}
	
	void invulnerabilidad_fin(){
		invulnerable = false;
		player_material.renderer.material.color = Color.white;

		obtenerCiudadanos ciudadanos = gameObject.GetComponent<obtenerCiudadanos>();

		ciudadanos.invulnerable = false;
	}

	void velocidad_fin (){
		speed /= 2.0f;

		obtenerCiudadanos ciudadanos = gameObject.GetComponent<obtenerCiudadanos>();
		
		ciudadanos.SendMessage ("cambiarVelocidadCiudadanos", 15);

		ciudadanos.velocidadActivada = false;
	}

}
