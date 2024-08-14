using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.Device;
using TMPro;

public class Television : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] int tvIndex;
    [SerializeField] LayerMask tvLayer;

    [SerializeField] bool isTV, isTVOn;
    [SerializeField] public bool tvDone;
    [SerializeField] bool hasInteracted = false;
    [SerializeField] bool playerInRange = false;

    public TextMeshProUGUI tvTask, watchAMovie;

    [SerializeField] GameObject screen;

    public LightmapData[] lightmapsOn;
    public LightmapData[] lightmapsOff;

    [SerializeField] AudioSource voice;
    [SerializeField] AudioSource staticnoice;

    private void Start()
    {
        screen.SetActive(false);
        LightmapSettings.lightmaps = lightmapsOff;
    }

    void TelevisionOn()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, tvLayer);
        if (isRay)
        {
            isTV = true;

            if (Input.GetKeyDown(KeyCode.E) && isTV && tvIndex % 2 != 0)
            {
                isTVOn = true;
                screen.SetActive(true);
                staticnoice.Play();
                voice.Play();
                LightmapSettings.lightmaps = lightmapsOn;
                hasInteracted = true;
                watchAMovie.color = Color.green;
                tvDone = true;
                tvIndex++;
            }

            else if (Input.GetKeyDown(KeyCode.E) && isTVOn && tvIndex % 2 == 0)
            {
                isTVOn = false;
                screen.SetActive(false);
                staticnoice.Stop();
                voice.Stop();
                LightmapSettings.lightmaps = lightmapsOff;
                hasInteracted = false;

                tvIndex++;
            }
        }

        else if (!isRay)
        {
            isTV = false;
        }
    }

    private void Update()
    {
        TelevisionOn();
    }

}
