using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public ObjectData data;
    public float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
