using System.Threading.Tasks;
using UnityEngine;

public class CloseWhisperer : MonoBehaviour
{
    [SerializeField] AudioSource behindYou;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(19500);
        behindYou.Play();
    }


}
