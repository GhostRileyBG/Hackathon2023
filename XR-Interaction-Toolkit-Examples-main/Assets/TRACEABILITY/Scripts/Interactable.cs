using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public ObjectData data;
    public float timer = 0;

    public List<GameObject> components;
    public List<Vector3> componentsTransform;
    public playSoundOnMovement soundMovement;
    public bool isInitialized = false;
    public bool alreadyUsed = false;

    private void Start()
    {
        for (int i = 0; i < components.Count; i++)
        {
            components[i].gameObject.SetActive(false);
        }
        //InitialiseObjectComponents();
        soundMovement = GetComponent<playSoundOnMovement>();
        if (soundMovement != null && data.shouldPlayBrokenSound) soundMovement.enabled = true;
        else if (soundMovement != null) soundMovement.enabled = false;
        gameObject.SetActive(false);


    }

    public void InitialiseObjectComponents()
    {

        for (int i = 0; i < components.Count; i++)
        {
            componentsTransform.Add(components[i].transform.position);
            Debug.Log("coucou");
        }
        isInitialized = true;
    }

    public void InitialiseInteractable()
    {
        //if (!isInitialized) InitialiseObjectComponents();
        for (int i = 0; i < components.Count; i++)
        {
            GameObject _object = components[i];
            //Debug.Log("object is : " + _object.name);
            _object.SetActive(true);
            //Debug.Log("transforms are : " + componentsTransform.Count);

            //Debug.Log(componentsTransform[i]);
            //_object.transform.position = componentsTransform[i];
            //_object.transform.SetParent(null);
        }


        // here put right textures
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
