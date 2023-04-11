using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifPlate : MonoBehaviour
{
    public enum ZoneType
    {
        False = 0,
        Real = 1
    }
    public ZoneType zoneType;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("this is a " + zoneType.ToString());
    }
}
