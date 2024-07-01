using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] int paperNoteIndex;

    [SerializeField] int cubeCount, sphereCount, coneCount, itemCount;

    [SerializeField] int maxNumberOfItems;

    [SerializeField] bool isObject, isPaperNote, isPaperNotePicked, cannotPickUp, isDoor, isDoorOpen;

    [SerializeField] public bool isPicked;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj, paperNoteLayer, placeLayer, doorLayer;

    [SerializeField] public Rigidbody objectRb;

    [SerializeField] public GameObject pickableObject, door;

    [SerializeField] Camera camera;

    [SerializeField] TextMeshProUGUI pickDropObjectText, interactionText, placeObjectText, inventoryFullText;

    [SerializeField] TextMeshProUGUI cubeCountText, sphereCountText, coneCountText;

    [SerializeField] Image crosshair, paperNote;

    [SerializeField] Image cubeImg, sphereImg, coneImg;

    [SerializeField] Transform[] itemFrames;

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
            if (/*hotbar.items.Length <= hotbar.numberOfItems*/ itemCount < maxNumberOfItems)
            {
                objectRb = hitObj.GetComponent<Rigidbody>();
                pickableObject = hitObj.gameObject;
                pickableObject.SetActive(false);
                hitObj.transform.position = pickUpPoint.position;
                hitObj.transform.rotation = pickUpPoint.rotation;
                hitObj.transform.parent = camera.transform;
                objectRb.constraints = RigidbodyConstraints.FreezeAll;
                pickDropObjectText.text = string.Empty;

                for (int i = 0; i < hotbar.items.Length; i++)
                {
                    if (hotbar.items[i] == null)
                    {
                        itemCount++;
                        if (pickableObject.tag == "Cube")
                        {
                            hotbar.items[0] = pickableObject;
                        }

                        if (pickableObject.tag == "Cone")
                        {
                            hotbar.items[1] = pickableObject;
                        }

                        if ((pickableObject.tag == "Sphere"))
                        {
                            hotbar.items[2] = pickableObject;
                        }
                        break;
                    }       
                }

                if (pickableObject.tag == "Cube")
                {
                    cubeCount++;

                    cubeCountText.text = cubeCount.ToString();
                }

                if (pickableObject.tag == "Cone")
                {
                    coneCount++;

                    coneCountText.text = coneCount.ToString();
                }

                if (pickableObject.tag == "Sphere")
                {
                    sphereCount++;

                    sphereCountText.text = sphereCount.ToString();
                }
            }

            else
            {
                StartCoroutine(TextPopUp());
            }
        }

        if (pickableObject != null)
        {
            isPicked = true;
        }

        if (isObject)
            pickDropObjectText.text = "Press E to pick up";

        else if (isPicked)
        {
            pickDropObjectText.text = "Press Q to Drop";
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPicked)
        {
            string dropObjectTag = pickableObject.tag;
            pickableObject.transform.parent = null;

            for (int i = 0; i < hotbar.items.Length; i++)
            {
                if (hotbar.items[i] == pickableObject)
                {
                    itemCount--;
                    hotbar.items[i] = null;
                    pickableObject = null;
                    hotbar.currentObject = null;
                    break;
                }
            }

            hotbar.currentObject = hitObj;
            cannotPickUp = false;
            isPicked = false;
            objectRb.constraints = RigidbodyConstraints.None;
            pickDropObjectText.text = string.Empty;

            if (dropObjectTag == "Cube")
            {
                cubeCount--;

                cubeCountText.text = cubeCount.ToString();

                if (cubeCount == 0)
                {
                    cubeImg.gameObject.SetActive(false);
                }
            }

            if (dropObjectTag == "Cone")
            {
                coneCount--;

                coneCountText.text = coneCount.ToString();

                if (coneCount == 0)
                {
                    coneImg.gameObject.SetActive(false);
                }
            }

            if (dropObjectTag == "Sphere")
            {
                sphereCount--;

                sphereCountText.text = sphereCount.ToString();

                if (sphereCount == 0)
                {
                    sphereImg.gameObject.SetActive(false);
                }
            }
        }

        if (pickableObject != null)
        {
            if (pickableObject.tag == "Cube")
            {
                cubeImg.gameObject.SetActive(true);
            }

            if (pickableObject.tag == "Sphere")
            {
                sphereImg.gameObject.SetActive(true);
            }

            if (pickableObject.tag == "Cone")
            {
                coneImg.gameObject.SetActive(true);
            }
        }

        if (cubeCount == 0)
        {
            cubeImg.gameObject.SetActive(false);
        }

        if (coneCount == 0)
        {
            coneImg.gameObject.SetActive(false);
        }

        if (sphereCount == 0)
        {
            sphereImg.gameObject.SetActive(false);
        }
    }

    IEnumerator TextPopUp()
    {
        inventoryFullText.text = "Inventory Full";
        yield return new WaitForSeconds(1);
        inventoryFullText.text = string.Empty;
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
            place = hit1.collider.gameObject;
            print(place.gameObject);
            crosshair.color = Color.green;
            pickDropObjectText.text = string.Empty;
            placeObjectText.text = "Place object";
            print(pickableObject.name);

            if (hotbar.currentObject.tag == place.tag)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Placeddd");

                    pickableObject.transform.parent = null;
                    //hotbar.items.Remove(pickableObject);
                    cannotPickUp = false;
                    isPicked = false;
                    // pickableObject.transform.position = place.transform.position;
                    //pickableObject.transform.rotation = Quaternion.identity;

                    for (int i = 0; i < hotbar.items.Length; i++)
                    {
                        if (hotbar.items[i] == pickableObject)
                        {
                            itemCount--;
                            hotbar.items[i].transform.position = place.transform.position;
                            hotbar.items[i].transform.rotation = Quaternion.identity;
                            hotbar.items[i] = null;
                            pickableObject = null;

                            if (hotbar.currentObject.tag == "Cube")
                            {
                                cubeCount--;
                            }

                            if (hotbar.currentObject.tag == "Cone")
                            {
                                coneCount--;
                            }

                            if (hotbar.currentObject.tag == "Sphere")
                            {
                                sphereCount--;
                            }

                            hotbar.currentObject = null;




                            break;
                        }
                    }
                }
            }
            
        }

        else if (!isRay)
        {
            crosshair.color = Color.red;
            placeObjectText.text = string.Empty;
        }
    }

    /* void OpenDoor()
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


     }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        ObjectDetect();
        PaperNote();
        PlaceObjects();
        /* OpenDoor();*/
    }
}

