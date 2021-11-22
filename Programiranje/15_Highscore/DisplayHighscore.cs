using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public Text[] highscoreTexts; //Prikazuje u svakom textu po jedan rezultat
    public Text myHighscore; //Prikaz igračevog highscora
    [SerializeField]
    int refreshRate = 30; //vrijeme ponovog zahtjeva za highscoreom
    Highscore highscoreManager;

    private void Start()
    {
        highscoreManager = GetComponent<Highscore>();
    }

    //Ako je na istoj sceni, samo se mjenja panel
    public void OnButtonClickToUpdate()
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i + 1 + ". Loading...";
        }

        //Započni refesh rate!
        StartCoroutine(refeshScore());
    }

    public void ShowOnTextWhenHighscoreDownloaded(Highscore.highscore[] highList)
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i + 1 + ". ";
            if (highList.Length > 1)
            {
                if(i >= highList.Length)
                {
                    highscoreTexts[i].text = "Data does not exist";
                }
                else if(i < highList.Length)
                {
                    //Dodaj tekstu username i razmak sa scoreom i znakom vrijednosti za bodova (moze biti $, kg, m, bodova, a ne mora biti nita)
                    highscoreTexts[i].text += highList[i].username + " - " + highList[i].score + " m";
                }
            }
        }
        //Vaš score zasebno u igri , iako ne mora biti, ali može biti u top listi
        myHighscore.text = highscoreManager.userNick + " - " + PlayerPrefs.GetInt("Highscore");

    }

    IEnumerator refeshScore()
    {
        while(true)
        {
            highscoreManager.DownloadHighcsores();
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
