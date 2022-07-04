using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreenEffect : MonoBehaviour
{
    public bool isUsed;

    public GameObject ChangeScreen;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (ChangeScreen.activeSelf && !isUsed)
        {
            isUsed = true;
        }

        var go = GameObject.FindGameObjectsWithTag("ChangeScreen");
        if (go.Length > 1)
        {
            if(isUsed)
            {
                StartCoroutine(Coroutine());

            }
        }
    }
    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
