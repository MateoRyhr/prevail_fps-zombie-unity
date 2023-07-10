using System.Collections;
using UnityEngine;

public static class Invoker
{
    public static void Invoke(this MonoBehaviour mb, System.Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }
 
    private static IEnumerator InvokeRoutine(System.Action f, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        f();
    }

    public static void InvokeScaledDeltaTime(this MonoBehaviour mb, System.Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutineScaledDeltaTime(f, delay));
    }
 
    private static IEnumerator InvokeRoutineScaledDeltaTime(System.Action f, float delay)
    {
        float timeElapsed = 0f;
        while (timeElapsed < delay)
        {
            timeElapsed += Time.deltaTime * Time.timeScale;
            yield return null;
        }
        f();
    }
}
