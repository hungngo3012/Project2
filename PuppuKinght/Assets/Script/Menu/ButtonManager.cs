using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject continueSystem;
    public MenuCollectionManager menuCollectionManager;

    public GameObject ChangeScreen;

    /*
    void Update()
    {
        if (ChangeScreen == null)
        {
            ChangeScreen = GameObject.Find("ChangeScreenEffect");
            Debug.Log("noo");
        }
    }
    */
    public void NewGame()
    {
        ChangeScreen.SetActive(false);
        ChangeScreen.SetActive(true);
        menuCollectionManager.SaveCollection();
        StartCoroutine(Coroutine());
    }

    public void LoadGame()
    {
        ChangeScreen.SetActive(false);
        ChangeScreen.SetActive(true);
        menuCollectionManager.SaveCollection();
        StartCoroutine(Coroutine());
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

    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
