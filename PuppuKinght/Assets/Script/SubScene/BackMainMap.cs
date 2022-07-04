using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackMainMap : MonoBehaviour
{
    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    PlayerControl Player;

    GameObject ChangeScreenEffect;
    bool canInt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player"))
        {
            canInt = true;
            CanInteract.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider info)
    {
        // Destroy everything that leaves the trigger
        if ((info.gameObject.tag == "Player"))
        {
            canInt = false;
            CanInteract.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeScreenEffect == null)
        {
            ChangeScreenEffect = GameObject.Find("ChangeScreen");
        }

        if ((Input.GetKeyDown(KeyCode.E)) && canInt)
        {
            ChangeScreenEffect.SetActive(false);
            ChangeScreenEffect.SetActive(true);
            StartCoroutine(Coroutine());
        }
    }
    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
