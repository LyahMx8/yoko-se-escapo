using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlGolpe : MonoBehaviour {

	controlYoko ctr;
	Animator anim;

	// Use this for initialization
	void Start () {
		ctr = GameObject.Find("Yoko_Sprite_2").GetComponent<controlYoko>(); //Buscar en Yoko controlYoko
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name.Equals("Boxes_0")){
			ctr.SetControlCaja(other.gameObject.GetComponent<controlCaja>());
		}
		if (other.gameObject.name.Equals("Enemigo_Sprite_0")){
			ctr.SetControlEnemigo(other.gameObject.GetComponent<Slay>());
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name.Equals("Boxes_0")){
			ctr.SetControlCaja(null);
		}
		if (other.gameObject.name.Equals("Enemigo_Sprite_0")){
			ctr.SetControlEnemigo(null);
		}
	}
}