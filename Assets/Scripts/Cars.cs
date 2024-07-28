using System.Collections;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    [SerializeField] private float destroyCarIn;

    [SerializeField] Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DestroyCar());
    }

    private void Update()
    {
        //gameObject.transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        Vector3 movement = transform.forward * carSpeed;
        rb.velocity = movement;
    }

    IEnumerator DestroyCar()
    {
        yield return new WaitForSeconds(destroyCarIn);
        Destroy(gameObject);
    }
}
