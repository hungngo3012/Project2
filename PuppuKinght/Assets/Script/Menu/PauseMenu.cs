using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPause = false;

    public GameObject PauseMenuUI;

    public GameObject Map;

    public GameObject Pack;

    public GameObject Quest;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPause)
            {
                Resume();
            }
            else { Pause(); }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPause = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void Setting()
    {

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OpenMap()
    {
        Map.SetActive(true);
        Pack.SetActive(false);
        Quest.SetActive(false);
    }

    public void OpenPack()
    {
        Map.SetActive(false);
        Pack.SetActive(true);
        Quest.SetActive(false);
    }

    public void OpenQuest()
    {
        Map.SetActive(false);
        Pack.SetActive(false);
        Quest.SetActive(true);
    }
}
