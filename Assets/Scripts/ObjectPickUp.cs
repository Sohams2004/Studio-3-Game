using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] int paperNoteIndex;

    [SerializeField] bool isObject, isPicked, isPaperNote, isPaperNotePicked, cannotPickUp, isDoorOpen;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj, paperNoteLayer, placeLayer, doorLayer;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject, door;

    [SerializeField] Camera camera;

    [SerializeField] TextMeshProUGUI pickDropObjectText, interactionText, placeObjectText, doorOpenText;

    [SerializeField] Image crosshair, paperNote;

    RaycastHit hit1;
    GameObject hitObj;
    GameObject hitDoor;

    private void Start()
    {
        camera = Camera.main;
    }

    void ObjectDetect()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, pickableObj);
        if (isRay)
        {
            Debug.Log("Object detected");
            hitObj = hit1.collider.gameObject;
            crosshair.color = Color.green;
            isObject = true;
        }

        else if (!isRay)
        {
            isObject = false;
            pickDropObjectText.text = string.Empty;
            crosshair.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.E) && isObject && !cannotPickUp)
        {
            cannotPickUp = true;
            isPicked = true;
            objectRb = hitObj.GetComponent<Rigidbody>();
            pickableObject = hitObj.gameObject;
            hitObj.transform.position = pickUpPoint.position;
            hitObj.transform.parent = camera.transform;
            objectRb.constraints = RigidbodyConstraints.FreezeAll;
            pickDropObjectText.text = string.Empty;
        }

        if (isObject)
            pickDropObjectText.text = "Press E to pick up";

        else if (isPicked)
        {
            pickDropObjectText.text = "Press Q to Drop";
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPicked)
        {
            cannotPickUp = false;
            isPicked = false;
            hitObj.transform.parent = null;
            objectRb.constraints = RigidbodyConstraints.None;
            pickDropObjectText.text = string.Empty;
        }
    }

    void PaperNote()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, paperNoteLayer);
        if (isRay)
        {
            Debug.Log("Note detected");

            isPaperNote = true;

            if (!isPaperNotePicked)
                interactionText.text = "Press E to interact";
        }

        else if (!isRay)
        {
            isPaperNote = false;
            interactionText.text = string.Empty;
        }


        if (Input.GetKeyDown(KeyCode.E) && isPaperNote && paperNoteIndex % 2 != 0)
        {
            paperNoteIndex++;
            isPaperNotePicked = true;
            paperNote.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.E) && isPaperNotePicked && paperNoteIndex % 2 == 0)
        {
            paperNoteIndex++;
            isPaperNote = false;
            isPaperNotePicked = false;
            paperNote.gameObject.SetActive(false);
        }

        if (isPaperNotePicked)
        {
            interactionText.text = string.Empty;
        }
    }

    void PlaceObjects()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, placeLayer) && isPicked;
        if (isRay)
        {
            Debug.Log("Place detected");
            GameObject place = hit1.collider.gameObject;
            crosshair.color = Color.green;
            pickDropObjectText.text = string.Empty;
            placeObjectText.text = "Place object";

            if (Input.GetMouseButtonDown(0))
            {
                cannotPickUp = false;
                isPicked = false;
                pickableObject.transform.position = place.transform.position;
                pickableObject.transform.rotation = Quaternion.identity;
                //objectRb.constraints = RigidbodyConstraints.None;
                hitObj.transform.parent = null;
            }
        }

        else if (!isRay)
        {
            crosshair.color = Color.red;
            placeObjectText.text = string.Empty;
        }
    }

    void OpenDoor()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, doorLayer);
        if (isRay && !isDoorOpen)
        {
            Debug.Log("Door detected");
            hitDoor = hit1.collider.gameObject;
            doorOpenText.text = "Press E to open the door";

            if (Input.GetKeyDown(KeyCode.E) && !isDoorOpen)
            {
                isDoorOpen = true;
                door = hitDoor;
                hitDoor.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && isDoorOpen)
        {
            isDoorOpen = false;
            hitDoor.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        }

        else if (isRay && isDoorOpen)
        {
            doorOpenText.text = "Press E to close the door";
        }

        else if (!isRay)
        {
            doorOpenText.text = string.Empty;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        ObjectDetect();
        PaperNote();
        PlaceObjects();
        OpenDoor();
    }
}
