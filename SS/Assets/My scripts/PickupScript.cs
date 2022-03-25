/*
@PickupScript.cs
 This code is used to detect an object is nearby or not.
 If the object(weapons) is near by than it will show message to user that press E to pickup 
 If user press E than the object will get deleted from the scene.

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 5.0f; // Defines the distance between the object and player from where player can pickup. 
    [SerializeField] GameObject PickupMessage;
    [SerializeField] GameObject PlayerArms;

    float rayDistance;
    bool canSeePickup=false;
    // Start is called before the first frame update
    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
	PlayerArms.gameObject.SetActive(false); // this inactivate the pickup object display.
        rayDistance = Distance;       
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance)) // this will check whether a movement is going on for the user
        {
            if (hit.transform.tag == "Apple")       // this will check if an apple is in front, if yes than user will see a pickup dialog box and if user presses E than the apple will be deleted from game scene and count will be increased.
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    SaveScript.Apples += 1;
                }
            }
            else if (hit.transform.tag == "Knife") // this will check if an knife is in front, if yes than user will see a pickup dialog box and if user presses E than the knife will be deleted from game scene flag of knife will be set to true as weapon is picked up
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
            else if (hit.transform.tag == "Axe") // this will check if an axe is in front, if yes than user will see a pickup dialog box and if user presses E than the axe will be deleted from game scene flag of axe will be set to true  as weapon is picked up
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
            else if (hit.transform.tag == "Gun") // this will check if an gun is in front, if yes than user will see a pickup dialog box and if user presses E than the gun will be deleted from game scene flag of gun will be set to true  as weapon is picked up
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

              else if (hit.transform.tag == "Crossbow") // this will check if an gun is in front, if yes than user will see a pickup dialog box and if user presses E than the gun will be deleted from game scene flag of gun will be set to true  as weapon is picked up
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.crossbow)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.crossbow = true;
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
