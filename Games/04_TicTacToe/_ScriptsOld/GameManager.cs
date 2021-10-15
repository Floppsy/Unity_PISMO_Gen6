using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Array polja za x i o")]
    public Text[] fieldList;
    [Header("Game over panel")]
    public GameObject gameOverPanel;
    [Header("Active Game Panel")]
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TMP_InputField playerOneInputName;
    public TMP_InputField playerTwoInputName;
    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;
    public TextMeshProUGUI movesText;

    [Header("Other / X & O")]
    public string side; //Može imati vrijednost x ili o
    public int moves = 1; //Na kojem smo potezu

    private void Start()
    {
        gameOverPanel.SetActive(false);
        side = "X"; //Prvi igrač uvijek kreće sa X
        moves = 1; //Prvi potez

        for (int i = 0; i < fieldList.Length; i++)
        {
            fieldList[i].text = ""; //očistim
            fieldList[i].GetComponentInParent<Button>().interactable = true; //Aktiviramo da možemo igrat
        }

        playerOneScore.text = PlayerPrefs.GetInt("ScoreOne").ToString();
        playerTwoScore.text = PlayerPrefs.GetInt("ScoreTwo").ToString();

        playerOneName.text = PlayerPrefs.GetString("playerOne");
        playerTwoName.text = PlayerPrefs.GetString("playerTwo");

        movesText.text = "Move: " + moves;
    }

    //Metoda koja mjenja tko je na potezu
    public void ChangeSide()
    {
        if(side == "X")
        {
            side = "O";
        }
        else
        {
            side = "X";
        }
    }

    //Metoda sa kojom provjeravamo imamo li pobjednika
    public void EndGame()
    {
        //0, 1, 2
        if(fieldList[0].text == side && fieldList[1].text == side && fieldList[2].text == side)
        {
            CheckWin();
        }
        //3, 4, 5
        if (fieldList[3].text == side && fieldList[4].text == side && fieldList[5].text == side)
        {
            CheckWin();
        }
        //6, 7, 8
        if (fieldList[6].text == side && fieldList[7].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        //0, 3, 6
        if (fieldList[0].text == side && fieldList[3].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        //1, 4, 7
        if (fieldList[1].text == side && fieldList[4].text == side && fieldList[7].text == side)
        {
            CheckWin();
        }
        //2, 5, 8
        if (fieldList[2].text == side && fieldList[5].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        //0, 4, 8
        if (fieldList[0].text == side && fieldList[4].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        //2, 4, 6
        if (fieldList[2].text == side && fieldList[4].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }

        ChangeSide();
    }
    
    //Nakon što smo postavili 3 u nizu ista znaka ili je nerješno pali game over panel i reci rezultat
    void CheckWin()
    {
        gameOverPanel.SetActive(true);
        //Ako je 10 potez koji je nemoguće, dakle neriješeno je
        if(moves > 9)
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "TIE!";
        }

        //X pobjedio - Prvi Player
        if(moves % 2 == 0)
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerOneName.text + " Wins!";
            //U ukupni rezultat spremi pobjedu prvoga
            PlayerPrefs.SetInt("ScoreOne", PlayerPrefs.GetInt("ScoreOne") + 1);
        }

        //O pobjedio - Drugi Player
        else
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerTwoName.text + " Wins!";
            //U ukupni rezultat spremi pobjedu drugoga
            PlayerPrefs.SetInt("ScoreTwo", PlayerPrefs.GetInt("ScoreTwo") + 1);
        }
    }

    //Poziva se na play gumb kada se unesu imena
    public void SetUpNames()
    {
        //Promjeni imena isključivo ako su unešene nove vrijednosti za imena
        if(playerOneInputName.text != "" && playerTwoInputName.text != "")
        {
            playerOneName.text = playerOneInputName.text;
            playerTwoName.text = playerTwoInputName.text;
            PlayerPrefs.SetString("playerOne", playerOneName.text);
            PlayerPrefs.SetString("playerTwo", playerTwoName.text);
        }
    }

    //Resetiram igru
    public void ResetGame()
    {
        Start();
    }
}
