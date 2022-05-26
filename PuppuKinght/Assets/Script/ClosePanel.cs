using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField]
    Transform ParrentPanel;

    bool isClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isClosed = true;
            ParrentPanel.gameObject.SetActive(false);
        }
    }

    public bool isClosePanel()
    {
        return isClosed;
    }
}
