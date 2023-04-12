using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPCtrl : MonoBehaviour
{
    public static GPCtrl instance = null;

    public List<ObjectData> datas;
    [SerializeField]
    private List<VerifPlate> plates;
    public float timer = 0;
    public float maxTime;
    public int score;
    public Text timerText;
    public Text scoreText;
    public Text finalScoreText;
    public GameObject table;
    public GameObject gameOver;
    public List<Interactable> interactables;
    public List<Interactable> interactablesWholeList;

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
    }

    private void Start()
    {
        datas.Clear();
        ObjectData[] _datas = Resources.LoadAll<ObjectData>("ObjectDatas");
        for (int i = 0; i < _datas.Length; i++)
        {
            datas.Add(_datas[i]);
        }
        table.SetActive(true);
        gameOver.SetActive(false);
        //for (int i = 0; i < interactables.Count; i++)
        //{
        //    DeactivateInteractable(interactables[i]);
        //}
        //for (int i = 0; i < interactablesWholeList.Count; i++)
        //{
        //    interactablesWholeList[i].gameObject.SetActive(false);
        //    //DeactivateInteractable(interactables[i]);
        //}
        InstantiateRandomInteractable();

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
                break;
            }
        }
    }

    public void InstantiateRandomInteractable()
    {
        int index = Random.Range(0, datas.Count);

        //GameObject _object =  //Instantiate(datas[index].prefabObject);
        while(interactablesWholeList[datas[index].refWholeListIndexPrefab].alreadyUsed)
        {
            index = Random.Range(0, datas.Count);

        }
        Interactable _interactable = interactablesWholeList[datas[index].refWholeListIndexPrefab];
        _interactable.gameObject.SetActive(true);
        Debug.Log("interactable : " + _interactable.name);
        //_interactable.transform.position = transform.position;
        _interactable.data = datas[index];
        _interactable.InitialiseInteractable();
        _interactable.alreadyUsed = true;
    }

    public void DeactivateInteractable(Interactable _interactable)
    {
        _interactable.gameObject.SetActive(false);
        _interactable.transform.position = transform.position;
        for (int i = 0; i < _interactable.components.Count; i++)
        {
            _interactable.components[i].SetActive(false);
        }
    }

    private void Update()
    {
        timerText.text = (maxTime - timer).ToString();
        scoreText.text = score.ToString();
        if (timer >= maxTime)
        {
            GameOver();
            return;
        }
        timer += Time.deltaTime;

    }

    public void GameOver()
    {
        Debug.Log("WELL DONE ! YOUR SCORE : " + score);
        timer = 0;
        table.SetActive(false);
        gameOver.SetActive(true);
        gameOver.GetComponent<AudioSource>().Play(0);
        finalScoreText.text = score.ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
