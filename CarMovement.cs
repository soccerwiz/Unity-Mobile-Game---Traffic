using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;

    public GameObject playerCar;

    public float health = 10;

    public bool move = false;

    public Transform front;
    public Transform back;
    public float sensorRadius = 0.1f;
    public LayerMask block;
    private bool frontCol;
    private bool backCol;

    public bool horizontal;
    public float speed = 10;

    private Rigidbody2D rigb;

	// Use this for initialization
	void Start () {

        rigb = GetComponent<Rigidbody2D>();

        playerCar = GameObject.FindGameObjectWithTag("Player");

        //Is the car horizontal or vertical
        if (gameObject.transform.localEulerAngles.z > 0f)
        {
            horizontal = true;
        }
        else
            horizontal = false;
	
	}
    void OnCollisionEnter2D(Collision2D collHealth)
    {
        //if (collHealth.gameObject.tag == "Car")
            //health = health - 5;
    }

    void FixedUpdate()
    {
        
        backCol = Physics2D.OverlapCircle(back.position, sensorRadius, block);

        frontCol = Physics2D.OverlapCircle(front.position, sensorRadius, block);

        //CollOffset();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        TouchMoveV2();
        Direction();
        //CollOffset();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
	
	}

    void CollOffset()
    {
        //set = GetComponent<Collider2D>().offset.x;
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        
        //Moves the collider up at high speeds to help the player tap the car
        if (playerCar.GetComponent<PlayerCar>().currentSpeed > 4f)
        {
            if (horizontal)
                col.offset = new Vector2(1, 0) / 4;
            else
                col.offset = new Vector2(0, 1) / 4;
        }
        else
            col.offset = new Vector2(0, 0);
    }
    

    void Direction()
    {
        //Determines where the car can move
        if (frontCol == true && backCol == false)
        {
            right = false;
            down = false;

            left = true;
            up = true;
        }
        else if (backCol == true && frontCol == false)
        {
            left = false;
            up = false;

            right = true;
            down = true;
        }
        else if (frontCol == true && backCol == true)
        {
            right = false;
            down = false;

            left = false;
            up = false;
        }
        else
        {
            return;
        }
        
    }

   

    void TouchMoveV2()
    {
        //Checks several factors then runs accordingly
        if (move && right && horizontal == true)
        {
            rigb.velocity = new Vector3(speed, 0, 0);
            

            if (frontCol == true)
            {
                rigb.velocity = Vector3.zero;
                move = false;
            }
        }
        else if (move && left && horizontal == true)
        {
            rigb.velocity = new Vector3(-speed, 0, 0);
            

            if (backCol == true)
            {
                rigb.velocity = Vector3.zero;
                move = false;
            }
        }
        else if (move && up && horizontal == false)
        {
            rigb.velocity = new Vector3(0, speed, 0);
            

            if (backCol == true)
            {
                rigb.velocity = Vector3.zero;
                move = false;
            }
        }
        else if (move && down && horizontal == false)
        {
            rigb.velocity = new Vector3(0, -speed, 0);
           

            if (frontCol == true)
            {
                rigb.velocity = Vector3.zero;
                move = false;
            }
        }
        else
        {
            //rigb.velocity = Vector3.zero;
            move = false;
            //rigb.angularVelocity = 0f;
        }
    }
}
