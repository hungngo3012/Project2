using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    [SerializeField]
    Transform Panel;

    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    Transform TakeQuestNPC;

    [SerializeField]
    Transform CheckCompletePanel;

    [SerializeField]
    private AudioSource CollectAudio;

    public Item item;

    bool canInt = false;
    bool isInteract = false;
    bool isTakeQuest = false;
    bool isCompleteQuest;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isInteract && isTakeQuest && !isCompleteQuest)
        {
            canInt = true;
            CanInteract.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isInteract && isTakeQuest)
        {
            canInt = false;
            CanInteract.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckCompletePanel.gameObject.activeSelf)
        {
            isCompleteQuest = true;
        }

        isTakeQuest = TakeQuestNPC.gameObject.GetComponent<InteractNPC>().isInteract;
        if ((Input.GetKeyDown(KeyCode.E)) && canInt && isTakeQuest && !isCompleteQuest)
        {
            CollectAudio.Play();
            //animator.SetBool("isInteract", true);
            isInteract = true;
            CanInteract.gameObject.SetActive(false);
            Panel.gameObject.SetActive(true);
            item.Add();
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);

        //yield return new WaitForEndOfFrame();
        canInt = false;
        //Player.gameObject.GetComponent<PlayerControl>().CollectSword();
    }
}
