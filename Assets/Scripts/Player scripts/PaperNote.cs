using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaperNote : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] int paperNoteIndex;
    [SerializeField] LayerMask paperNoteLayer;
    [SerializeField] bool isPaperNote, isPaperNotePicked;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] Image paperNote;
    [SerializeField] GameObject laundry;
    public GameObject panel;


    Movement movement;

    private void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

    void PaperList()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, paperNoteLayer);
        if (isRay)
        {
            Debug.Log("Note detected");

            isPaperNote = true;

            if (!isPaperNotePicked)
                interactionText.text = "Left Click to Interact";
        }

        else if (!isRay)
        {
            isPaperNote = false;
            interactionText.text = string.Empty;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && isPaperNote && paperNoteIndex % 2 != 0)
        {
            paperNoteIndex++;
            isPaperNotePicked = true;
            paperNote.gameObject.SetActive(true);

            movement.enabled = false;
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && isPaperNotePicked && paperNoteIndex % 2 == 0)
        {
            paperNoteIndex++;
            isPaperNote = false;
            isPaperNotePicked = false;
            paperNote.gameObject.SetActive(false);
            movement.enabled = true;
            laundry.gameObject.SetActive(true);
            panel.SetActive(true); //activate the tasklist 
        }

        if (isPaperNotePicked)
        {
            interactionText.text = string.Empty;
        }
    }

    private void Update()
    {
        PaperList();
    }
}
