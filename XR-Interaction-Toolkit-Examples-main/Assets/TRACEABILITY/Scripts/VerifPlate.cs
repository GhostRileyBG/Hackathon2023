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
        } else
        {
            Debug.Log("TOO BAD, YOU GOT IT WRONG");
            StartCoroutine(lightUp(false));
            //malus ? game over ? 
        }
        for (int i = 0; i < currentObject.components.Count; i++) // destroy all plates of object inspected
        {
            Destroy(currentObject.components[i]);
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
