using UnityEngine;

public class Activator : MonoBehaviour
{
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Active(float time)
    {
        this.Invoke(() => gameObject.SetActive(true),time);
    }

    public void Desactive()
    {
        gameObject.SetActive(false);
    }

    public void Desactive(float time)
    {
        this.Invoke(() => gameObject.SetActive(false),time);
    }
}
