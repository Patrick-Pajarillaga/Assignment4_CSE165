using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToGrab : MonoBehaviour
{
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        this.gameObject.GetComponent<Outline>().enabled = false;

    }

    public void grabbed() {
        hand.GetComponent<LastGrabbed>().last = this.gameObject;
    }
}
