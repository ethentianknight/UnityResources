using UnityEngine;
using System.Collections;

public class BodyMovement : MonoBehaviour
{
    public GameObject PlayerHead;
    public new Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var segmentDistance = 5;
            UpdateRotation();
        if (Vector3.Distance(transform.position, PlayerHead.transform.position) > segmentDistance)
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        var speed = 10 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerHead.transform.position, speed);
    }

    void UpdateRotation()
    {
        var turnSmoothing = 5 * Time.deltaTime;
        var targetDir = PlayerHead.transform.position - transform.position;
        var newDir = Vector3.RotateTowards(transform.forward, targetDir, turnSmoothing, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
