using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

    public GameObject currentCar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            RaycastMouse();

        RaycastTouch();
	
	}

    void RaycastMouse()
    {
        //Raycasts to the mouse down position and checks if a car/collider was hit
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            currentCar = hit.collider.gameObject;
            currentCar.GetComponent<CarMovement>().move = true;
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);

        }
        else
        {
            currentCar = null;
        }
    }

    void RaycastTouch()
    {
        //Raycasts to the touch position and checks if a car/collider was hit
        if (Input.touchCount > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

            if (hit.collider != null)
            {
                currentCar = hit.collider.gameObject;
                currentCar.GetComponent<CarMovement>().move = true;
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);

            }
            else
            {
                currentCar = null;
            }

        }
        
    }
}
