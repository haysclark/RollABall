using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start () {
		count = 0;
		rb = GetComponent<Rigidbody> ();
		winText.text = "";
		updateCountText ();
	}

	// FixedUpdate is called once per frame before any physics calcs.
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;
		rb.AddForce (movement);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			updateCountText ();
			checkForWin ();
		}
	}

	private void checkForWin () {
		if (count < 12) {
			return;
		}

		showWinText ();
	}

	private void showWinText () {
		winText.text = "You Win!";
	}

	private void updateCountText () {
		countText.text = "Count: " + count.ToString ();
	}
}
