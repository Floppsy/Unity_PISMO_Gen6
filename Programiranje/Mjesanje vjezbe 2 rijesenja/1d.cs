using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 1d : MonoBehaviour
{
    public int x = 8; //varijiabla x
    public int y = 13; //varijabla y
    private void Start() //start metoda koja u početku radi sljedeće
    {
        if (x + y < 50) //provjeravamo dali je zbroj manji od 50
        {
            x += x; //zbrajamo x samim sa sobom
        }
        if (x + y >= 50) //provjeravamo dali je zbroj veći ili jednak od 50
        {
            y += y; //zbrajamo y samim sa sobom
        }
    }
}
