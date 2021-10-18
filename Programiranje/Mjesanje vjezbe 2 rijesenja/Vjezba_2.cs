using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vjezba_2 : MonoBehaviour
{
    // Neka je x 6, a y je 7, zatim njihov zbroj uveæajte za vrijednost y. Rezultat spremate u 
    // z.Sve to nek se odvije u metodi Awake.

    int x = 6;//definiramo varijablu x koja ima vrijednost 6
    int y = 7;//definiramo varijablu y koja ima vrijednost 7
    int z;//definiramo varijablu z za rezulat

    private void Awake()//metoda awake
    {
        z = (x + y) + y;//zbrajanje x i y, zbroju dodajemo y i spremamo to u z

    }
}
