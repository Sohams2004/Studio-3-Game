using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPickUp : MonoBehaviour
{
    public GameObject panel; //for the task list
    public TextMeshProUGUI CashTask; //to reference the task text

    [SerializeField] float rayLength;

    [SerializeField] float moneyCount;

    [SerializeField] int paperNoteIndex;

    [SerializeField] int cubeCount, sphereCount, coneCount, itemCount;

    [SerializeField] int maxNumberOfItems;

    [SerializeField] bool isObject, isPaperNote, isPaperNotePicked, cannotPickUp;

    [SerializeField] public bool isPicked, isDoorOpen, isBlinds, isBlindsOpen;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj, paperNoteLayer, placeLayer, moneyLayer;

    [SerializeField] public Rigidbody objectRb;

    [SerializeField] public GameObject pickableObject;

    [SerializeField] Camera camera;

    [SerializeField] TextMeshProUGUI pickDropObjectText, interactionText, placeObjectText, inventoryFullText, pickUpMoneyText;

    [SerializeField] TextMeshProUGUI cubeCountText, sphereCountText, coneCountText, moneyCountText;

    [SerializeField] Image crosshair, paperNote, handSign;

    [SerializeField] Image cubeImg, sphereImg, coneImg;

    [SerializeField] Transform[] itemFrames;

    [SerializeField] Material shapeMaterial;

    [SerializeField] Shader outlineShader;
    [SerializeField] Shader standard;
    [SerializeField] Material outlineMaterial;

    RaycastHit hit1;
    GameObject hitObj;

    GameObject parentObj;
    GameObject place;
    GameObject money;

    HotBar hotbar;
    public Movement movement;

    private void Start()
    {
        camera = Camera.main;
        hotbar = FindObjectOfType<HotBar>();
        movement = FindObjectOfType<Movement>();

        //outlineShader = Shader.Find("Outline");
        outlineMaterial = new Material(outlineShader);
    }

    void ObjectDetect()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, pickableObj);
        if (isRay)
        {
            Debug.Log("Object detected");
            hitObj = hit1.collider.gameObject;
            handSign.gameObject.SetActive(true);
            crosshair.enabled = false;
            isObject = true;

            Renderer renderer = hitObj.GetComponent<Renderer>();

            if (renderer != null)
            {
                shapeMaterial = renderer.material;
                shapeMaterial.shader = outlineShader;
            }
        }

        else if (!isRay)
        {
            isObject = false;
            pickDropObjectText.text = string.Empty;
            handSign.gameObject.SetActive(false);
            crosshair.enabled = true;

            shapeMaterial.shader = standard;
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
                shapeMaterial.shader = standard;


                for (int i = 0; i < hotbar.items.Count; i++)
                {
                    if (hotbar.items[i] == null)
                    {
                        itemCount++;
                        hotbar.items.Add(pickableObject);
                        //pickableObject = null;

                        /*if (pickableObject.tag == "Cube" && cubeCount < 1)
                        {
                            
                        }

                        if (pickableObject.tag == "Cone" && coneCount < 1)
                        {
                            hotbar.items[i] = pickableObject;
                            pickableObject = null;
                        }

                        if (pickableObject.tag == "Sphere" && sphereCount < 1)
                        {
                            hotbar.items[i] = pickableObject;
                            pickableObject = null;
                        }*/
                        break;
                    }
                }

                //hotbar.Inventory();

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

            for (int i = 0; i < hotbar.items.Count; i++)
            {
                if (hotbar.items[i] == pickableObject)
                {
                    itemCount--;
                    hotbar.items.Remove(hotbar.currentObject);
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
            movement.enabled = false;
        }

        else if (Input.GetKeyDown(KeyCode.E) && isPaperNotePicked && paperNoteIndex % 2 == 0)
        {
            paperNoteIndex++;
            isPaperNote = false;
            isPaperNotePicked = false;
            paperNote.gameObject.SetActive(false);
            movement.enabled = true;

            panel.SetActive(true); //activate the tasklist 
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

                    for (int i = 0; i < hotbar.items.Count; i++)
                    {
                        if (hotbar.items[i] == pickableObject)
                        {
                            itemCount--;
                            hotbar.items[i].transform.position = place.transform.position;
                            hotbar.items[i].transform.rotation = Quaternion.identity;
                            hotbar.items.Remove(hotbar.currentObject);
                            pickableObject = null;

                            if (hotbar.currentObject.tag == "Cube")
                            {
                                cubeCount--;

                                cubeCountText.text = cubeCount.ToString();
                            }

                            if (hotbar.currentObject.tag == "Cone")
                            {
                                coneCount--;

                                coneCountText.text = coneCount.ToString();
                            }

                            if (hotbar.currentObject.tag == "Sphere")
                            {
                                sphereCount--;

                                sphereCountText.text = sphereCount.ToString();
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

    void Money()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, moneyLayer);
        if (isRay)
        {
            Debug.Log("Money");

            money = hit1.collider.gameObject;
            pickUpMoneyText.text = "Press E to pick up Money";

            if (Input.GetKeyDown(KeyCode.E))
            {
                moneyCount += 5f;
                moneyCountText.text = string.Format("$ " + moneyCount);
                money.SetActive(false);

                CashTask.text = "Cash Collected"; //two lines to update task text
                CashTask.color = Color.green;

            }
        }

        else if (!isRay)
        {
            pickUpMoneyText.text = string.Empty;
        }
    }

    /*void OpenDoor()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength);

        if (isRay)
        {
            isDoor = true;
            if (Input.GetKeyDown(KeyCode.E) && isDoor)
            {
                isDoorOpen = true;
            }
        }

        else if (!isRay)
        {
            isDoor = false;
        }
    }*/

    /* void BlindsOpen()
     {
         bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength);

         if (isRay)
         {
             isBlinds = true;

             if (Input.GetKeyDown(KeyCode.E) && isBlinds)
             {
                 isBlindsOpen = true;
             }
         }

         else if (!isRay)
         {
             isBlinds = false;
         }

     }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        ObjectDetect();
        PlaceObjects();
        PaperNote();
        /* OpenDoor();*/
        /*BlindsOpen();*/
        Money();
    }
}

