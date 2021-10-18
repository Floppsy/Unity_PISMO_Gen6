using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vjezba_5 : MonoBehaviour
{
    // Vrijednost x je -3.6, a vrijednost y je 10, ako je njihov umnožak (množe se ) veæi od 
    //100 neka se x uveæa za taj umnožak, ako je manji od 100 neka se y uveæa za
    //umnožak, a ako su jednaki 100 onda neka se i x i y uveæaju za sami sebe.

    float x = -3.6f;//definiranje varijable x
    float y = 10;//definiranje varijable y
    float umnozak;//definiranje varijable u koju ćemo spremiti umnožak

    private void Start()//metoda start
    {
        umnozak = x * y;//množenje x i y, te spremanje umnoška u umnozak varijablu
        if (umnozak > 100)//uvjet u kojem umnozak treba biti veci od 100
        {
            x += umnozak;//naredba u kojoj x zbrajamo sa umnoskom i spremamo ga u x
        }
        else if (umnozak < 100)//uvjet u kojem umnozak treba biti manji od 100
        {
            y += umnozak;//naredba u kojoj y zbrajamo sa umnoškom i spremamo ga u y
        }
        else//uvjet koji se događa u svim ostalim slučajevima, jedini mogući u ovom slučaju je da umnozak bude jednak 100
        {
            x += x;//naredba u kojoj se x dodaje samom sebi i sprema se u x
            y += y;//naredba u kojoj se y dodaje samom sebi i sprema se u y
        }
    }

}
