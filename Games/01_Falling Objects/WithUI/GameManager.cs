using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0; //broj bodova
    public int life = 3; //broj zivota
    public Text scoreText;
    public Text lifeText;

    private void Start()
    {
        scoreText.text = "Score is: " + score;
        lifeText.text = "Life: " + life + " / 3";
    }

    private void Update()
    {
        //Na escape ugasi igru
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void DodajScore()
    {
        score++;
        scoreText.text = "Score is: " + score;
        //scoreText.text = score;
        //scoreText.text = score + "";
        //scoreText.text = score.ToString();

        Debug.Log("<color=green>Score is: " + score + "</color> and <color=red> life is: " + life + "</color>");
    }

    public void MakniZivot()
    {
        life--;
        lifeText.text = "Life: " + life + " / 3";

        Debug.Log("<color=green>Score is: " + score + "</color> and <color=red> life is: " + life + "</color>");
        if (life <= 0)
        {
            Debug.Log("<color=red>Izgubio si. Konačni score je: " + score + "</color>");
            Application.Quit();
        }
    }

    //Metoda koja je na gumbu za izaci iz igre
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
