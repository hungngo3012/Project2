using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    //public Inventory inventory;

    public AudioMixer audioMixer;

    public static bool GameisPause = false;

    public GameObject PauseMenuUI;

    public GameObject Map;

    public GameObject Pack;

    public GameObject Quest;

    public GameObject SettingPanel;

    public Light GameLight;

    public GameObject Player;

    public GameObject Boss;

    public GameObject Chest;



    void Start()
    {
        //inventory.SetDeleteId(10);
    }

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
        SettingPanel.SetActive(false);
        PauseMenuUI.SetActive(false);
        Player.GetComponent<PlayerControl>().isPause = false;
        Time.timeScale = 1f;
        GameisPause = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Player.GetComponent<PlayerControl>().isPause = true;
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void Setting()
    {
        SettingPanel.SetActive(true);
    }

    public void SetMusic(float vol)
    {
        audioMixer.SetFloat("Music", -vol*80.0f);
    }

    public void SetSound(float vol)
    {
        audioMixer.SetFloat("SFX", -vol * 80.0f);
    }

    public void SetLight(float val)
    {
        if(val < 0.9f)
        {
            GameLight.intensity = 1.0f - 1.0f * Mathf.Sin(0.5f * Mathf.PI * val);
        }    
    }

    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }

    public void LoadMenu()
    {
        SettingPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        Player.GetComponent<PlayerControl>().SavePlayer();
        Boss.GetComponent<BossManager>().SaveBoss();
        Chest.GetComponent<ChestManager>().SaveChest();
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

    public void Open(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Close(GameObject panel)
    {
        panel.SetActive(false);
    }
}
