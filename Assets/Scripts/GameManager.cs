using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject hillPrefab;
	public Text scoreText;
	public Text bulletText;
	public int score;
	public int bulletCount;
	public int hillsToSpawn;
	List<GameObject> hillsList = new List<GameObject>();
	Vector2 spawnPosition;
	float hillWidth =0f;

	// Use this for initialization
	void Start () {
		spawnPosition = transform.position;
		hillWidth = hillPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		MakeHills();
		score = 0;
		bulletCount = 10;
	}
	
	// Update is called once per frame
	void Update () {
		score = (int) transform.position.x * 3;
		scoreText.text = "Distance: "+score+" M";
		bulletText.text = "Bullets left x"+bulletCount;
	}

	void MakeHills(){
		for(int i=0; i< hillsToSpawn; i++){
			GameObject hillTemp = Instantiate(hillPrefab, spawnPosition, hillPrefab.transform.rotation);
			hillsList.Add(hillTemp);
			spawnPosition += new Vector2(hillWidth,0f);
		}
	}

}
