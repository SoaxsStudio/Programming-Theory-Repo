using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool gameActive = true;
    private int minStart = 4;
    private int maxStart = 12;
    public GameObject[] animals;
    private int maxAnimals = 50;
    public bool canSpawn = true;
    public UIManager uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GenerateInitial();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountAnimals() >= maxAnimals)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }

        if (!uiManager.gameActive)
        {
            EndGame();
        }
    }

    private void GenerateInitial()
    {
        foreach (var animal in animals)
        {
            int toGenerate = Random.Range(minStart, maxStart);
            for (int i = 0; i < toGenerate; i++)
            {
                Vector3 place = GeneratePlace();
                Instantiate(animal, place, animal.transform.rotation);
            }
        }
    }

    public Vector3 GeneratePlace()
    {
        Vector3 position = new Vector3(Random.Range(-3, 3), 0.25f, Random.Range(-2, 3));
        return position;
    }

    private int CountAnimals()
    {
        int total = (GameObject.FindGameObjectsWithTag("Beaver").Length + GameObject.FindGameObjectsWithTag("Rabbit").Length + GameObject.FindGameObjectsWithTag("Chipmunk").Length);
        return total;
    }

    public void EndGame()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Beaver"))
        {
            Destroy(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Rabbit"))
        {
            Destroy(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Chipmunk"))
        {
            Destroy(item);
        }
        Destroy(GameObject.FindGameObjectWithTag("Player"));

    }
}
