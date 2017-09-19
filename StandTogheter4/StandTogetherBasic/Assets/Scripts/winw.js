#pragma strict

var nivel : String;

function Start () {
Time.timeScale = 1;
Invoke("creditos", 7);
}

function Update () {

}

function creditos (){
	Application.LoadLevel(nivel);
}