using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "ScriptableObjects/ObjectData", order = 1)]
public class ObjectData : ScriptableObject
{
    public enum ObjectState
    {
        Wrong = 0,
        Right = 1
    }

    public ObjectState objectState;
    public GameObject prefabObject;
}
