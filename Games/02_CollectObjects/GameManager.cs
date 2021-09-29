using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pickedArtifects;
    public GameObject[] artifacts;
    public UIManager uiM;

    private void Start()
    {
        uiM = FindObjectOfType<UIManager>();
        artifacts = GameObject.FindGameObjectsWithTag("Artifact");
        //Želim da mi ispiše koliko od koliko artifekata imam - to treba napraviti UI Manager
        uiM.UpdateText(pickedArtifects, artifacts.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Artifact")
        {
            pickedArtifects++;
            uiM.UpdateText(pickedArtifects, artifacts.Length);
            if(pickedArtifects == artifacts.Length)
            {
                uiM.ShowEndGame(pickedArtifects);
                Time.timeScale = 0;
                //GameObject player = GameObject.FindGameObjectWithTag("Player");
                //player.SetActive(false);
            }
            other.gameObject.SetActive(false);
        }
    }
}
