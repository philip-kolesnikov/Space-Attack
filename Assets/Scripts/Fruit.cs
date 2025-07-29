using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    //ref to Game Manager
    private GameManager gm;
    //ref to RigidBody2D
    private Rigidbody2D rb;
    //bool that keeps track of whether THIS fruit is combining with ANOTHER fruit
    private bool combined = false;
    //fruit index number (to identify the fruit)
    public int fruitIndex;

    // Start is called before the first frame update
    void Start()
    {
        //get Game Manager in scene
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //get component RigidBody
        rb = GetComponent<Rigidbody2D>();
    }

    //function that causes our fruit to fall using gravity
    public void gravityOn()
    {
        rb.gravityScale = 1.0f;
    }

    public void SetCombined(bool value)
    {
        combined = value;
    }

    public void DestroyFruit()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we collide with a fruit and are not combined with a fruit
        //check if we are the same kind of fruit by name
        if ((collision.gameObject.transform.name == gameObject.name) && combined == false)
        {
            SetCombined(true);
            collision.gameObject.GetComponent<Fruit>().SetCombined(true);
            gm.FruitCollision(gameObject, collision.gameObject);

            Debug.Log("Hello World, I am");
        }
    }

}
                     