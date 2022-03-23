using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardScript : MonoBehaviour
{
    [SerializeField] Text RewardText;
    // Start is called before the first frame update
    void Start()
    {
        SaveScript.HealthChanged = false;
        RewardText.text = ""+SaveScript.reward;    // Set the inital value of the health
    }

    // Update is called once per frame
    void Update()
    {
        RewardText.text = ""+SaveScript.reward; // It will set the value of the health if updated in the scree
    }
}
