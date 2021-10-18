using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vjezba_1 : MonoBehaviour
{
    // Zbrojite x koji je 17.2 i y koji je 12.32. Rješenje napišite u javnoj varijabli „Javna“

    float x = 17.2f; //definiramo varijablu x
    float y = 12.32f;//definiramo varijablu y
    public float Javna;//definiramo javnu varijablu koja služi kao rezultat

    private void Start()//metoda start
    {
        Javna = x + y;//zbrajanje varijable x i y, rezultat pohranjujemo u javnu varijablu
    }

}
