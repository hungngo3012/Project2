using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueSystem : MonoBehaviour
{
    GameObject loadSystem;

    GameObject boss;

    public bool continueClick;

    private bool isLoad;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        loadSystem = GameObject.Find("Player");

        boss = GameObject.Find("BossManager");
        /*
        if(loadSystem == null)
        {
            Debug.Log("nooo");
        }*/

        if ((loadSystem != null) && continueClick && !isLoad)
        {
            ContinueActive();
        }
    }

    public void ContinueActive()
    {
        loadSystem.GetComponent<PlayerControl>().LoadPlayer();
        boss.GetComponent<BossManager>().LoadBoss();
        isLoad = true;
        //StartCoroutine(Coroutine());
    }

    public void SetContinueClick(bool val)
    {
        continueClick = val;
    }

    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        Destroy(gameObject);     

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
