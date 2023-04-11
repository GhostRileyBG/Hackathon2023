using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPCtrl : MonoBehaviour
{
    public static GPCtrl instance = null;

    public List<ObjectData> datas;
    [SerializeField]
    private List<VerifPlate> plates;
    public float timer = 0;
    public float maxTime;
    public int score;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
                InstantiateRandomInteractable();
            }
        }
    }

    public void InstantiateRandomInteractable()
    {
        int index = Random.Range(0, datas.Count);
        Interactable _interactable = Instantiate(datas[index].prefabObject).GetComponent<Interactable>();
        _interactable.data = datas[index];
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("WELL DONE ! YOUR SCORE : " + score);
    }
}
