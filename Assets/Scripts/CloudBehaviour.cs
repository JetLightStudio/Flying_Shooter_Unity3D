using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour {

	float levelWidth = 0f;
	float levelHeight = 0f;
	float speed = 1f;

	void Start(){
		speed = Random.Range(1f,3f);
		Vector3 v =  Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height /2));
		levelWidth = v.x + GetComponent<SpriteRenderer>().bounds.extents.x;
		levelHeight = v.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(-Time.fixedDeltaTime * speed, 0f,0f);
		if(Camera.main.transform.position.x - transform.position.x > levelWidth){
			transform.position = new Vector3(levelWidth + Camera.main.transform.position.x 
											,Random.Range(0,levelHeight * 2),transform.position.z);
			speed = Random.Range(1f,3f);
		}
	}
}
