using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBall : MonoBehaviour
{
    [SerializeField]
    public AudioSource CollectAudio;

    public float hp = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if (info.gameObject.tag == "Player")
        {
            info.gameObject.GetComponent<PlayerControl>().UpdateHealth(hp);
            CollectAudio.Play();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
