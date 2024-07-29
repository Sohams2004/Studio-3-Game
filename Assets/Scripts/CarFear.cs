using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFear : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] Rigidbody carRb;

    [SerializeField] float carSpeed;

    [SerializeField] bool isCarMoving;

    [SerializeField] Transform carSpawn;

    [SerializeField] Cars cars;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car Fear"))
        {
            Instantiate(car, carSpawn.position, Quaternion.Euler(0, -180f, 0));
            cars = car.GetComponent<Cars>();

            cars.carSpeed = 40;

            var carCollider = car.GetComponent<BoxCollider>();
            carCollider.enabled = false;

            //cars.enabled = false;

            isCarMoving = true;

            Destroy(other.gameObject);
        }
    }

    void CarsAttractToPlayer()
    {
        //car = GameObject.FindWithTag("Car");

        carRb = car.GetComponent<Rigidbody>();
        Vector3 Distance = (gameObject.transform.position - car.transform.position).normalized;
        carRb.AddForce(Distance * carSpeed * Time.deltaTime);


        //Vector3 moveCar = Distance * carSpeed * Time.deltaTime;
        //carRb.MovePosition(carRb.position + moveCar);
    }

    private void Update()
    {
        if(isCarMoving)
        {
            CarsAttractToPlayer();
        }
    }
}
