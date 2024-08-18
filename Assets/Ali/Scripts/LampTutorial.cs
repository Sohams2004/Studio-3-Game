using UnityEngine;

public class LampTutorial : MonoBehaviour
{
    public GameObject lamp; 
    public GameObject lightSource; 
    public GameObject lightText; 
    public KeyCode lightKey = KeyCode.Mouse0;
    public AudioSource audioSource; 
    public AudioClip lightToggleSound; 

    private bool isLightOn = false;

    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Lamp"))
            {
                lightText.SetActive(true);

                
                if (Input.GetKeyDown(lightKey))
                {
                    isLightOn = !isLightOn; 
                    lightSource.SetActive(isLightOn);

                    if (audioSource != null && lightToggleSound != null)
                    {
                        audioSource.PlayOneShot(lightToggleSound);
                    }
                }
            }
            else
            {
                lightText.SetActive(false);
            }
        }
        else
        {
            lightText.SetActive(false);
        }
    }
}
