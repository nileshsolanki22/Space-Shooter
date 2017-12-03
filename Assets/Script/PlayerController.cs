using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}
public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

    private Rigidbody rb2;
    public AudioSource ac;

	void Update()
	{

		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
            ac = GetComponent<AudioSource>();
            ac.Play();
		}

	}

	void FixedUpdate()
	{

		float moveHorizontal=Input.GetAxis("Horizontal");
		float moveVertical=Input.GetAxis("Vertical");
        rb2 = GetComponent<Rigidbody>();

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb2.velocity = movement * speed;



        rb2.position = new Vector3
        (
            Mathf.Clamp(rb2.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb2.position.z, boundary.zMin, boundary.zMax)
        );
        
        rb2.rotation = Quaternion.Euler(0.0f, 0.0f, rb2.velocity.x * -tilt);
    }
}
