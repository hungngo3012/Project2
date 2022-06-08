using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField]
    Transform Panel;

    bool canInt = true;
    // Start is called before the first frame update
    void Start()
    {
        Panel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
