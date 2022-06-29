using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject continueSystem;
    public MenuCollectionManager menuCollectionManager;

    public void NewGame()
    {
        menuCollectionManager.SaveCollection();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        menuCollectionManager.SaveCollection();
        SceneManager.LoadScene(1);
        continueSystem.GetComponent<ContinueSystem>().SetContinueClick(true);
    }

    public void Open(GameObject panel)
    {
        //menuCollectionManager.SaveCollection();
        panel.SetActive(true);
    }

    public void Close(GameObject panel)
    {
        //menuCollectionManager.SaveCollection();
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        menuCollectionManager.SaveCollection();
        Application.Quit();
    }
}
