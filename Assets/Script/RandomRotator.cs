using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    private Rigidbody rb1;

    void Start () 
	{
        rb1 = GetComponent<Rigidbody>();
          rb1.angularVelocity = Random.insideUnitSphere * tumble;
    }
}