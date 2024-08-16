using TMPro;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public float raycastDistance = 5f;  // Distance for the raycast
    public LayerMask interactableLayer;  // Layer for interactable objects

    // Assign the specific note sound effects for each key
    public AudioClip[] pianoNotes;  // Array to hold 24 AudioClips
    [SerializeField]
    private TextMeshProUGUI playPianoTask;
    public bool playPianoDone = false;
    private AudioSource audioSource;

    private void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Check for left mouse button click
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
            {
                playPianoTask.color = Color.green;
                playPianoDone = true;
                // Check if the object hit is a piano key
                if (hit.collider.CompareTag("PianoKey"))
                {
                    PlayNote(hit.collider.gameObject);
                }
            }
        }
    }

    private void PlayNote(GameObject pianoKey)
    {
        // Assuming each piano key has a unique identifier
        // Example: "PianoKey1", "PianoKey2", ..., "PianoKey24"
        int keyIndex = GetKeyIndex(pianoKey.name);

        if (keyIndex >= 0 && keyIndex < pianoNotes.Length)
        {
            AudioClip clip = pianoNotes[keyIndex];
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
        else
        {
            Debug.LogWarning("Key index out of range or AudioClip not found.");
        }
    }

    private int GetKeyIndex(string keyName)
    {
        // Map the key names to indices
        // Modify this to match the naming convention used in your project
        if (keyName.StartsWith("PianoKey"))
        {
            int index;
            if (int.TryParse(keyName.Substring("PianoKey".Length), out index))
            {
                return index - 1;  // Convert to 0-based index
            }
        }

        return -1;  // Return -1 if key name is not valid
    }
}
