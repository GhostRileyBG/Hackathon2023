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
    public bool alreadyUsed = false;

    private void Start()
    {
        if (GetComponent<playSoundOnMovement>() != null) soundMovement = GetComponent<playSoundOnMovement>();
        if (soundMovement != null && data.shouldPlayBrokenSound) soundMovement.enabled = true;
        else if (soundMovement != null) soundMovement.enabled = false;
        for (int i = 0; i < components.Count; i++)
        {
            componentsTransform.Add(components[i].transform.position);
        }
    }

    public void InitialiseInteractable()
    {
        gameObject.SetActive(true);
        for (int j = 0; j < components.Count; j++)
        {
            components[j].transform.position = componentsTransform[j];
        }


        // here put right textures
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
