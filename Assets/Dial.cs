using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hand;
    private Transform initial = null;
    public Quaternion init;
    public Quaternion upd;
    private Vector3 angles;
    private Vector3 before;
    private Vector3 after;
    public float temp = 0;
    public float wee = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upd = hand.GetComponent<Transform>().rotation;
        if(initial != null) {
            //print("MOVING");
            //print(hand.GetComponent<Transform>().rotation.eulerAngles.z);
            //print(initial.rotation.eulerAngles.z);
            temp = hand.GetComponent<Transform>().rotation.eulerAngles.z - angles.z;
            //print(temp);
            //temp = Vector3.Angle(hand.GetComponent<Transform>().rotation.eulerAngles, initial.rotation.eulerAngles);
            var epic = this.gameObject.transform.rotation;
            this.gameObject.transform.rotation = new Quaternion(epic.x, hand.GetComponent<Transform>().rotation.z, epic.z, epic.w);
            //hand.GetComponent<LastGrabbed>().last.transform.localScale = Math.abs(1.01f);
        }
    }

    public void initialPos() {
        initial = hand.GetComponent<Transform>();
        init = initial.rotation;
        angles = new Vector3(init.eulerAngles.x,init.eulerAngles.y,init.eulerAngles.z);
        before = this.gameObject.transform.forward;
        //print("SELECTED");
    }

    public void endPos() {
        initial = null;
        print("Deselected");
        var diff = Vector3.SignedAngle(this.gameObject.transform.forward, before, Vector3.up);
        //print(diff);
        
        if(diff > 0) {
            wee = Mathf.Abs(diff);
            wee = wee / 60f;
            hand.GetComponent<LastGrabbed>().last.transform.localScale *= wee * 5.0f;
        } else {
            wee = Mathf.Abs(diff);
            wee = wee / 360f;
            hand.GetComponent<LastGrabbed>().last.transform.localScale *= wee * 0.5f;
        }

    }
}
