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

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPanel.gameObject.GetComponent<ClosePanel>().isClosePanel() && !isActive)
        {
            CurrentMusic.gameObject.SetActive(false);
            BossMusic.gameObject.SetActive(true);
            BossHP.gameObject.SetActive(true);
            Boss.gameObject.GetComponent<Enemy>().enabled = true;
            isActive = true;
        }
    }
}
