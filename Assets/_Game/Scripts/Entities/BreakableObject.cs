using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [Header("Object Details")]
    [SerializeField] public int _tapsNeededToBreak;
    [SerializeField] public int _timeToBreakThisObject;
    public AnimationCurve curve;
    [SerializeField] ParticleSystem _particles;

    public void Shake()
    {
        _particles.Play();
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 0.1f)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/0.1f);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
