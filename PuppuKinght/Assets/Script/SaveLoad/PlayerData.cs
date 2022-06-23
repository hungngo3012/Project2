using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float stamina;
    public float health;

    public int isCollectSword;
    public int isCollectShield;
    public int isCollectBomb;

    public int isCollectLife;
    public int isCollectSoul;
    public int isCollectPower;
    public int isCollectWisdom;

    public float[] position;

    public int[] isInteractNPC;

    public int isBackHammerQuest;

    public PlayerData(PlayerControl player)
    {
        stamina = player.stamina;
        health = player.hp;

        //Check collect weapon
        if (player.isCollectSword)
        {
            isCollectSword = 1;
        }
        else
        {
            isCollectSword = 0;
        }

        if (player.isCollectShield)
        {
            isCollectShield = 1;
        }
        else
        {
            isCollectShield = 0;
        }

        if (player.isCollectBomb)
        {
            isCollectBomb = 1;
        }
        else
        {
            isCollectBomb = 0;
        }

        //
        if (player.isCollectSoul)
        {
            isCollectSoul = 1;
        }
        else
        {
            isCollectSoul = 0;
        }

        if (player.isCollectLife)
        {
            isCollectLife = 1;
        }
        else
        {
            isCollectLife = 0;
        }

        if (player.isCollectPower)
        {
            isCollectPower = 1;
        }
        else
        {
            isCollectPower = 0;
        }

        if (player.isCollectWisdom)
        {
            isCollectWisdom = 1;
        }
        else
        {
            isCollectWisdom = 0;
        }

        //
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        //
        isInteractNPC = new int[4];
        if(player.isInteractNPC[0])
        {
            isInteractNPC[0] = 1;
        }
        else
        {
            isInteractNPC[0] = 0;
        }

        if (player.isInteractNPC[1])
        {
            isInteractNPC[1] = 1;
        }
        else
        {
            isInteractNPC[1] = 0;
        }

        if (player.isInteractNPC[2])
        {
            isInteractNPC[2] = 1;
        }
        else
        {
            isInteractNPC[2] = 0;
        }

        if (player.isInteractNPC[3])
        {
            isInteractNPC[3] = 1;
        }
        else
        {
            isInteractNPC[3] = 0;
        }

        //
        if(player.isBackHammerQuest)
        {
            isBackHammerQuest = 1;
        }
        else
        {
            isBackHammerQuest = 0;
        }
    }
}
