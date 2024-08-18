using System.Threading.Tasks;
using UnityEngine;

public class Sitting2 : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject secondPlayer;
    public bool isSecondPlayerActive = false;
    public bool isInsde = false;
    [SerializeField] GameObject chair;

    void Start()
    {
        chair.SetActive(false);
        secondPlayer.SetActive(false); 
    }

    /* void Update()
     {
         if (isInsde && Input.GetKeyDown(KeyCode.F))
         {
             //Debug.Log("Switching to second player");
             SwitchToSecondPlayer();
             GetUp.SetActive(true);
         }

     }*/
    async void Update()
    {

        if (!isSecondPlayerActive && isInsde && Input.GetKeyDown(KeyCode.F))
        {
            chair.SetActive(false);
            SwitchToSecondPlayer();
            await Task.Delay(1000);
            isSecondPlayerActive = true;


        }
        if (isSecondPlayerActive && isInsde && Input.GetKeyDown(KeyCode.F))
        {
            chair.SetActive(true);
            SwitchToMainPlayer();
            await Task.Delay(1000);
            isSecondPlayerActive = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (!isSecondPlayerActive)
            {
                chair.SetActive(true);
                isInsde = true;
            }
            if (isSecondPlayerActive)
            {
                chair.SetActive(true);
                isInsde = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
    
        if (other.CompareTag("Player"))
        {
            if (!isSecondPlayerActive)
            {
                chair.SetActive(true);
                isInsde = true;
            }
            if (isSecondPlayerActive)
            {
                chair.SetActive(true);
                isInsde = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        chair.SetActive(false);
        isInsde = false;
    }

    void SwitchToMainPlayer()
    {
        mainPlayer.SetActive(true);
        secondPlayer.SetActive(false);

    }
    void SwitchToSecondPlayer()
    {
        mainPlayer.SetActive(false);
        secondPlayer.SetActive(true);

    }


}
