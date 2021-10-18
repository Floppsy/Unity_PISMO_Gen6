using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrviMijesane : MonoBehaviour
{


    // C Imaš javnu vrijednost „pokrajine“ i svaka ti daje 1 coin po sekundi.Na tipku D
    //oduzmi 50% svojih pokrajina, a na tipku A dodaj random između 1 i 5 pokrajina.
    //Neka se broj novcica ispisuje na UI, te također broj pokrajina.

    public float[] pokrajine;
    int coin = 1;
    public Text UiText;


    private void Start()
    {
        InvokeRepeating("Metoda", 1f, 1f);
        UiText.text = pokrajine.ToString();
    }

    public void Metoda()
    {
        pokrajine[1] += coin; 
        pokrajine[2] += coin; 
        pokrajine[3] += coin; 
        pokrajine[4] += coin; 
        pokrajine[5] += coin; 
        UiText.text = pokrajine.ToString();


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            pokrajine[1] *= 0.5f;
            pokrajine[2] *= 0.5f;
            pokrajine[3] *= 0.5f;
            pokrajine[4] *= 0.5f;
            pokrajine[5] *= 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Random.Range(0, pokrajine.Length);
        }
        
       
    }



}
