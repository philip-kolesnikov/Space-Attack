using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private Fruit fruit;
    private Camera cam;
    private Vector3 dragOffset;
    public bool draggable;

    private GameManager gm;

    public float followSpeed;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
        fruit = GetComponent<Fruit>();
    }

    private void OnMouseUp()
    {
        //drop the object
        Drop();
    }

    //function that controls when the mouse button is down
    private void OnMouseDown()
    {
        
        dragOffset = transform.position - getMousePos();
    }

    //fucntion that controls when the mouse is held down (dragging)
    private void OnMouseDrag()
    {
        //if we can drag object
        if (draggable)
        {
            transform.position = Vector3.MoveTowards(transform.position, getMousePos() + dragOffset, followSpeed * Time.deltaTime);
        }
        //set the position of object to mouses position
    }

    //function that gets the mouse position
    private Vector3 getMousePos()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    //function that controls what happens when we drop the game object
    public void Drop()
    {
        if (draggable)
        {
            draggable = false;
            gm.SpawnNewFruit();
        }
        fruit.gravityOn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && draggable == true)
        {
            Drop();
        }
    }

}