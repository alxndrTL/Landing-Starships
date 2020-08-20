using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVCAnimationController : MonoBehaviour
{

    void Start()
    {
    }

    private void Update()
    {
        /*
        transform.localRotation = Quaternion.Euler(-90, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, 90, -90); //roll neg
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(-100, 90, -90); //roll pos
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(-100, 0, 0); //pitch pos
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, 0, 0); //pitch neg
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, 135, -135);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, 45, -45);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, -135, -135);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, -40, 40);
        }
        */

        







        /*
        float rollTVC = 0;
        float pitchTVC = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rollTVC = -7;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rollTVC = 7;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pitchTVC = 7;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            pitchTVC = -7;
        }
        */

        /*
        transform.localRotation = Quaternion.Euler(-90, 0, 0);

        if (rollTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-100, 90, -90); //roll pos
        }

        if (rollTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, 90, -90); //roll neg
        }

        if (pitchTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-100, 0, 0); //pitch pos
        }

        if (pitchTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, 0, 0); //pitch neg
        }

        if (rollTVC == 7 && pitchTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-80, -135, -135);
        }
        
        if(rollTVC == 7 && pitchTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, -40, 40);
        }

        if (rollTVC == -7 && pitchTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-80, 135, -135);
        }

        if (rollTVC == -7 && pitchTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, 45, -45);
        }
        */
    }

    public void UpdateTVCAnimation(float rollTVC, float pitchTVC)
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, 135, -135);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, 45, -45);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, -135, -135);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(-80, -40, 40);
        }
        */


        transform.localRotation = Quaternion.Euler(-90, 0, 0);

        if (rollTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-100, 90, -90); //roll pos
        }

        if (rollTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, 90, -90); //roll neg
        }

        if (pitchTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-100, 0, 0); //pitch pos
        }

        if (pitchTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, 0, 0); //pitch neg
        }

        if (rollTVC == 7 && pitchTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-80, -135, -135);
        }

        if (rollTVC == 7 && pitchTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, -40, 40);
        }

        if (rollTVC == -7 && pitchTVC == 7)
        {
            transform.localRotation = Quaternion.Euler(-80, 135, -135);
        }

        if (rollTVC == -7 && pitchTVC == -7)
        {
            transform.localRotation = Quaternion.Euler(-80, 45, -45);
        }


    }

        /*
    public void UpdateTVCAnimation(float rollTVC, float pitchTVC)
    {
        if(rollTVC == 7 && rollTVCstate == 1)
        {
            return;
        }

        if (rollTVC == 0 && rollTVCstate == 0)
        {
            return;
        }

        if (rollTVC == -7 && rollTVCstate == -1)
        {
            return;
        }

        if(rollTVC == 7)
        {
            if(rollTVCstate == 0)
            {

            }else if(rollTVCstate == -1)
            {
                transform.Rotate(new Vector3(0, +10, 0));
            }

            rollTVCstate = 1;
            transform.Rotate(new Vector3(0, +10, 0));
        }

        if (rollTVC == -7)
        {
            if (rollTVCstate == 0)
            {

            }
            else if (rollTVCstate == 1)
            {
                transform.Rotate(new Vector3(0, -10, 0));
            }

            rollTVCstate = -1;
            transform.Rotate(new Vector3(0, -10, 0));
        }

        if (rollTVC == 0)
        {
            if (rollTVCstate == 1)
            {
                transform.Rotate(new Vector3(0, -10, 0));
            }
            else if (rollTVCstate == -1)
            {
                transform.Rotate(new Vector3(0, +10, 0));
            }

            rollTVCstate = 0;
        }
    }
    */
}
