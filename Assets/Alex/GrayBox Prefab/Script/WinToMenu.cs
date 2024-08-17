using System.Threading.Tasks;
using UnityEngine;

public class WinToMenu : MonoBehaviour
{
    [SerializeField] GameObject win;
    void Start()
    {
        win.SetActive(false);
        TimeToWin();

    }

    async void TimeToWin()
    {
        await Task.Delay(20000);
        win.SetActive(true);
    }
}
