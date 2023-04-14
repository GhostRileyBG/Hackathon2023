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
    public List<Interactable> interactablesWholeList;
    public bool allowNewLimbActivation = true;

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
    }

    public void ValidateChoice()
    {
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
        List<Interactable> _interactables = interactablesWholeList.FindAll(x => !x.alreadyUsed);
        Debug.Log("number of things left : " + _interactables.Count);
        if (_interactables.Count == 0)
        {
            GameOver();
            return;
        } 

        int index = Random.Range(0, _interactables.Count-1);
        for (int i = 0; i < _interactables.Count; i++) //deactivate all
        {
            _interactables[i].gameObject.SetActive(false);
            for (int j = 0; j < _interactables[i].components.Count; j++)
            {
                _interactables[i].components[j].transform.position += new Vector3(100, 100, 100);
            }
        }
        Interactable _interactable = _interactables[index];
        _interactable.InitialiseInteractable();
        _interactable.alreadyUsed = true;
    }

    public void DeactivateInteractable(Interactable _interactable)
    {
        _interactable.gameObject.SetActive(false);
        for (int i = 0; i < _interactable.components.Count; i++)
        {
            _interactable.components[i].SetActive(false);
        }
        Debug.Log("deactivate interactable");
    }

    private void Update()
    {
        timerText.text = (maxTime - timer).ToString();
        scoreText.text = score.ToString();
        if (allowNewLimbActivation)
        {
            allowNewLimbActivation = false;
            InstantiateRandomInteractable();
        }

        if (timer >= maxTime)
        {
            GameOver();
            return;
        }
        timer += Time.deltaTime;

    }

    public void GameOver()
    {
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
