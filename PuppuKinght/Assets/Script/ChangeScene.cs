using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    Transform CanInteract;

    [SerializeField]
    PlayerControl Player;

    [SerializeField]
    BossManager BossManager;

    [SerializeField]
    ChestManager ChestManager;


    public int NextSceneIndex;
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
        if ((Input.GetKeyDown(KeyCode.E)) && canInt)
        {
            Player.SavePlayer();
            BossManager.SaveBoss();
            ChestManager.SaveChest();

            SceneManager.LoadScene(NextSceneIndex);
        }
    }
}
