using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCollectionManager : MonoBehaviour
{
    public bool isCollectBlue;
    public bool isCollectRed;
    public bool isCollectAlpha;

    public bool isCollectGru;

    public bool isCollectVike;
    public bool isCollectSnape;
    public bool isCollectHammer;
    public bool isCollectLeon;

    //Panel
    public GameObject Blue;
    public GameObject Red;
    public GameObject Alpha;

    public GameObject Gru;

    public GameObject Vike; 
    public GameObject Snape; 
    public GameObject Hammer; 
    public GameObject Leon;
    // Start is called before the first frame update
    void Start()
    {
        LoadCollection();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollectBlue && !Blue.activeSelf)
        {
            Blue.SetActive(true);
        }

        if (isCollectRed && !Red.activeSelf)
        {
            Red.SetActive(true);
        }

        if (isCollectAlpha && !Alpha.activeSelf)
        {
            Alpha.SetActive(true);
        }

        if (isCollectGru && !Gru.activeSelf)
        {
            Gru.SetActive(true);
        }

        if (isCollectVike && !Vike.activeSelf)
        {
            Vike.SetActive(true);
        }

        if (isCollectSnape && !Snape.activeSelf)
        {
            Snape.SetActive(true);
        }

        if (isCollectHammer && !Hammer.activeSelf)
        {
            Hammer.SetActive(true);
        }

        if (isCollectLeon && !Leon.activeSelf)
        {
            Leon.SetActive(true);
        }
    }

    public void SaveCollection()
    {
        SaveSystem.SaveCollection(this);
    }

    public void LoadCollection()
    {
        MenuCollectionData data = SaveSystem.LoadCollection();

        if(data.isCollectBlue == 1)
        {
            isCollectBlue = true;
        }

        if (data.isCollectRed == 1)
        {
            isCollectRed = true;
        }

        if (data.isCollectAlpha == 1)
        {
            isCollectAlpha = true;
        }

        if (data.isCollectGru == 1)
        {
            isCollectGru = true;
        }

        if (data.isCollectVike == 1)
        {
            isCollectVike = true;
        }

        if (data.isCollectSnape == 1)
        {
            isCollectSnape = true;
        }

        if (data.isCollectHammer == 1)
        {
            isCollectHammer = true;
        }

        if (data.isCollectLeon == 1)
        {
            isCollectLeon = true;
        }
    }
}
