using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hand;
    public GameObject menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShowing() == true) {
            menu.SetActive(true);
            //Debug.Log("IN VIEW");
        }
        else {
            menu.SetActive(false);
            //Debug.Log("NOT IN VIEW");
        }
    }

    private bool isShowing() {
        //print(hand.localRotation);
        if(hand.localRotation.z >= -0.4f && hand.localRotation.z <= 0.4f) {
            if(hand.localRotation.y <= 0.9f && hand.localRotation.y >= 0.2f) {
                return true;
            }
            else {
                return false;
            }
        } else {
            return false;
        }
    }
}
