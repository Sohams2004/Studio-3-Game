using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpiderScript : MonoBehaviour
{
    public GameObject spider;

    // Start is called before the first frame update
    void Start()
    {
        spider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spider.SetActive(true);
        }
    }
}
