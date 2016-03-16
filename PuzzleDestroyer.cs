using UnityEngine;
using System.Collections;

public class PuzzleDestroyer : MonoBehaviour {

    public GameObject destroyPoint;

	// Use this for initialization
	void Start () {
        destroyPoint = GameObject.Find("DestroyPoint");
	
	}
	
	// Update is called once per frame
	void Update () {
        //Deactivates objects behind the player
        if (transform.position.y < destroyPoint.transform.position.y)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
	
	}
}
