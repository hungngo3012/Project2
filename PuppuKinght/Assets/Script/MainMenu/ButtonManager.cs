using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {

    }

    public void Setting()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
