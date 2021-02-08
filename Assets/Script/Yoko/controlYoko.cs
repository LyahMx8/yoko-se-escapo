using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlYoko : MonoBehaviour {
	Rigidbody2D rgb;
	Animator anim;
	controlCaja ctrCaja = null;
	Slay ctrEnemigo = null;
	bool onFire1 = false;
	bool onHorizontal = false;
	bool parDer = true;

	public int cosGolpe = 1; //
	public float costoGolpe = 10; //
	public int cosSalto = 1;
	public int premioCaja = 15;
	public float energy = 100;
	public float maxVel = 6f;
	public float speed = 0;
	public float jumpPow = 9.6f;
	public bool Suelando;
	private bool Jump;
	public Slider slider;
	public Text txt;

	// Use this for initialization 
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void Update(){
		anim.SetBool("Suelando", Suelando);
		anim.SetFloat("Speed", Mathf.Abs(rgb.velocity.x));
		if(Mathf.Abs (Input.GetAxis("Fire1")) > 0.01f){
			if(onFire1 == false){
				onFire1 = true;
				anim.SetTrigger("Atacar");
				if(ctrCaja != null){
					if (ctrCaja.GolpeYoko()){
						energy += premioCaja;
						if(energy > 100)
							energy = 100;
					}
				}else{
					energy -= cosGolpe;
				}
				if(ctrEnemigo != null){
					if (ctrEnemigo.GolpeYoko()){
						energy += premioCaja;
						if(energy > 100)
							energy = 100;
					}
				}else{
					energy -= cosGolpe;
				}
			}
		}else{
			onFire1 = false;
				anim.SetTrigger("Parar");
		}

		if(Mathf.Abs (Input.GetAxis("Horizontal")) > 0.01f) {
			anim.SetTrigger("Caminando");
		}else{
			anim.SetTrigger("Parar");
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && Suelando){
			Jump = true;
		}

		slider.value = energy;
		txt.text = energy.ToString();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float v = Input.GetAxis("Horizontal");
		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		v *= maxVel;
		vel.x = v;
		rgb.velocity = vel;

		if(parDer && v < 0){
			parDer = false;
			Flip();
		}else if(!parDer && v > 0){
			parDer = true;
			Flip();
		}

		if(Jump){
			rgb.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
			Jump = false;
		}
	}

	void Flip(){
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.tag == "Ground")
			Suelando = true;
	}
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground")
			Suelando = false;
	}

	public void SetControlCaja( controlCaja ctr){
		ctrCaja = ctr;
	}
	public void SetControlEnemigo( Slay ctr){
		ctrEnemigo = ctr;
	}
}