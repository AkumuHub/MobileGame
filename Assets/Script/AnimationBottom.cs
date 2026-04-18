using UnityEngine;
using System.Collections;

public class AnimationBottom : MonoBehaviour
{

    [SerializeField] private Transform Yunke; 
    [SerializeField] private float escalaMax = 1.2f;
    [SerializeField] private float duracion = 0.1f;

    [SerializeField]  ClickManager clickManager;

    private Vector3 originalScale;
    private Coroutine actualAnimation;


    private void Awake()
    {
        originalScale = Yunke.localScale;
    }

    public void Pulse() 
    {
        clickManager.Pulsar();
        if (actualAnimation != null)
        {
            StopCoroutine(actualAnimation);
            Yunke.localScale = originalScale; 
        }
        actualAnimation = StartCoroutine(AnimarPulso());

    }

    IEnumerator AnimarPulso()
    {
        Vector3 escalaObjetivo = originalScale * escalaMax;

        float time = 0f;

        // agrandar

        while (time < duracion)
        {
            time += Time.deltaTime;
            Yunke.localScale = Vector3.Lerp(originalScale, escalaObjetivo, time / duracion);
            yield return null;
        }

            time = 0f;

        // reducir

        while (time < duracion)
        {
            time += Time.deltaTime;
            Yunke.localScale = Vector3.Lerp(escalaObjetivo, originalScale, time / duracion);
            yield return null;
        }

        Yunke.localScale = originalScale; 
    }




}
