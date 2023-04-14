using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public AudioSource click;
    public AudioSource woosh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(launch());
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public IEnumerator launch()
    {
        click.Play(0);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Game");
    }

    public void onHover()
    {
        woosh.Play(0);
    }
}
