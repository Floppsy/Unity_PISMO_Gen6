using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadatf : MonoBehaviour
{
    public int x; // neki javni broj

    private void Update()
    {
        if (x < 10) // provjera dali je javni broj manj od 10
        {
            x += 20;// broj uvecavamo za 20
        }
        else if(x>10) // provjera jel broj veci od 10
        {
            x -= 9; // umanjujemo ga za 9
        }
    }

}
