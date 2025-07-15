using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] fruitList;

    public int SpawnRate;

    private int upcomingFruitIndex;

    public GameObject SpawnPoint;

    void Start()
    {
        upcomingFruitIndex = 0;
        SpawnNewFruit();
    }

    public void SpawnNewFruit()
    {
        StartCoroutine("CreateNewFruit");
    }

    IEnumerator CreateNewFruit()
    {
        yield return new WaitForSeconds(SpawnRate);

        GameObject fruitClone = Instantiate(fruitList[upcomingFruitIndex], SpawnPoint.transform.position, Quaternion.identity);

        fruitClone.GetComponent<DragAndDrop>().draggable = true;

        upcomingFruitIndex = 0;
    }
    
}
