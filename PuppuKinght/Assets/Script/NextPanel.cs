using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanel : MonoBehaviour
{
    [SerializeField]
    Transform Next_Panel;

    private bool isNext;

    // Start is called before the first frame update
    void Start()
    {
        isNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && !isNext)
        {
            Next_Panel.gameObject.SetActive(true);
            isNext = true;
        }
    }
}
