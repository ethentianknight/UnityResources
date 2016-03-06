using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Vector3 offset;
    public GameObject focus;

	// Use this for initialization
	void Start () {
        offset = transform.position - focus.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = focus.transform.position + offset;
	}
}
