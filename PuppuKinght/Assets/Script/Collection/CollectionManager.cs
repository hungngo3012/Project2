using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public bool isCollectBlue;
    public bool isCollectRed;
    public bool isCollectAlpha;

    public bool isCollectGru;

    public bool isCollectVike;
    public bool isCollectSnape;
    public bool isCollectHammer;
    public bool isCollectLeon;

    GameObject MenuCollectionManager;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MenuCollectionManager = GameObject.Find("MenuCollectionManager");
        if(MenuCollectionManager != null)
        {
            if(isCollectBlue)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectBlue = true;
            }

            if(isCollectRed)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectRed = true;
            }

            if(isCollectAlpha)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectAlpha = true;
            }

            if (isCollectGru)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectGru = true;
            }

            if (isCollectVike)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectVike = true;
            }

            if (isCollectSnape)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectSnape = true;
            }

            if (isCollectHammer)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectHammer = true;
            }

            if (isCollectLeon)
            {
                MenuCollectionManager.GetComponent<MenuCollectionManager>().isCollectLeon = true;
            }
        }
    }
}
