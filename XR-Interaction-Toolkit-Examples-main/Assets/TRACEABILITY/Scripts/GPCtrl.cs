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
        ObjectData[] _datas = Resources.LoadAll<ObjectData>("ObjectDatas");
        for (int i = 0; i < _datas.Length; i++)
        {
            datas.Add(_datas[i]);
        }
        table.SetActive(true);
        gameOver.SetActive(false);
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
            }
        }
    }

    public void InstantiateRandomInteractable()
    {
        int index = Random.Range(0, datas.Count);
        Interactable _interactable = Instantiate(datas[index].prefabObject, transform).GetComponent<Interactable>();
        _interactable.data = datas[index];
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
