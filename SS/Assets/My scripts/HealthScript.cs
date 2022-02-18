/*
 @HealthScript.cs
 This script is used to check save the health of the user and display in the screen of the user
 It will check the current value of Player Health and it will display accordingly.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    [SerializeField] Text HealthText;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = SaveScript.PlayerHealth + "%";    // Set the inital value of the health
    }

    // Update is called once per frame
    void Update()
    {
        SaveScript.HealthChanged = false;               
        HealthText.text = SaveScript.PlayerHealth + "%"; // It will set the value of the health if updated in the screen
    }
}
