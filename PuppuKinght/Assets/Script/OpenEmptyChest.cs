using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEmptyChest : MonoBehaviour
{
    [SerializeField]
    Transform Player;

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

    void OnCollisionEnter(Collision info)
    {
        if ((info.gameObject.tag == "Player") && !isOpen)
        {
            canOpen = true;
            CanInteract.gameObject.SetActive(true);
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
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);

        //yield return new WaitForEndOfFrame();
        canOpen = false;
    }
}
