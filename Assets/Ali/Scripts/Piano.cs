using TMPro;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public float raycastDistance = 5f;  
    public LayerMask interactableLayer;  

    
    public AudioClip[] pianoNotes;  
    [SerializeField]
    private TextMeshProUGUI playPianoTask;
    public bool playPianoDone = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
            {
                playPianoTask.color = Color.green;
                playPianoDone = true;

                if (hit.collider.CompareTag("PianoKey"))
                {
                    PlayNote(hit.collider.gameObject);
                }
            }
        }
    }

    private void PlayNote(GameObject pianoKey)
    {
    
        int keyIndex = GetKeyIndex(pianoKey.name);

        if (keyIndex >= 0 && keyIndex < pianoNotes.Length)
        {
            AudioClip clip = pianoNotes[keyIndex];
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
       
    }

    private int GetKeyIndex(string keyName)
    {
        
        if (keyName.StartsWith("PianoKey"))
        {
            int index;
            if (int.TryParse(keyName.Substring("PianoKey".Length), out index))
            {
                return index - 1;  
            }
        }

        return -1;  
    }
}
