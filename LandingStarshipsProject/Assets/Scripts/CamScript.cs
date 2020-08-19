using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject sideCam;

    bool mainCamUsed = true;

    void Start()
    {
        mainCam.SetActive(true);
        sideCam.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(mainCamUsed)
            {
                mainCam.SetActive(false);
                sideCam.SetActive(true);
                mainCamUsed = false;
            }else
            {
                mainCam.SetActive(true);
                sideCam.SetActive(false);
                mainCamUsed = true;
            }
            
        }
    }
}
