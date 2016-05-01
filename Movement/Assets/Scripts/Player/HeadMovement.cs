using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

    public GameObject ViewCamera;
    public GameObject Body;
    private new Rigidbody Head;
    private float HeadDistance = 3.25f;

    // Use this for initialization
    void Start () {
        Head = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        JumpPosition();
        AlignHead();
	}

    void AlignHead()
    {
        Quaternion bodyRotation = Body.transform.rotation;
        Quaternion rotation = ViewCamera.transform.rotation;
        if (rotation.x > 0.03f)
        {
            rotation.x = 0.03f;
        }
        //TODO: If head is rotating past body, stop it
        //TODO: If body is moving a direction, move slightly that direction.
        var targetRotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
        transform.rotation = targetRotation;
    }

    void JumpPosition()
    {
        transform.position = Body.transform.position + Body.transform.forward * HeadDistance;
    }
}
