using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vjezba_6 : MonoBehaviour
{
    //Ako je javni broj manji od 10, broj uvecaj za 20, a ako je broj veci od 10 umanji ga za 9

    public int x;//definiranje varijable javnog broja sa x

    private void Start()//metoda start
    {
        if (x < 10)//uvjet u kojem javni broj mora biti manji od 10
        {
            x += 20;//naredba u kojoj se javnom broju dodaje 20 i sprema se u samog sebe
        }
        else if (x > 10)//uvjet u kojem javni broj mora biti manji od 10
        {
            x -= 9;//naredba u kojoj se od javnog broja oduzima 9 i sprema se u samog sebe
        }
    }

}
