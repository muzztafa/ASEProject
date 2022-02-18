/*
@PlayerFlashLightSettings.cs
 This code is used to check the settings for night vision and flashlight. 
 In this code it is first check whether the player has the battery power.
 if yes then it will check for the input of the player if N is pressed than nightvision is enabled.
 if F is pressed than flashlight is enabled.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PlayerFlashLightSettings : MonoBehaviour
{
    [SerializeField] GameObject flashLight = null;
    [SerializeField] GameObject nightVisionOverlay = null;
    [SerializeField] PostProcessVolume MyVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile NightVision;
    bool flashLightActive = false;
    bool nightVisionActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
        nightVisionOverlay.gameObject.SetActive(false);
        flashLight.gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.BatteryPower > 0.0f) // This will check if battery power is greater than 0
        {
            if (Input.GetKeyDown(KeyCode.N))  // This will check if the N is pressed if yes than it will check if night vision is on if yes than it will switch it off else it will turn on.
            {

                if (nightVisionActive == false)
                {
                    MyVolume.profile = NightVision;
                    nightVisionActive = true;
                    nightVisionOverlay.gameObject.SetActive(true);
                    SaveScript.NightVisionLightOn = true;
                }
                else
                {
                    MyVolume.profile = Standard;
                    nightVisionActive = false;
                    nightVisionOverlay.gameObject.SetActive(false);
                    SaveScript.NightVisionLightOn = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F)) // This will check if the F is pressed if yes than it will check if flashlight is on if yes than it will switch it off else it will turn on.
            {
                if (flashLightActive == false)
                {
                    flashLightActive = true;
                    flashLight.gameObject.SetActive(true);
                    SaveScript.FlashLightOn = true;
                }
                else
                {
                    flashLightActive = false;
                    flashLight.gameObject.SetActive(false);
                    SaveScript.FlashLightOn = false;
                }
            }
        }
        if (SaveScript.BatteryPower <= 0.0f) // Checks if battery power is less tha 0 than it will turn of the nightvision and flashlight
        {
            MyVolume.profile = Standard;
            nightVisionActive = false;
            nightVisionOverlay.gameObject.SetActive(false);
            SaveScript.NightVisionLightOn = false;
            flashLightActive = false;
            flashLight.gameObject.SetActive(false);
            SaveScript.FlashLightOn = false;
        }
        
    }
}
