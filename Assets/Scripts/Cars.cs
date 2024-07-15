using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    [SerializeField] private float destroyCarIn;

    private void Awake()
    {
        StartCoroutine(DestroyCar());
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }

    IEnumerator DestroyCar()
    {
        yield return new WaitForSeconds(destroyCarIn);
        Destroy(gameObject);
    }
}
