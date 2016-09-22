using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text pwrText;

	private Rigidbody rb;
	private int count;
	private float timer = 0;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		pwrText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		 
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("PowerUp")) 
		{
			other.gameObject.SetActive(false);
			timer = Time.time + 10;
		}
		powerUp (timer);
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 15) 
		{
			winText.text = "You win!!";
		}
	}

	void powerUp(float t)
	{
		if (Time.time <= t) {
			pwrText.text = "PWR UP";
			speed = 25;
		} else {
			pwrText.text = "";
			speed = 10;
		}
	}
}
