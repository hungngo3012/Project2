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
    Transform TakeQuestPanel;

    [SerializeField]
    private AudioSource CollectAudio;

    public Item item;

    bool canInt = false;
    bool isInteract = false;
    bool isTakeQuest = false;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isInteract && isTakeQuest)
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
        isTakeQuest = TakeQuestPanel.gameObject.GetComponent<ClosePanel>().isClosePanel();
        if ((Input.GetKeyDown(KeyCode.E)) && canInt && isTakeQuest)
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
