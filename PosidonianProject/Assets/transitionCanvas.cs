using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionCanvas : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject levelsCanvas;
    [SerializeField] string sceneMenu;
    [SerializeField] string sceneEndless;
    [SerializeField] string sceneLevel1;
    [SerializeField] string sceneLevel2;
    [SerializeField] WaveSpawner waveController;
    public Text waves;



    private void Update()
    {
        waves.text =  waveController.waveIndex.ToString();
    }
    public void BackToMenu()
    {
        menuCanvas.SetActive(true);
        levelsCanvas.SetActive(false);
    }

    public void GoToLevels()
    {
        menuCanvas.SetActive(false);
        levelsCanvas.SetActive(true);
    }

    public void GoToEndless()
    {
        SceneManager.LoadScene(sceneEndless);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene(sceneLevel1);
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(sceneLevel2);
    }

    

    public void GoToMenu()
    {
        SceneManager.LoadScene(sceneMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
