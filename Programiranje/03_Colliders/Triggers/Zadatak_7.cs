using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_7 : MonoBehaviour
{
    public float score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sfera")
        {
            score++;
            //Nestane sfera da ne mozemo vise puta
            other.gameObject.SetActive(false);
            //samo ugasiti collider
            //other.enabled = false;
        }
    }
}
