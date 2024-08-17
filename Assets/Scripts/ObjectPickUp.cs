using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ObjectPickUp : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] GameObject mainPlayer;

    [SerializeField] float rayLength;
    public bool cleanupDone = false;

    [SerializeField] int sitIndex;

    [SerializeField] int cubeCount, sphereCount, coneCount, eggCount, orangeCount, breadCount, itemCount;
    /*   [SerializeField] public int clothCount;*/

    [SerializeField] int maxNumberOfItems;

    [SerializeField] bool isObject, cannotPickUp;

    [SerializeField] public bool isPicked, isChair, isSitting, isSecondPlayerActive;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj, placeLayer, chairLayer;

    [SerializeField] public Rigidbody objectRb;

    [SerializeField] public GameObject pickableObject;

    [SerializeField] Camera camera, objectsCamera;

    [SerializeField] TextMeshProUGUI pickDropObjectText, placeObjectText, inventoryFullText;

    [SerializeField] TextMeshProUGUI cubeCountText, sphereCountText, coneCountText, eggCountText, orangeCountText, breadCountText;
    [SerializeField] public TextMeshProUGUI clothCountText;

    [SerializeField] TextMeshProUGUI cleanupTask;

    [SerializeField] Image crosshair, handSign, chairSign;

    [SerializeField] Image cubeImg, sphereImg, coneImg, eggImg, orangeImg, breadImg;

    [SerializeField] GameObject hitObj;

    GameObject place;

    [SerializeField] HotBar hotbar;
    public Movement movement;
    Sitting2 sitting;

    private void Start()
    {
        camera = Camera.main;
        hotbar = FindObjectOfType<HotBar>();
        movement = FindObjectOfType<Movement>();
        sitting = FindObjectOfType<Sitting2>();
    }

    private void Awake()
    {
        objectsCamera.enabled = false;
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
        }

        else if (!isRay)
        {
            isObject = false;
            pickDropObjectText.text = string.Empty;
            handSign.gameObject.SetActive(false);
            crosshair.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && isObject)
        {
            if (itemCount < maxNumberOfItems)
            {
                objectRb = hitObj.GetComponent<Rigidbody>();
                pickableObject = hitObj.gameObject;
                pickableObject.SetActive(false);
                hitObj.transform.position = pickUpPoint.position;
                hitObj.transform.rotation = pickUpPoint.rotation;
                hitObj.transform.parent = camera.transform;
                objectRb.constraints = RigidbodyConstraints.FreezeAll;
                pickDropObjectText.text = string.Empty;


                for (int i = 0; i < hotbar.items.Count; i++)
                {
                    if (hotbar.items[i] == null)
                    {
                        itemCount++;
                        hotbar.items.Add(pickableObject);
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

                /*  if (pickableObject.tag == "Clothing")
                  {
                      clothCount++;

                      clothCountText.text = clothCount.ToString();
                  }*/

                if (pickableObject.tag == "Egg")
                {
                    eggCount++;

                    eggCountText.text = eggCount.ToString();
                }

                if (pickableObject.tag == "Orange")
                {
                    orangeCount++;

                    orangeCountText.text = orangeCount.ToString();
                }

                if (pickableObject.tag == "Toast")
                {
                    breadCount++;

                    breadCountText.text = breadCount.ToString();
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
            pickDropObjectText.text = "Press E to Pick Up";

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

            /* if (dropObjectTag == "Clothing")
             {
                 clothCount--;

                 clothCountText.text = clothCount.ToString();

                 if (clothCount == 0)
                 {
                     clothImg.gameObject.SetActive(false);
                 }
             }*/

            if (dropObjectTag == "Egg")
            {
                eggCount--;

                eggCountText.text = eggCount.ToString();

                if (eggCount == 0)
                {
                    eggImg.gameObject.SetActive(false);
                }
            }

            if (dropObjectTag == "Orange")
            {
                orangeCount--;

                orangeCountText.text = orangeCount.ToString();

                if (orangeCount == 0)
                {
                    orangeImg.gameObject.SetActive(false);
                }
            }

            if (dropObjectTag == "Toast")
            {
                breadCount--;

                breadCountText.text = breadCount.ToString();

                if (breadCount == 0)
                {
                    breadImg.gameObject.SetActive(false);
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

            /*if (pickableObject.tag == "Clothing")
            {
                clothImg.gameObject.SetActive(true);
            }*/

            if (pickableObject.tag == "Egg")
            {
                eggImg.gameObject.SetActive(true);
            }

            if (pickableObject.tag == "Orange")
            {
                orangeImg.gameObject.SetActive(true);
            }

            if (pickableObject.tag == "Toast")
            {
                breadImg.gameObject.SetActive(true);
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

        /* if (clothCount == 0)
         {
             clothImg.gameObject.SetActive(false);
         }*/

        if (eggCount == 0)
        {
            eggImg.gameObject.SetActive(false);
        }

        if (orangeCount == 0)
        {
            orangeImg.gameObject.SetActive(false);
        }

        if (breadCount == 0)
        {
            breadImg.gameObject.SetActive(false);
        }
    }

    IEnumerator TextPopUp()
    {
        inventoryFullText.text = "Inventory Full";
        yield return new WaitForSeconds(1);
        inventoryFullText.text = string.Empty;
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
            placeObjectText.text = "Place Object";

            print(pickableObject.name);

            if (hotbar.currentObject.tag == place.tag)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    cleanupTask.color = Color.green;
                    cleanupDone = true;
                    Debug.Log("Placeddd");
                    hotbar.currentObject.transform.parent = null;

                    for (int i = 0; i < hotbar.items.Count; i++)
                    {
                        if (hotbar.items[i] == pickableObject)
                        {
                            itemCount--;
                            hotbar.items[i].transform.rotation = Quaternion.identity;
                            hotbar.items[i].transform.position = place.transform.position;
                            hotbar.items[i].transform.rotation = place.transform.rotation;
                            hotbar.items.Remove(hotbar.currentObject);
                            pickableObject = null;
                            objectRb = null;

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

                            if (hotbar.currentObject.tag == "Egg")
                            {
                                eggCount--;

                                eggCountText.text = eggCount.ToString();
                            }

                            if (hotbar.currentObject.tag == "Orange")
                            {
                                orangeCount--;

                                orangeCountText.text = orangeCount.ToString();
                            }

                            if (hotbar.currentObject.tag == "Toast")
                            {
                                breadCount--;

                                breadCountText.text = breadCount.ToString();
                            }

                            hotbar.currentObject = null;

                            break;
                        }
                    }

                    cannotPickUp = false;
                    isPicked = false;
                }
            }

        }

        else if (!isRay)
        {
            crosshair.color = Color.red;
            placeObjectText.text = string.Empty;
        }
    }

    void ObjectCameraActivate()
    {
        if (isPicked)
        {
            objectsCamera.enabled = true;
        }

        else
        {
            objectsCamera.enabled = false;
        }
    }

    /*void ObjectLayer()
    {
        if (isObject)
        {
            if (hitObj.tag == "Cube" || hitObj.tag == "Cone" || hitObj.tag == "Sphere")
            {
                hitObj.layer = pickableObj;
            }
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
        /* Sit();*/
        ObjectCameraActivate();
        //ObjectLayer();
    }
}
