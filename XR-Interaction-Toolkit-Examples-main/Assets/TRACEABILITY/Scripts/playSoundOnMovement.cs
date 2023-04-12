using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnMovement : MonoBehaviour
{
    public AudioSource rumble;
    public float minMoveDistance = 0.1f;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        rumble = this.GetComponent<AudioSource>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = Vector3.Distance(transform.position, previousPosition);

        if (moveDistance >= minMoveDistance)
        {
            rumble.Play(0);

            previousPosition = transform.position;
        }
    }
}
