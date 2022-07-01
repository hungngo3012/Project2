using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubSceneChestManager : MonoBehaviour
{
    public bool isOpenSubChest2;

    public GameObject subChest2;

    GameObject currentPlayer;

    GameObject ChestManager;
    GameObject Player;

    bool isLoad;
    float curHp;
    float curSta;
    // Start is called before the first frame update
    void Start()
    {
        ChestData data = SaveSystem.LoadChest();
        if(data.isOpenSubChest2 == 1)
        {
            isOpenSubChest2 = true;
            if(subChest2 != null)
            {
                subChest2.GetComponent<OpenEmptyChest>().isOpen = true;
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ChestManager = GameObject.Find("ChestManager");
        if((ChestManager == null))
        {
            currentPlayer = GameObject.Find("Player");
            curHp = currentPlayer.GetComponent<PlayerControl>().hp;
            curSta = currentPlayer.GetComponent<PlayerControl>().stamina;
        }
        Scene scene = SceneManager.GetActiveScene();
        if (!isOpenSubChest2)
        {
            if(subChest2 != null)
            {
                isOpenSubChest2 = subChest2.GetComponent<OpenEmptyChest>().isOpen;
            }
        }

        if ((ChestManager != null) && !isLoad)
        {
            Player = GameObject.Find("Player");

            ChestManager.GetComponent<ChestManager>().LoadAgainAllData();

            Player.GetComponent<PlayerControl>().hp = curHp;
            Player.GetComponent<PlayerControl>().stamina = curSta;

            if (isOpenSubChest2)
            {
                ChestManager.GetComponent<ChestManager>().isOpenSubChest2 = true;
            }
            //ChestManager.GetComponent<ChestManager>().SaveAllData();
            StartCoroutine(Coroutine());
            isLoad = true;
        }

        if ((scene.buildIndex == 1) && isLoad)
        {
            Destroy(gameObject);
        }

        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            ChestManager.GetComponent<ChestManager>().SaveAllData();
        }

    }
}
