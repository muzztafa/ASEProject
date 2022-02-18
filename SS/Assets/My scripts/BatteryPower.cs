
// @BatteryPower.cs
// The below code is to used to drain the battery symbol if flashlight or NightVision is been used.
//It will drain the Power after every 15 seconds.
 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image BatteryUI; // Image of Battery used in UI
    [SerializeField] float DrainTime = 15.0f; // This field is used to define the time to drain per power
    [SerializeField] float Power; 

    // Update is called once per frame
    void Update()       // This function will check if the night vision or flashlight is on than the battery symbol will start decreasing.
    { 
        if(SaveScript.NightVisionLightOn || SaveScript.FlashLightOn)  
        {
            BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
            Power = BatteryUI.fillAmount;
            SaveScript.BatteryPower = Power;
        }
        
    }
}
