using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    ParticleSystem Explo;

    [SerializeField]
    Transform Damage;

    [SerializeField]
    private AudioSource ExplosionAudio;

    Rigidbody bul;
    MeshRenderer bulMesh;
    Collider bulCol;
    Collider damageCol;
    // Start is called before the first frame update
    void Start()
    {
        bul = gameObject.GetComponent<Rigidbody>();

        bulMesh = gameObject.GetComponent<MeshRenderer>();

        bulCol = gameObject.GetComponent<Collider>();

        damageCol = Damage.gameObject.GetComponent<Collider>();
    }

    void OnCollisionEnter()
    {
        bul.velocity = Vector3.zero;
        bul.useGravity = false;
        bulMesh.enabled = false;
        Explo.Play();
        ExplosionAudio.Play();
        damageCol.isTrigger = false;
        //Damage.gameObject.SetActive(true);
        bul.velocity = Vector3.zero;
        bulCol.isTrigger = true;
        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForEndOfFrame();
        damageCol.isTrigger = true;

        yield return new WaitForSeconds(1);
        transform.position = transform.position + new Vector3(0, 0, 1000.0f);
        //Damage.gameObject.SetActive(false);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
