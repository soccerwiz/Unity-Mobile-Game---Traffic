using UnityEngine;
using System.Collections;

public class CarSprite : MonoBehaviour {

    public Sprite[] sprites;

    private int spriteSelector;

    // Use this for initialization
    void Start()
    { 
        //Randomises the colour of the car
        spriteSelector = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[spriteSelector];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
