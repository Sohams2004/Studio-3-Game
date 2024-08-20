using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Blinds : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] int blindsIndex;
    [SerializeField] LayerMask blindsLayer;
    [SerializeField] bool isBlinds, isBlindsOpen;
    [SerializeField] GameObject blinds;
    [SerializeField] Animator blindsAnimator;
    [SerializeField] AudioSource blindsAudio;
    [SerializeField] TextMeshProUGUI blindsTask;
    public bool lighton;


    async void BlindsOpen()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, blindsLayer);

        if (isRay)
        {
            isBlinds = true;
            isBlindsOpen = false;
            blinds = hit1.collider.gameObject;
            blindsAnimator = blinds.GetComponent<Animator>();
            blindsAudio = blinds.GetComponent<AudioSource>();


            if (Input.GetKeyDown(KeyCode.Mouse0) && isBlinds && blindsIndex % 2 != 0)
            {
                Debug.Log("Blinds open");

                blindsIndex++;


                blindsAnimator.Play("Close Curtain");

                blindsTask.color = Color.green;
                lighton = true;
                if (blindsAudio != null)
                {
                    blindsAudio.Play();
                }
                isBlindsOpen = true;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && isBlindsOpen && blindsIndex % 2 == 0)
            {
                Debug.Log("Blinds close");

                blindsIndex++;


                blindsAnimator.Play("Open Curtain");

                if (blindsAudio != null)
                {
                    blindsAudio.Play();
                }
                await Task.Delay(1000);
                isBlindsOpen = false;
            }
        }

        else if (!isRay)
        {
            isBlinds = false;
            blinds = null;
            blindsAnimator = null;
            blindsAudio = null;
        }
    }

    private void Update()
    {
        BlindsOpen();
    }
}
