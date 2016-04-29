using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

    public new Rigidbody rigidbody;
    public float turnSmoothing = 2f;
    public GameObject view;
    public GameObject body;
    public float headDistance = 2f;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Jump();
	}

    void Jump()
    {
        transform.position = body.transform.position + body.transform.forward * headDistance;
    }
}
