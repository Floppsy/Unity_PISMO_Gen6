using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    // WEB: https://dreamlo.com/lb/mF9M0QiyIU2SotCLFmvgEA_jMQ8hEG3Uyrs5ZcbUgNkg
    //podatke za dljnje stringove upisujemo sa stranice dreamlo.com
    //const služi kako se ta varijabla nebi više mjenjala nigdje
    const string privateCode = "mF9M0QiyIU2SotCLFmvgEA_jMQ8hEG3Uyrs5ZcbUgNkg";
    const string publicCode = "619b51958f40bb12787d0dc6";
    //Za Android i iOS potrebno imati SSL - https
    const string webURL = "http://dreamlo.com/lb/";

    [Header("Player input")]
    [SerializeField] InputField playerName;
    public string userNick;

    public DisplayHighscore displayHighscore;
    highscore[] highscoreList;

    private void Awake()
    {
        //Provjera u playerPrefsu imamo li to ime već na igraču, odnosno ima li igrač ime
        userNick = PlayerPrefs.GetString("PlayerUsername");
        displayHighscore = GetComponent<DisplayHighscore>(); //Obje skripte su na istom gameobjektu
    }

    private void Start()
    {
        //Ako user nije upisao svoje ime
        if(userNick == string.Empty) //userNick == null
        {
            userNick = "Player" + Random.Range(1000, 100000).ToString();
        }
    }

    //Igrač je upisao novo ime i želi sa tim novim imenom uploadati svoj score
    public void ChangeDataByMe()
    {
        if(playerName.text != string.Empty)
        {
            //učitati ime iz inputa
            userNick = playerName.text;
            //spremiti novo ime u PlayerPrefs
            PlayerPrefs.SetString("PlayerUsername", userNick);
            //Dodjeli higscore
            int maxScore = PlayerPrefs.GetInt("Highscore");
            //Dodaj novi highscore sa imenom i bodovima
            AddNewHighscore(userNick, maxScore);
        }
    }

    public void AddNewHighscore(string username, int score)
    {
        //Pozovi korutinu
        StartCoroutine(UploadNewHighscore(username, score));
    }

    public void DownloadHighcsores()
    {
        //Pozovi korutinu
        StartCoroutine(DownloadHighscoresFromDatabase());
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        //Na koju konekciju (na koji link) šaljemo zahtjev
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        //ako je zahtjev uspiješan - nemamo error
        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successfull");
            //Vrati nam listu highscorova
            DownloadHighcsores();
        }

        //ako je zahtjev failao i imamo error
        else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        UnityWebRequest www = new UnityWebRequest(webURL + publicCode + "/pipe/");

        /*
         * DownloadHandlerBuffer nam služi za preuzimanje podataka u bajtovima u Unity
         * potom te podatke pakira u cijelinu u našoj memoriji
         * Napomena - dok se skida je u RAM Memoriji, tek kad se skine sve složi se u cijelinu i stavlja na disk
         */

        DownloadHandlerBuffer dh = new DownloadHandlerBuffer();
        www.downloadHandler = dh;

        yield return www.SendWebRequest();

        //Ako je uspješno skinuto
        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download Successfull");
            Debug.Log(www.downloadHandler.text);
            //Formatiranje texta
            FormatHighscore(www.downloadHandler.text);
            //Prikazati ga na UI u Unityu
        }

        //Ako skidanje je nesupiješno i nije preuzeto
        else
        {
            Debug.Log("Error downloading: " + www.error);
        }
    }

    //Formatiranje skinutog sadržaja
    void FormatHighscore(string textStream)
    {
        //Složi podatke u array tako da se razdvoji svaki rad kao poseban unos
        string[] entires = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        //stvori array određene dužine
        highscoreList = new highscore[entires.Length];

        for (int i = 0; i < entires.Length; i++)
        {
            //Razdovijti sve podatke svakog reda gdje se nalazi znak "|"
            string[] entryInfo = entires[i].Split(new char[] { '|' });
            //učitaj prvi razdvojeni podatak - username
            string username = entryInfo[0];
            //učitaj drugi razdvojeni podatak - score
            int score = int.Parse(entryInfo[1]);
            //Popuni array za prikaz sa podatcima
            highscoreList[i] = new highscore(username, score);
        }
    }

    //Jedan blok memorije , a može mu se pristupiti iz više izvora ili na više načina
    public struct highscore
    {
        public string username;
        public int score;

        public highscore(string username, int scoreInput)
        {
            this.username = username;
            this.score = scoreInput;
        }
    }
}
