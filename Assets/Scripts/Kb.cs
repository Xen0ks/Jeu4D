using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kb : MonoBehaviour
{
    public float kbAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce((rb.position - transform.position).normalized * kbAmount, ForceMode.Impulse);
        }
    }
}
