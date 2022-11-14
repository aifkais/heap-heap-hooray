using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis ("Horizontal") != 0){
			if(!keyDown){
				if (Input.GetAxis ("Horizontal") < 0) {
					if(index < maxIndex&&index!=2&&index!=5){
						index++;
					}
				} else if(Input.GetAxis ("Horizontal") > 0){
					if(index > 0&&index !=3&&index != 6){
						index --; 
					}
				}
				keyDown = true;
			}
		}else{
			keyDown = false;
		}
	if(index==2&&Input.GetAxis ("Jump")>0){
						index = 3;
	}else if(index==5&&Input.GetAxis ("Jump")>0){
						index = 6;
	}else if(index==8&&Input.GetAxis ("Jump")>0)
						index = 0;
	}

}
