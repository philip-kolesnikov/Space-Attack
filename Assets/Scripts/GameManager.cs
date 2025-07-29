using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] fruitList;

    public int SpawnRate;

    private int upcomingFruitIndex;

    public GameObject SpawnPoint;

    private bool mergingFruit = false;

    private GameObject firstFruit;

    private GameObject secondFruit;

    private float score;

    private UiManager Ui;

    [SerializeField]
    Dictionary<string, float> ScoreDictionary = new Dictionary<string, float>()
    {
        {"Fruit0", 100f},
        {"Fruit1", 200f},
        {"Fruit2", 300f},
        {"Fruit3", 400f},

    };

    void Start()
    {
        Ui = GameObject.FindGameObjectWithTag("Ui").GetComponent<UiManager>();
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

    public void FruitCollision(GameObject first, GameObject second)
    {
        if (first.GetComponent<Fruit>().fruitIndex != fruitList.Length - 1 && !mergingFruit)
        {
            firstFruit = first;
            secondFruit = second;
            mergingFruit = true;
            cretaeMergedFruit();
        }
        //CREATE NEXT FRUIT IN CYCLE
    }

    private Vector3 getFruitMidpoint()
    {
        Vector3 midpoint = Vector3.Lerp(firstFruit.gameObject.transform.position, secondFruit.gameObject.transform.position, 0.5f);
        return midpoint;
    }

    private int getNextFruitIndex()
    {
        int currentFriutIndex = firstFruit.GetComponent<Fruit>().fruitIndex;
        return currentFriutIndex + 1;
    }

    private void cretaeMergedFruit()
    {
        //find the midpoint between the fruit so we know where to put the new friend
        Vector3 newFruitPosition = getFruitMidpoint();
        //figure out which fruit is the next fruit
        int nextFruitIndex = getNextFruitIndex();
        string oldFruitName = firstFruit.name;
        //get rid of the 2 combined fruits
        firstFruit.GetComponent<Fruit>().DestroyFruit();
        secondFruit.GetComponent<Fruit>().DestroyFruit();
        //spawn in the new fruit
        GameObject fruitClone = Instantiate(fruitList[nextFruitIndex], newFruitPosition, Quaternion.identity);
        //make sure the new fruit has gravity and isnt being dragged.
        fruitClone.GetComponent<Rigidbody2D>().gravityScale = 1;
        //get ready to merge more fruit
        mergingFruit = false;

        //add score
        AddPoints(oldFruitName);
        //add sounds

        //add particles
    }

    private void AddPoints(string fruitName)
    {
        string cleanName = fruitName.Remove(fruitName.Length - 7);
        float points = ScoreDictionary[cleanName];
        score += points;
    }

}
