using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vjezba_4 : MonoBehaviour
{
    //x je velièine 8, a y je velièine 13, ako je njihov zbroj manji od 50 neka se x poveæa za 
    //samoga sebe, ako je veæi ili jednak neka se y poveæa za samoga sebe

    int x = 8;//definiranje varijable x
    int y = 13;//definiranje varijable y
    int rez;//definiranje varijable rezultat u koji ćemo spremati zbroj x i y

    private void Start()//metoda start
    {
        rez = x + y;//zbrajanje x i y, spremanje zbroja u rezultat

        if(rez < 50)//uvjet u kojem rezultat mora biti manji od 50
        {
            x += x;//naredba koja x zbraja sa samim sobom i sprema ga u x
        }
        else if (rez >= 50)//uvjet u kojem rezultat mora biti veći ili jednak 50
        {
            y += y;//naredba koja y zbraja sa samim sobom i sprema ga u y
        }
    }

}
