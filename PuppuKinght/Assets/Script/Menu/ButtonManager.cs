using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject continueSystem;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        continueSystem.GetComponent<ContinueSystem>().SetContinueClick(true);
    }

    public void Open(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Close(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
