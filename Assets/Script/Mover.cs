using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody rb3;

	void Start()
	{
        rb3 = GetComponent<Rigidbody>();

        //rigidbody.velocity = transform.forward * speed;

        rb3.velocity = transform.forward * speed;
	}
}
