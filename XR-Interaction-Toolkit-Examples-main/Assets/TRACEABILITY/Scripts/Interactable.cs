using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public ObjectData data;
    public float timer = 0;

    public List<GameObject> components;

    private void Start()
    {
        for (int i = 0; i < components.Count; i++)
        {
            components[i].transform.SetParent(null);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
