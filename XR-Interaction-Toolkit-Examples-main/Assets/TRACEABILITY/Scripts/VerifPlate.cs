using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifPlate : MonoBehaviour
{

    public ObjectData.ObjectState zoneType;
    public Interactable currentObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("this is a " + zoneType.ToString());
        currentObject = other.GetComponent<Interactable>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Interactable>() != null && other.GetComponent<Interactable>() == currentObject)
        {
            currentObject = null;
        }
    }


    public void CheckPlateMatching()
    {
        //check if matches with data
        if (currentObject == null) return;
        if (currentObject.data.objectState == zoneType)
        {
            Debug.Log("WELL DONE THIS WAS RIGHT ");
            //add a point to the score
        } else
        {
            Debug.Log("TOO BAD, YOU GOT IT WRONG");
            //malus ? game over ? 
        }


        //spawn new object

    }

}
