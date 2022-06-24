using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossData
{
    public int isGruDie;

    public int isDoomDie;

    public int isRockyDie;

    public int isBepoDie;
    public BossData(BossManager boss)
    {
        if(boss.isGruDie)
        {
            isGruDie = 1;
        }
        else
        {
            isGruDie = 0;
        }

        if (boss.isDoomDie)
        {
            isDoomDie = 1;
        }
        else
        {
            isDoomDie = 0;
        }

        if (boss.isRockyDie)
        {
            isRockyDie = 1;
        }
        else
        {
            isRockyDie = 0;
        }

        if (boss.isBepoDie)
        {
            isBepoDie = 1;
        }
        else
        {
            isBepoDie = 0;
        }
    }
}
