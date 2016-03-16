using UnityEngine;
using System.Collections;

public class PuzzleSpawnV2 : MonoBehaviour {

    public Transform spawnPoint;
    private float puzzleHeight = 5;

    private int puzzleSelector;
    //public GameObject[] puzzles;

    public ObjectPooler[] theObjectPools;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
        
        if (transform.position.y < spawnPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + puzzleHeight, transform.position.z);

            puzzleSelector = Random.Range(0, theObjectPools.Length);

            //Instantiate(puzzles[puzzleSelector], transform.position, transform.rotation);

            GameObject newPuzzle = theObjectPools[puzzleSelector].GetPooledObject();
            newPuzzle.transform.position = transform.position;
            newPuzzle.transform.rotation = transform.rotation;
            newPuzzle.SetActive(true);
           
        }
	
	}
}
