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

    public float[] position;

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

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
