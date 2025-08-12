using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private float currentTime = 0f;
    public float maxTime = 5f;

    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DangerZone"))
        {
            currentTime = 0;
        }

        if (collision.CompareTag("InstantGameOver"))
        {
            gm.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DangerZone"))
        {
            currentTime = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DangerZone") && gameObject.GetComponent<DragAndDrop>().draggable == false)
        {
            currentTime += Time.deltaTime;

            if (currentTime > maxTime)
            {
                gm.GameOver();
            }
        }

    }

       

}
