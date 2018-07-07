using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
public class GunBehaviour : MonoBehaviour {

	public bool startGame;
	public float shootingForce = 10f;
	public float roationForce = 10f;
	public GameObject shootingPosition;
	public GameObject gameManager;
	private LineRenderer line;
	Rigidbody2D rb;

    void Awake()
    {
        line = shootingPosition.GetComponent<LineRenderer>();
    }
	
	// Use this for initialization
	void Start () {
		startGame = false;
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && gameManager.GetComponent<GameManager>().bulletCount > 0){
			if(!startGame) {
				startGame = true;
				GetComponent<Animator>().enabled = false;
				rb.isKinematic = false;
			}
			shoot();
		}

		Vector2 newPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.material.SetTextureOffset("_MainTex", new Vector2(Time.timeSinceLevelLoad * 4f, 0f));
        line.material.SetTextureScale("_MainTex", new Vector2(newPosition.magnitude, 1f));
        line.SetPosition(0, shootingPosition.transform.position);
        line.SetPosition(1, shootingPosition.transform.position + (shootingPosition.transform.right * -30));
        line.materials[0].mainTextureScale = new Vector3(7, 1, 1);
	}

	void shoot(){
		rb.AddForce(transform.right * shootingForce,ForceMode2D.Impulse);
		rb.AddTorque(transform.rotation.z * roationForce);
		gameManager.GetComponent<GameManager>().bulletCount--;
	}

	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag.Equals("Hill")){
			rb.AddTorque(-3f * roationForce * Time.fixedDeltaTime);
		}
	}


}
