using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    [SerializeField]
    Transform Panel;

    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    private AudioSource OpenAudio;

    bool canOpen = false;
    bool isOpen = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isOpen)
        {
            canOpen = true;
            CanInteract.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider info)
    {
        // Destroy everything that leaves the trigger
        if ((info.gameObject.tag == "Player") && !isOpen)
        {
            canOpen = false;
            CanInteract.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && canOpen)
        {
            OpenAudio.Play();
            animator.SetBool("isOpen", true);
            isOpen = true;
            CanInteract.gameObject.SetActive(false);
            canOpen = false;
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);

        //yield return new WaitForEndOfFrame();
        Panel.gameObject.SetActive(true);
        Player.gameObject.GetComponent<PlayerControl>().CollectSword();
    }
}
