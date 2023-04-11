using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPCtrl : MonoBehaviour
{
    public List<ObjectData> datas;

    [SerializeField]
    private List<VerifPlate> plates;

    public void Awake()
    {
        datas.Clear();
        ObjectData[] _datas = Resources.LoadAll<ObjectData>("ObjectData");
        for (int i = 0; i < _datas.Length; i++)
        {
            datas.Add(_datas[i]);
        }
    }

    public void ValidateChoice()
    {
        Debug.Log("VALIDATE CHOICE");
        for (int i = 0; i < plates.Count; i++)
        {
            if (plates[i].currentObject != null)
            {
                plates[i].CheckPlateMatching();
            }
        }
    }

    public void InstantiateRandomInteractable()
    {
        int index = Random.Range(0, datas.Count);
        Interactable _interactable = Instantiate(datas[index].prefabObject).GetComponent<Interactable>();
        _interactable.data = datas[index];
    }
}
