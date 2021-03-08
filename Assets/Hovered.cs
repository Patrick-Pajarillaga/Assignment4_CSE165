using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hovered : MonoBehaviour
{
    public GameObject baseBlock;
    public GameObject sc;
    public Transform parento;
    // Start is called before the first frame update
    private Vector3 initial;

    private bool lastButtonState = false;
    private bool onTrig = false;
    private List<InputDevice> devicesWithPrimaryButton;
    private GameObject insta = null;
    public bool gra = true;

    private void Awake()
    {
        devicesWithPrimaryButton = new List<InputDevice>();
    }
    void Start()
    {
        initial = this.GetComponent<Transform>().localScale;
    }

    private void OnEnable()
    {
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, devicesWithPrimaryButton);
    }


    // Update is called once per frame
    void Update()
    {
        bool tempState = false;
        //GameObject insta = null;
        foreach (var device in devicesWithPrimaryButton)
        {
            bool primaryButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.triggerButton, out primaryButtonState) // did get a value
                        && primaryButtonState // the value we got
                        || tempState; // cumulative result from other controllers
        }

        if (tempState != lastButtonState) // Button state changed since last frame
        {
            
            lastButtonState = tempState;
            if(lastButtonState == true && onTrig == true) {
               //print("Object Spawned");
               insta = Instantiate(baseBlock, parento.position, parento.rotation, parento); 
               insta.GetComponent<Rigidbody>().isKinematic = true;
               insta.SetActive(true);
            } else if (lastButtonState == false) {
                //print("Object Dropped");
                insta.transform.SetParent(null);
                insta.GetComponent<Rigidbody>().isKinematic = false;
                
            }
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        GoBig();
        
    }

    private void OnCollisionExit(Collision other) {
        GoBack();
    }

    private void OnTriggerEnter(Collider other) {
        GoBig();
        onTrig = true;
    }

    private void OnTriggerExit(Collider other) {
        GoBack();
        onTrig = false;
    }

    private void OnTriggerStay(Collider other) {
        
    }
    public void GoBig() {
        this.GetComponent<Transform>().localScale = this.GetComponent<Transform>().localScale * 1.1f;
    }

    public void GoBack() {
        this.GetComponent<Transform>().localScale = initial;
    }

    public void lastGrabbed(GameObject o) {
        sc.GetComponent<LastGrabbed>().last = o;
    }
}
