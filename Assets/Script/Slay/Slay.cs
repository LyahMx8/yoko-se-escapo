using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slay : MonoBehaviour {
	public float vel = -1f;
	public int energy = 100;
	public int cosGolpe = 20;
	Rigidbody2D rgb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void Update (){
		if(energy <= 0){
			energy = 0;
			anim.SetTrigger("Muere");
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 v = new Vector2 (vel, 0);
		rgb.velocity = v;

		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Caminar") && Random.value < 1f/(60f*3f)){
			anim.SetTrigger("Caminar");
		}
	}

	/*void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name.Equals("Yoko_Sprite_2")){
			controlYoko ctr = other.gameObject.GetComponent<controlYoko>();
			if(ctr != null) ctr.RecibirGolpe();
		}
		Flip ();
	}*/
	void OnTriggerEnter2D(Collider2D other){
		Flip ();
	}

	void Flip(){
		vel *= -1;
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

	public bool GolpeYoko(){
		bool resp = false;
		energy -= cosGolpe;
		anim.SetTrigger("Golpe");
		if(energy <= 0){
			anim.SetTrigger("Muere");
			resp = true;
		}
		return resp;
	}
}