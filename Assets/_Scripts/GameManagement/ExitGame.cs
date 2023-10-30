using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit(float delay)
    {
        this.Invoke(() => Application.Quit(),delay);
    }
}
