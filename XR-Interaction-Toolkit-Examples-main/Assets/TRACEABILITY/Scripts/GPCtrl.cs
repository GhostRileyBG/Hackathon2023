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
    public Text timerText;
    public float maxTime;
    public int score;
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
        ObjectData[] _datas = Resources.LoadAll<ObjectData>("ObjectData");
        for (int i = 0; i < _datas.Length; i++)
        {
            datas.Add(_datas[i]);
        }
        table.SetActive(true);
        gameOver.SetActive(false);
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
        timerText.text = (maxTime - timer).ToString();
        scoreText.text = score.ToString();
        if (timer >= maxTime)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        table.SetActive(false);
        gameOver.SetActive(true);
        finalScoreText.text = score.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Interaction Menu");
    }
}
