using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] int tapWaterIndex;
    [SerializeField] LayerMask tapWaterLayer;
    [SerializeField] bool isTapWater, isTapWaterRunning;

    [SerializeField] ParticleSystem tapWater;

    private void Start()
    {
        tapWater.Stop();
    }

    void TapWater()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, tapWaterLayer);

        if (isRay)
        {
            isTapWater = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTapWaterRunning = !isTapWaterRunning;
                tapWaterIndex++;
            }
        }

        else if (!isRay)
        {
            isTapWater = false;
        }

        if (isTapWaterRunning)
        {
            tapWater.Play();
        }

        else if (!isTapWaterRunning)
        {
            tapWater.Stop();
        }
    }

    private void Update()
    {
        TapWater();
    }
}
