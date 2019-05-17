using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	public float shotDelay;
	private float shotDelayCounter;

	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject ninjaStar;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

		if (grounded) {
			doubleJumped = false;
		}
		anim.SetBool ("Grounded", grounded);

		if(Input.GetKeyDown (KeyCode.Space) && grounded)
		{
			Jump();
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}
	
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			Jump();
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			doubleJumped = true;
		}

		moveVelocity = 0f;

		if(Input.GetKey (KeyCode.D))
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeed;
		}


		if(Input.GetKey (KeyCode.A))
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeed;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		if (Input.GetKeyDown (KeyCode.Return)) {
			Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
		}
	}


	public void Jump()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);

	}
		
}