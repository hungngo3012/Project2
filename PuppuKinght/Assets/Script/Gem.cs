using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    Transform Panel;

    [SerializeField]
    Transform QuestPanel;

    [SerializeField]
    Transform CollectPanel;

    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    Transform Player;

    [SerializeField]
    private AudioSource CollectAudio;

    public int typeGem;
    bool canInt = false;
    bool isInteract = false;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isInteract)
        {
            canInt = true;
            CanInteract.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider info)
    {
        // Destroy everything that leaves the trigger
        if ((info.gameObject.tag == "Player") && !isInteract)
        {
            canInt = false;
            CanInteract.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && canInt)
        {
            CollectAudio.Play();
            //animator.SetBool("isInteract", true);
            isInteract = true;
            CanInteract.gameObject.SetActive(false);
            Panel.gameObject.SetActive(true);
            QuestPanel.gameObject.SetActive(true);
            CollectPanel.gameObject.SetActive(true);
            canInt = false;
            if(typeGem == 0)
            {
                Player.gameObject.GetComponent<PlayerControl>().CollectLife(true);
            }
            //StartCoroutine(Coroutine());
        }

        if(isInteract)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);

        //yield return new WaitForEndOfFrame();

        //Player.gameObject.GetComponent<PlayerControl>().CollectSword();
    }
}
