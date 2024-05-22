using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremplin : MonoBehaviour
{
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
        }
    }
}
