using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//2. Napravite skriptu sa javnom vrijednoscu maxHp.
//Neka se na textu prikazuje "currentHP / maxHP".
//Kada igrac stisne tipku A neka se igracev Hp smanji za 5

public class UI_2 : MonoBehaviour
{
    public Text hpText;
    public float maxHP;
    float currentHP;
    private void Start()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        hpText.text = currentHP + "/" + maxHP;
        if(Input.GetKeyDown(KeyCode.A))
        {
            currentHP -= 5;
        }
    }
}
