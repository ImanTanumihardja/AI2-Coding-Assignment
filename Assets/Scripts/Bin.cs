using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bin : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> CollectedEvent;

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.CompareTag("Active"))
        {
            CollectedEvent?.Invoke(go);
        }
    }
}
