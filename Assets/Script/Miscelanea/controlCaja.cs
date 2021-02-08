using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCaja : MonoBehaviour {

	public int numGolCaer = 3;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool GolpeYoko(){
		bool resp = false;
		numGolCaer--;
		if(numGolCaer <= 0){
			int randomNum = Random.Range(1, 5);
			anim.SetTrigger("boxing" + randomNum);
			resp = true;
		}
		return resp;
	}
}