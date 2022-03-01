using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSprayControl : MonoBehaviour
{
    //This class will control the blood spray and will turn on and off the spray
    [SerializeField] GameObject BloodOff;
    
    void Start()
    {
        StartCoroutine(SwitchOff());
    }

    void Update()
    {
        StartCoroutine(SwitchOff());
    }

    IEnumerator SwitchOff()
    {
        yield return new WaitForSeconds(0.2f);
        BloodOff.gameObject.SetActive(false);
    }
}
