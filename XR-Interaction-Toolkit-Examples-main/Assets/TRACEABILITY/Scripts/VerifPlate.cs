using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifPlate : MonoBehaviour
{

    public ObjectData.ObjectState zoneType;
    public Interactable currentObject;

    public GameObject redLight;
    public GameObject greenLight;

    public AudioSource correctSFX;
    public AudioSource incorrectSFX;

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
            GPCtrl.instance.score += Mathf.RoundToInt(100 * 1 / currentObject.timer);
            StartCoroutine(lightUp(true));
            //add a point to the score
        } else
        {
            Debug.Log("TOO BAD, YOU GOT IT WRONG");
            StartCoroutine(lightUp(false));
            //malus ? game over ? 
        }
        Destroy(currentObject.gameObject);
        currentObject = null;
    }

    public IEnumerator lightUp(bool verif)
    {
        if(verif)
        {
            correctSFX.Play(0);
            greenLight.SetActive(true);
            yield return new WaitForSeconds(3);
            greenLight.SetActive(false);
        } else
        {
            incorrectSFX.Play(0);
            redLight.SetActive(true);
            yield return new WaitForSeconds(3);
            redLight.SetActive(false);
        }
    }

}
