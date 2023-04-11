using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "ScriptableObjects/ObjectData", order = 1)]
public class ObjectData : ScriptableObject
{
    public enum ObjectState
    {
        False = 0,
        Real = 1,
        Broken = 2
    }

    public ObjectState objectState;
    public GameObject prefabObject;
}
