using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float spawnRest = 2f;
    public Rigidbody rb;
    public GameObject currentAnimal;
    public GameObject gameManager;
    bool canBreed;

    private void Awake()
    {
        canBreed = false;
    }

    private void Start()
    {
  
        rb = GetComponent<Rigidbody>();
        StartCoroutine(BreedRest());
        gameManager = GameObject.Find("Game Manager");
    }

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        rb.AddForce(GenerateDirection() * moveSpeed);
    }

    Vector3 GenerateDirection()
    {
        Vector3 direction = new Vector3(Random.Range(-7.5f,7.5f), 0, Random.Range(-4,5));
        return direction;
    }

    public virtual void Breed()
    {
        Instantiate(currentAnimal, gameObject.transform.position, currentAnimal.transform.rotation);
        
        gameManager.GetComponent<GameManager>().score++;
        
        if (gameManager.GetComponent<GameManager>().score > MainManager.Instance.highScore)
        {
            MainManager.Instance.highScore = gameManager.GetComponent<GameManager>().score;
        }
                
    }

    IEnumerator BreedRest()
    {
        yield return new WaitForSeconds(spawnRest);
        canBreed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") && canBreed && gameManager.GetComponent<GameManager>().canSpawn)
        {
            Breed();
            canBreed = false;
            StartCoroutine(BreedRest());
        }


    }
}
