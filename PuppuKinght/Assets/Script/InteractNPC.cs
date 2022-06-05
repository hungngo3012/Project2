using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC : MonoBehaviour
{
    [SerializeField]
    Transform Panel;

    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    private AudioSource TalkAudio;

    [SerializeField]
    Transform Player;

    [SerializeField]
    Transform NPC;

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
            TalkAudio.Play();
            NPC.LookAt(Player);
            //animator.SetBool("isInteract", true);
            isInteract = true;
            CanInteract.gameObject.SetActive(false);
            Panel.gameObject.SetActive(true);
            canInt = false;
            //StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);

        //yield return new WaitForEndOfFrame();

        //Player.gameObject.GetComponent<PlayerControl>().CollectSword();
    }
}
