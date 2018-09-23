using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;

	private int count;
	public Text countText;
	public Text winText;
	public float speed;


	void SetCountText(){
		countText.text = "Count: " + count.ToString();
		if(count >= 9) {
			winText.text = "You win!";
		}
	}
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		winText.text = "";
		SetCountText();
	}
	
	// Happens before any physics calculation
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	rb2d.AddForce(movement * speed/2);
	}

	void OnTriggerEnter2D(Collider2D hi){
		if(hi.gameObject.CompareTag("Pickup")){
			hi.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}
}
