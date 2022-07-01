using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSceneManager : MonoBehaviour
{
    public PlayerControl Player;

    public bool isLoad;
    GameObject chestManager;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Player.hp = data.health;
        Player.stamina = data.stamina;

        Player.SwordDamage = data.SwordDamage;

        Player.WeaponJ.GetComponent<Attack>().damage = Player.SwordDamage;
        Player.WeaponK.GetComponent<Attack>().damage = Player.SwordDamage * 2;

        //Load Collect Weapon status
        if (data.isCollectSword == 1)
        {
            Player.CollectSword();
        }

        if (data.isCollectShield == 1)
        {
            Player.CollectShield();
        }

        if (data.isCollectBomb == 1)
        {
            Player.CollectBomb();
        }

        //Load main quest status
        if (data.isCollectLife == 1)
        {
            Player.isCollectLife = true;
        }
        if (data.isCollectPower == 1)
        {
            Player.isCollectPower = true;
        }
        if (data.isCollectSoul == 1)
        {
            Player.isCollectSoul = true;
        }
        if (data.isCollectWisdom == 1)
        {
            Player.isCollectWisdom = true;
        }

        //
        if (data.isBackHammerQuest == 1)
        {
            Player.isBackHammerQuest = true;
        }
    }
    void Start()
    {
    }

    void Update()
    {
        /*
        chestManager = GameObject.Find("ChestManager");
        
        if((chestManager != null) && !isLoad)
        {
            chestManager.GetComponent<ChestManager>().LoadChest();
            Destroy(chestManager);
            isLoad = true;
        }*/
    }
}
