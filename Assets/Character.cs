using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    public float rotSpeed;
    public float walkSpeed;
    // Update is called once per frame
    void Update () 
	{
 
    }

	private void FixedUpdate()
	{		
        float v = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;
        pos += transform.forward * v * walkSpeed;
        rb.MovePosition(pos);

		float h = Input.GetAxis("Horizontal");
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y += h * rotSpeed;
        rb.MoveRotation(Quaternion.Euler(eulerAngles));

    }
}
