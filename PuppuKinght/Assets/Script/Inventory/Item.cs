using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform[] Slot;
    public int pos;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pos > inventory.deleteId)
        {
            int tmp = inventory.deleteId + 1;
            pos = pos - 1;
            inventory.SetDeleteId(tmp);
            transform.position = Slot[pos].position;
        }    
    }

    public void Add()
    {
        pos = inventory.next;
        transform.gameObject.SetActive(true);
        transform.position = Slot[pos].position;
        inventory.Add();
    }

    public void Delete()
    {
        transform.gameObject.SetActive(false);
        inventory.Delete(pos);
    }
}
