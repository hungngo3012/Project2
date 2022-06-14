using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActive : MonoBehaviour
{
    [SerializeField]
    private AudioSource CurrentMusic;

    [SerializeField]
    private AudioSource BossMusic;

    [SerializeField]
    Transform CheckPanel;

    [SerializeField]
    Transform BossHP;

    [SerializeField]
    Transform Boss;

    [SerializeField]
    Transform Gate;

    [SerializeField]
    Transform GatePos;

    [SerializeField]
    Transform OpenPos;

    private bool isActive = false;
    private bool closeGate = false;
    private bool openGate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPanel.gameObject.GetComponent<ClosePanel>().isClosePanel() && !isActive)
        {
            closeGate = true;
            CurrentMusic.gameObject.SetActive(false);
            BossMusic.gameObject.SetActive(true);
            BossHP.gameObject.SetActive(true);
            Boss.gameObject.GetComponent<Enemy>().enabled = true;
            isActive = true;
        }

        if(closeGate)
        {
            openGate = false;
            Gate.position = Vector3.Lerp(Gate.position, GatePos.position, Time.deltaTime * 3.0f);
        }

        if(!BossHP.gameObject.activeSelf)
        {
            openGate = true;
        }

        if(openGate)
        {
            closeGate = false;
            Gate.position = Vector3.Lerp(Gate.position, OpenPos.position, Time.deltaTime * 3.0f);
        }
    }
}
