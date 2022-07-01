using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChestManager : MonoBehaviour
{
    public bool isOpenChest0;
    public bool isOpenChest1;
    public bool isOpenChest2;
    public bool isOpenChest3;

    public bool isOpenSubChest2;

    public GameObject chest0;
    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;

    public PlayerControl Player;
    public BossManager boss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isOpenChest0)
        {
            isOpenChest0 = chest0.GetComponent<OpenChest>().isOpen;
        }

        if (!isOpenChest1)
        {
            isOpenChest1 = chest1.GetComponent<OpenChestShield>().isOpen;
        }

        if(!isOpenChest2)
        {
            isOpenChest2 = chest2.GetComponent<OpenChest>().isOpen;
        }

        if(!isOpenChest3)
        {
            isOpenChest3 = chest3.GetComponent<OpenEmptyChest>().isOpen;
        }
    }

    public void SaveChest()
    {
        SaveSystem.SaveChest(this);
    }

    public void LoadChest()
    {
        ChestData data = SaveSystem.LoadChest();

        if(data.isOpenChest0 == 1)
        {
            isOpenChest0 = true;
            chest0.GetComponent<OpenChest>().isOpen = true;
        }
        else
        {
            isOpenChest0 = false;
        }

        if (data.isOpenChest1 == 1)
        {
            isOpenChest1 = true;
            chest1.GetComponent<OpenChestShield>().isOpen = true;
        }
        else
        {
            isOpenChest1 = false;
        }

        if (data.isOpenChest2 == 1)
        {
            isOpenChest2 = true;
            chest2.GetComponent<OpenChest>().isOpen = true;
        }
        else
        {
            isOpenChest2 = false;
        }

        if (data.isOpenChest3 == 1)
        {
            isOpenChest3 = true;
            chest3.GetComponent<OpenEmptyChest>().isOpen = true;
        }
        else
        {
            isOpenChest3 = false;
        }

        if (data.isOpenSubChest2 == 1)
        {
            isOpenSubChest2 = true;
        }
        else
        {
            isOpenSubChest2 = false;
        }
    }

    public void LoadAgainAllData()
    {
        Player.LoadPlayer();
        boss.LoadBoss();
        LoadChest();
    }

    public void SaveAllData()
    {
        Player.SavePlayer();
        boss.SaveBoss();
        SaveChest();
    }
}
