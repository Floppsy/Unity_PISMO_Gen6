using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1. Napravite skriptu koja ima javnu varijablu string.
//U startu neka se na UI Textu prikaže unesena vrijenost varijable
public class UI_1 : MonoBehaviour
{
    public string word;
    public Text nasUIText;

    private void Start()
    {
        nasUIText.text = word;
    }
}
