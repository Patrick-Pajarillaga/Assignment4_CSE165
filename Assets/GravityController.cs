using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 grav;
    public GameObject wee;
    private float pos;
    private float t;
    public float mult;
    public Vector3 gravy;
    public float poss;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pos = wee.transform.position.x;
        pos = pos + 1.0f;
        poss = pos;
        t = Mathf.InverseLerp(0.6f, 0.3f, pos);
        mult = Mathf.Lerp(0.1f, 10f, t);
        Physics.gravity = new Vector3(0, -9.8f, 0) * mult;
        gravy = Physics.gravity;
        
    }
}
