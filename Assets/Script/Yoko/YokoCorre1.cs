using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoCorre1 : MonoBehaviour {
	public float vel = 1f;
	Rigidbody2D rgb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 v = new Vector2 (vel, 0);
		rgb.velocity = v;

		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Caminando") && Random.value < 1f/(60f*3f)){
			anim.SetTrigger("Saltando");
		}else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Saltando")){
			if(Random.value < 1f / 3f){
				anim.SetTrigger("Atacando");
			}else{
				anim.SetTrigger("Caminando");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Flip ();
	}

	void Flip(){
		vel *= -1;
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}
}