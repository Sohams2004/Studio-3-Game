using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] int paperNoteIndex;

    [SerializeField] bool isObject, isPicked, isPaperNote, isPaperNotePicked, cannotPickUp, isDoor, isDoorOpen;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj, paperNoteLayer, placeLayer, doorLayer;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] public GameObject pickableObject, door;

    [SerializeField] Camera camera;

    [SerializeField] TextMeshProUGUI pickDropObjectText, interactionText, placeObjectText, doorOpenText;

    [SerializeField] Image crosshair, paperNote;

    RaycastHit hit1;
    GameObject hitObj;
    GameObject hitDoor;
    GameObject parentObj;
    GameObject place;

    HotBar hotbar;

    private void Start()
    {
        camera = Camera.main;
        hotbar = FindObjectOfType<HotBar>();
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

        if (Input.GetKeyDown(KeyCode.E) && isObject)
        {
            //cannotPickUp = true;
            isPicked = true;
            objectRb = hitObj.GetComponent<Rigidbody>();
            pickableObject = hitObj.gameObject;
            pickableObject.SetActive(false);
            hitObj.transform.position = pickUpPoint.position;
            hitObj.transform.parent = camera.transform;
            objectRb.constraints = RigidbodyConstraints.FreezeAll;
            pickDropObjectText.text = string.Empty;
            hotbar.items.Add(pickableObject);
        }

        if (isObject)
            pickDropObjectText.text = "Press E to pick up";

        else if (isPicked)
        {
            pickDropObjectText.text = "Press Q to Drop";
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPicked)
        {
            hotbar.currentObject = hitObj;
            cannotPickUp = false;
            isPicked = false;
            objectRb.constraints = RigidbodyConstraints.None;
            pickDropObjectText.text = string.Empty;
            hotbar.items.Remove(pickableObject);
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
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, placeLayer);
        if (isRay && isPicked)
        {
            Debug.Log("Place detected");
            place = hit1.collider.gameObject;
            crosshair.color = Color.green;
            pickDropObjectText.text = string.Empty;
            placeObjectText.text = "Place object";
            print(pickableObject.name);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Placeddd");

                hitObj.transform.parent = null;
                cannotPickUp = false;
                isPicked = false;
                pickableObject.transform.position = place.transform.position;
                pickableObject.transform.rotation = Quaternion.identity;
                hotbar.items.Remove(pickableObject);
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
            parentObj = hitDoor.transform.parent.gameObject;
            doorOpenText.text = "Press E to open the door";

            isDoor = true;
        }

        else if (isRay && isDoorOpen)
        {
            doorOpenText.text = "Press E to close the door";
        }

        else if (!isRay)
        {
            doorOpenText.text = string.Empty;
        }


        if (Input.GetKeyDown(KeyCode.E) && isDoor)
        {
            isDoorOpen = true;
            door = hitDoor;
            parentObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.E) && isDoorOpen && isRay)
        {
            isDoorOpen = false;
            parentObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
