using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.gameObject.activeSelf)
        {
            StartCoroutine(Coroutine());
        }
    }
    // Update is called once per frame
    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        transform.gameObject.SetActive(false);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
