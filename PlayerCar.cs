using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {

    private Rigidbody2D rigb;

    public float maxSpeed;
    public float speed;
    public float currentSpeed;

	// Use this for initialization
	void Start () {

        rigb = GetComponent<Rigidbody2D>();
        //Car spwans moveing
        rigb.velocity = new Vector3(0, 2, 0);
	
	}
	
	// Update is called once per frame
	void Update () {

        //rigb.velocity = new Vector3(0, speed, 0);

        //transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

        //Mathf.Clamp(transform.position.x, 0, 1);
        currentSpeed = rigb.velocity.magnitude;
        
	
	}

    void FixedUpdate()
    {
        /*
        if (speed <= maxSpeed)
        {
            speed += 1;
        }
        else
        {
            speed = maxSpeed;
        }
         */

        //Moves the players car till it reaches max speed
        if (rigb.velocity.magnitude >= maxSpeed)
        {
            rigb.velocity = new Vector3(0, maxSpeed, 0);
        }
        else
            rigb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Force);
    }
}
