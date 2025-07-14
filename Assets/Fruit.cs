using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    //ref to Game Manager
    private GameManager gm;
    //ref to RigidBody2D
    
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
        
    }

    //function that causes our fruit to fall using gravity
    public void gravityOn
    {
        GetComponent<Rigidbody2D>().GravityScale = 1.0f;
    }
}
                     