using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public bool isGruDie;
    public bool isDoomDie;
    public bool isRockyDie;
    public bool isBepoDie;

    public GameObject Player;
    public GameObject Gru;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGruDieStatus(bool val)
    {
        isGruDie = true;
    }

    public void SetDoomDieStatus(bool val)
    {
        isDoomDie = true;
    }

    public void SetRockyDieStatus(bool val)
    {
        isRockyDie = true;
    }

    public void SetBepoDieStatus(bool val)
    {
        isBepoDie = true;
    }

    public void SaveBoss()
    {
        SaveSystem.SaveBoss(this);
    }

    public void LoadBoss()
    {
        BossData data = SaveSystem.LoadBoss();

        if(data.isGruDie == 1)
        {
            isGruDie = true;
        }

        if (data.isDoomDie == 1)
        {
            isDoomDie = true;
        }

        if (data.isRockyDie == 1)
        {
            isRockyDie = true;
        }

        if (data.isBepoDie == 1)
        {
            isBepoDie = true;
        }

        if(isGruDie)
        {
            Player.GetComponent<PlayerControl>().isCollectLife = true;
            Destroy(Gru);
        }
        //Debug.Log(isGruDie);
    }
}
