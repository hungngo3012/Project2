using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int next;
    public int deleteId;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        next = next + 1;
    }

    public void Delete(int i)
    {
        next = next - 1;
        deleteId = i;
    }

    public void SetDeleteId(int i)
    {
        deleteId = i;
    }
}
