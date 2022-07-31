using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_InputField input;

    public TextMeshProUGUI currentUser;
    public TextMeshProUGUI currentHighScore;


    private void Start()
    {
        currentUser.text = "Current user: " + MainManager.Instance.userName;
        currentHighScore.text = "Current high score: " + MainManager.Instance.highScore + " " + MainManager.Instance.highScoreUser;
    }

    private void Update()
    {
        GetUsername();
    }

    public void GetUsername()
    {
        if (input.text != "")
        {
            MainManager.Instance.userName = input.text;
        }
        currentUser.text = "Current user: " + MainManager.Instance.userName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        MainManager.Instance.SaveInfo();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OpenOptions()
    {
        Debug.Log("Nothing programmed for this yet!");
    }



}
