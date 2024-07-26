using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFear : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] Rigidbody carRb;

    [SerializeField] float carSpeed;

    [SerializeField] Cars cars;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car Fear"))
        {
            CarsAttractToPlayer();
            cars = car.GetComponent<Cars>();

            cars.enabled = false;
        }
    }

    void CarsAttractToPlayer()
    {
        car = GameObject.FindWithTag("Car");
        carRb = car.GetComponent<Rigidbody>();
        Vector3 attractCar = (car.transform.position - gameObject.transform.forward).normalized;
        carRb.velocity = attractCar * carSpeed;
    }
}
