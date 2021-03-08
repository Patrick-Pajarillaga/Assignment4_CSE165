using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change() {
        cam.GetComponent<LastGrabbed>().last.GetComponent<Renderer>().material = this.GetComponent<Renderer>().material; 
    }
}
