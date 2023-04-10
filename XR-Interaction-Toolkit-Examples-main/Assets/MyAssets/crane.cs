using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class crane : MonoBehaviour
{
    public GameObject joint;
    public GameObject upper;
    public GameObject lower;
    public SpringJoint ball;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 0.075f;
    }

    public void OnJoystickMovementChangeX(float x)
    {
        if(x > 0 && joint.transform.localPosition.z < 2.85f)
        {
            joint.transform.localPosition += new Vector3(0, 0, x * movementSpeed);
            upper.transform.localPosition += new Vector3(0, 0, x * movementSpeed);
        }
        if (x < 0 && joint.transform.localPosition.z > -1.85f)
        {
            joint.transform.localPosition += new Vector3(0, 0, x * movementSpeed);
            upper.transform.localPosition += new Vector3(0, 0, x * movementSpeed);
        }
    }
    public void OnJoystickMovementChangeY(float y)
    {
        if (y > 0 && joint.transform.localPosition.x > -4.1f)
        {
            joint.transform.localPosition += new Vector3(y * -movementSpeed, 0, 0);
            lower.transform.localPosition += new Vector3(y * -movementSpeed, 0, 0);
        }
        if (y < 0 && joint.transform.localPosition.x < 0.6f)
        {
            joint.transform.localPosition += new Vector3(y * -movementSpeed, 0, 0);
            lower.transform.localPosition += new Vector3(y * -movementSpeed, 0, 0);
        }
    }
    public void OnJoystickHeightChange(float h)
    {
        ball.spring = Mathf.Exp(h) * 11;
    }
}
