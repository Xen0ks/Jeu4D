using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player p))
        {
            p.respawnPoint = transform.GetChild(0).position;
        }
    }
}
