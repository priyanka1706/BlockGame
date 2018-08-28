using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed;
	public GameObject deathParticles;

	private float maxSpeed = 6f;
	private Vector3 input;
	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		spawn = transform.position;
	}

	// Update is called once per frame
	void Update () {

		input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
		{
			GetComponent<Rigidbody>().AddForce(input * moveSpeed);
		}

		if (transform.position.y < -2) {
			Die ();
		}

	}

	void OnCollisionEnter(Collision other) //what we hit is stored in other
	//enter hence triggered only at start
	//if you want continuous, try oncollisionstay
	{
		if (other.transform.tag=="Ogre")
		{
			Die ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Goal") {
			GameManager.CompleteLevel ();
		}
	}

	void Die()
	{
		Instantiate (deathParticles, transform.position, Quaternion.Euler (270, 0, 0));
		//method to create an instance of the object in our world.
		transform.position = spawn;
	}
}
