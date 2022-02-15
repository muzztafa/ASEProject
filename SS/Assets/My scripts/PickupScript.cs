using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 5.0f;
    [SerializeField] GameObject PickupMessage;

    float rayDistance;
    bool canSeePickup=false;
    // Start is called before the first frame update
    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        rayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    SaveScript.Apples += 1;
                }
            }
            else if (hit.transform.tag == "Knife")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.knife)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.knife = true;
                    }
                    
                }
            }
            else if (hit.transform.tag == "Axe")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.axe)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.axe = true;
                    }

                }
            }
            else if (hit.transform.tag == "Gun")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.gun)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.gun = true;
                    }

                }
            }
            else
            {
                canSeePickup = false;
            }
            
        }
        if (canSeePickup)
        {
            PickupMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }
        else
        {
            PickupMessage.gameObject.SetActive(false);
            rayDistance = Distance;
        }
    }
}
