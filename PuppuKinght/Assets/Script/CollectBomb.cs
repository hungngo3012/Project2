using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBomb : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    bool isCollect = false;
    bool canCollect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Player") && !isCollect)
        {
            canCollect = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && canCollect)
        {
            Player.gameObject.GetComponent<PlayerControl>().CollectBomb();
        }
    }
}
