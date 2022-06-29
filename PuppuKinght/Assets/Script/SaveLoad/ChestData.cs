using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChestData
{
    public int isOpenChest0;
    public int isOpenChest1;
    public int isOpenChest2;
    public int isOpenChest3;
    // Start is called before the first frame update
    public ChestData(ChestManager chest)
    {
        if(chest.isOpenChest0)
        {
            isOpenChest0 = 1;
        }
        else
        {
            isOpenChest0 = 0;
        }

        if (chest.isOpenChest1)
        {
            isOpenChest1 = 1;
        }
        else
        {
            isOpenChest1 = 0;
        }

        if (chest.isOpenChest2)
        {
            isOpenChest2 = 1;
        }
        else
        {
            isOpenChest2 = 0;
        }

        if (chest.isOpenChest3)
        {
            isOpenChest3 = 1;
        }
        else
        {
            isOpenChest3 = 0;
        }
    }
}
