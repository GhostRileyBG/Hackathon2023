using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnMovement : MonoBehaviour
{
    public AudioSource rumble;
    public float minMoveDistance = 0.1f;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        float moveDistance = Vector3.Distance(transform.position, previousPosition);

        if (moveDistance >= minMoveDistance)
        {
            rumble.Play();

            previousPosition = transform.position;
        }
    }
}
