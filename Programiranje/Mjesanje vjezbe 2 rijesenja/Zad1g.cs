using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zad1g : MonoBehaviour
{
    public int elfovi;          //Broj koliko ima elfova
    public int gnomovi;         //Broj koliko ima gnomova
    public int orkovi;          //Broj koliko ima orkova
    public Text brojLikova;     //Tekst koji ce napisati na sceni broj svih likova

    public float interval = 0.03f; //Interval kojime ce se odvijati moja metoda
    
    private void Start()        //Start metoda u kojoj se poziva moja metoda
    {
        InvokeRepeating("MojaMetoda", interval, interval); //InvokeRepeating koji odvija da se moja metoda ponavlja
    }
    void MojaMetoda()           //Moja metoda koja ce u ovome slucaju sluziti kao zamjena za update metodu
    {
        
        if(elfovi + gnomovi <= orkovi) //Ako elfova i gnomova zajedno ima manje ili jednako kao orkova
        {
            elfovi += elfovi;       //Elfovi se povecavaju za broj elfova
        }
        else if( elfovi + gnomovi > orkovi) //Ako elfova i gnomova zajedno ima vise nego orkova
        {
            gnomovi /= 2;       //Gnomobi se smanjuju za 50%
        }
        brojLikova.text = "Broj elfova je: " + elfovi + "Broj gnomova je: " + gnomovi + "Broj orkova je: " + orkovi; //Tekst koji se ispisuje na UI-u koji nam govori koliko je cega ostalo
    }
}
