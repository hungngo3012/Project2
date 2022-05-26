using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    Transform NextPanel;

    [SerializeField]
    Transform LastPanel;

    private bool isNext;

    // Start is called before the first frame update
    void Start()
    {
        LastPanel.gameObject.SetActive(false);
        isNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && !isNext)
        {
            NextPanel.gameObject.SetActive(true);
            isNext = true;
        }
    }
}
