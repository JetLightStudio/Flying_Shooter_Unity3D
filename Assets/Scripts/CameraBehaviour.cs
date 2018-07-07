using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public Transform target;
	Vector3 offSet;

	// Use this for initialization
	void Start () {
		offSet = transform.position - target.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector2 newTarget = target.position + offSet; 
		if(transform.position.x < newTarget.x) transform.position = new Vector3(newTarget.x,transform.position.y,transform.position.z);	
	}
}
