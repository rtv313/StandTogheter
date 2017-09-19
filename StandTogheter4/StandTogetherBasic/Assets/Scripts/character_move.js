#pragma strict


// Especificar en el editor cual control es 1 o 2

public var player1 : boolean;
public var player2 : boolean;

// Movimiento player1 

private var up : boolean;
private var down : boolean;
private var right : boolean;
private var left : boolean;

// Movimiento player2

private var up_p2 : boolean;
private var down_p2 : boolean;
private var right_p2 : boolean;
private var left_p2 : boolean;

// Veocidad del movimiento

public var speed_p1 : float;
public var speed_p2 : float;

// Llamado

public var call : GameObject;

// Estados

private var pos1 : Vector3;
private var pos2 : Vector3;
private var pos3 : Vector3;
private var pos4 : Vector3;
private var pos5 : Vector3;

// Color flash

private var colorStart : Color = Color.white;
private var colorEnd : Color = Color.green;
private var duration : float;

// power ups

var player_material : GameObject;
private var invulnerable : boolean;
private var flashing_progress : float;


function Start () {
	
	// Para que no se mueva desde el principio
	
	up = false;
	down = false;
	right = false;
	left = false;
	
	up_p2 = false;
	down_p2 = false;
	right_p2 = false;
	left_p2 = false;
	
	//llama a la funcion para salvar la primera posicion
	
	Invoke ("posicion1",1);
	
	invulnerable = false;
	flashing_progress= 0;
}

function Update () {
	
	// Listener de eventos
	
	var move_control : CharacterController = GetComponent(CharacterController);
	if (player1 == true){
		if (Input.GetKeyDown (KeyCode.LeftControl)){
			Debug.Log("call");
			Instantiate (call, Vector3( transform.position.x, transform.position.y -3,transform.position.z -0.1), Quaternion.identity);
		}
		
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
		
		
		
	} else if (player2 == true){
		
	}
	
	
	//   Movimiento
	
	// Para p1
	
	if (up == true){
			move_control.Move(Vector3(0,0,speed_p1));
		} else if(down == true){
			move_control.Move(Vector3(0,0,-speed_p1));
		} else if(right == true){
			move_control.Move(Vector3(speed_p1,0,0));
		} else if(left == true){
			move_control.Move(Vector3(-speed_p1,0,0));
		}
	
	
	// P - ups
	
	if (invulnerable == true){
		var flashing_progress : float = Mathf.PingPong (Time.time, 0.3) / 0.3;
       	player_material.renderer.material.color = Color.Lerp(Color.gray,Color.white,flashing_progress);
       	Invoke("power_end", 5);
	}
	
	
}

function OnTriggerEnter ( c:Collider){

	if ( c.tag == "invulnerabilidad"){
		invulnerable = true;
	}
}

function power_end(){
	invulnerable = false;
	player_material.renderer.material.color = Color.white;
}

function posicion1(){
	if (pos1 != transform.position);
	pos1 = transform.position;
	
	Invoke("posicion1", 1);
	
	Invoke("posicion2", 1);
}

function posicion2(){
	if (pos2 != pos1);
	pos2 = pos1;
	Invoke("posicion2", 1);
}

