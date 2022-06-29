using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MenuCollectionData
{
    public int isCollectBlue;
    public int isCollectRed;
    public int isCollectAlpha;

    public int isCollectGru;

    public int isCollectVike;
    public int isCollectSnape;
    public int isCollectHammer;
    public int isCollectLeon;

    public MenuCollectionData(MenuCollectionManager collection)
    {
        if(collection.isCollectBlue)
        {
            isCollectBlue = 1;
        }
        else
        {
            isCollectBlue = 0;
        }

        if (collection.isCollectRed)
        {
            isCollectRed = 1;
        }
        else
        {
            isCollectRed = 0;
        }

        if (collection.isCollectAlpha)
        {
            isCollectAlpha = 1;
        }
        else
        {
            isCollectAlpha = 0;
        }

        if (collection.isCollectGru)
        {
            isCollectGru = 1;
        }
        else
        {
            isCollectGru = 0;
        }

        if (collection.isCollectVike)
        {
            isCollectVike = 1;
        }
        else
        {
            isCollectVike = 0;
        }

        if (collection.isCollectSnape)
        {
            isCollectSnape = 1;
        }
        else
        {
            isCollectSnape = 0;
        }

        if (collection.isCollectHammer)
        {
            isCollectHammer = 1;
        }
        else
        {
            isCollectHammer = 0;
        }

        if (collection.isCollectLeon)
        {
            isCollectLeon = 1;
        }
        else
        {
            isCollectLeon = 0;
        }
    }
    // Start is called before the first frame update

}
