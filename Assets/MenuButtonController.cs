using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;

	[SerializeField] int maxIndex;
	public AudioSource audioSource;
	public ArrayScript arrayScript;

	int züge=0;
	int züge2 = 0;

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
					if(index > 0&&index !=3&&index != 6&&index !=züge){
						index --; 
					}
				}
				keyDown = true;
			}
	}else if(index==2&&Input.GetAxis ("Jump")!=0){
		if(!keyDown){
		index = 3;
		keyDown = true;	
		}
					
	}else if(index==5&&Input.GetAxis ("Jump")!=0){
		if(!keyDown){
		index = 6;
		keyDown = true;	
		}
	}else if(index==8&&Input.GetAxis ("Jump")!=0){
		if(!keyDown){
		if(züge ==1 || züge==4){
			züge++;
			
		}
		züge++;
		züge2++;
		index = 0+züge;
		arrayScript.heapinArray(züge2);	
		keyDown = true;	
		
		}
	}else if(Input.GetAxis ("Jump")!=0){
		if(!keyDown){
		arrayScript.changearraypos(index);
		keyDown= true;
		
		}
					
	}else{
			keyDown = false;
	}
}





}
