using UnityEngine;

public class KitchenTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            // Find the breakable window in the scene
            BreakableWindow breakableWindow = FindObjectOfType<BreakableWindow>();
            
            if (breakableWindow != null && !breakableWindow.isBroken)
            {
                // Break the window
                breakableWindow.breakWindow();
            }
        }
    }
}
