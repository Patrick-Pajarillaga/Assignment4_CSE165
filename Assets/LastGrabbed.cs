using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastGrabbed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject last;
    public GameObject previous;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(last != null) {
            if(last == previous) {
                last.GetComponent<Outline>().enabled = true;
                previous = last;
                
            }
        }
    }
}
