using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActiveGhost : MonoBehaviour
{
    [SerializeField] Text ghost;
    [SerializeField] GameObject DeathPanel;
    // Start is called before the first frame update
    void Start()
    {
        ghost.text = ""+SaveScript.activeG;    // Set the inital value of the health
    }

    // Update is called once per frame
    void Update()
    {
        ghost.text = ""+SaveScript.activeG; // It will set the value of the active ghost if updated in the scree
        if(SaveScript.activeG <= 0){
            SaveScript.activeG = 0;
            DeathPanel.gameObject.SetActive(true);
        }
    }
}
