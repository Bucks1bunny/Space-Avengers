using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public float destroyTime = .3f;
    public Vector3 randomizeText = new Vector3(0, 0, 0);
    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += new Vector3(Random.Range(-randomizeText.x, randomizeText.x),
           Random.Range(-randomizeText.y, randomizeText.y),
           Random.Range(-randomizeText.z, randomizeText.z));
    }
}
