using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMiniMap : MonoBehaviour
{
    public GameObject MapPanel;

    public GameObject MiniMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MapPanel.activeSelf)
        {
            MiniMap.SetActive(true);
        }
        else
        {
            MiniMap.SetActive(false);
        }
    }
}
