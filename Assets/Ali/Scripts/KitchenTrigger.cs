using UnityEngine;

public class KitchenTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            BreakableWindow breakableWindow = FindObjectOfType<BreakableWindow>();
            
            if (breakableWindow != null && !breakableWindow.isBroken)
            {
                breakableWindow.breakWindow();
            }
        }
    }
}
