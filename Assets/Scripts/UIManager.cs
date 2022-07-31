using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayScore; 
    public TextMeshProUGUI displayTime;
    public TextMeshProUGUI timeUpText;
    public GameManager gameManager;
    public bool gameActive = true;
    private int timeLeft = 60;

    private void Start()
    {
        if (MainManager.Instance != null)
        {
            displayName.text = MainManager.Instance.userName;
        }
        DisplayScore();
        displayTime.text = "Time: " + timeLeft;
        StartCoroutine(DisplayTime());
    }

    private void Update()
    {
        DisplayScore();
    }


    public void DisplayScore()
    {
        displayScore.text = "Score: " + gameManager.score;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Debug.Log("Nope, not programmed that yet either");
    }

    IEnumerator DisplayTime()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            displayTime.text = "Time: " + timeLeft;
            if (timeLeft <= 0)
            {
                gameActive = false;
                timeUpText.gameObject.SetActive(true);
            }
        }

    }

}
