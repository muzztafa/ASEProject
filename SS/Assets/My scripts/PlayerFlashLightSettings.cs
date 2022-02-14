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
        if (Input.GetKeyDown(KeyCode.N))
        {
            
            if (nightVisionActive == false)
            {
                MyVolume.profile = NightVision;
                nightVisionActive = true;
                nightVisionOverlay.gameObject.SetActive(true);
            }
            else
            {
                MyVolume.profile = Standard;
                nightVisionActive = false;
                nightVisionOverlay.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLightActive == false)
            {
                flashLightActive = true;
                flashLight.gameObject.SetActive(true);
            }
            else
            {
                flashLightActive = false;
                flashLight.gameObject.SetActive(false);
            }
        }
    }
}
