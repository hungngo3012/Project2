using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteHammerQuest : MonoBehaviour
{
    [SerializeField]
    Transform[] CheckPanel;

    [SerializeField]
    Transform Panel;

    [SerializeField]
    Transform CheckPanelParent;

    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    private AudioSource TalkAudio;

    [SerializeField]
    Transform weaponJ;

    [SerializeField]
    Transform weaponK;


    [SerializeField]
    Transform Player;


    [SerializeField]
    Transform NPC;

    public float plusDamage = 1.0f;

    bool canInt = false;
    bool isInteract = false;
    bool completeQuest = false;
    bool isPlus = false;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isInteract && completeQuest)
        {
            canInt = true;
            CanInteract.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int j = 0;
        int i = 0;
        if ((Input.GetKeyDown(KeyCode.E)) && canInt && completeQuest)
        {
            TalkAudio.Play();
            NPC.LookAt(Player);
            //animator.SetBool("isInteract", true);
            isInteract = true;
            CanInteract.gameObject.SetActive(false);
            Panel.gameObject.SetActive(true);
            CheckPanelParent.gameObject.SetActive(false);
            if (!isPlus)
            {
                weaponJ.gameObject.GetComponent<Attack>().UpdateDamage(plusDamage);
                weaponK.gameObject.GetComponent<Attack>().UpdateDamage(plusDamage * 2.0f);
            }
            isPlus = true;
            StartCoroutine(Coroutine());
        }
        while (i < CheckPanel.Length){
            if (CheckPanel[i].gameObject.activeSelf)
            {
                j++;
            }
            i++;
        }

        if(j == CheckPanel.Length)
        {
            completeQuest = true;
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