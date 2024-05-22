using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    bool opened;

    IEnumerator Open()
    {
        yield return new WaitForSeconds(0.2f);
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(0.1f);
        opened = true;
        yield return new WaitForSeconds(0.9f);
        opened = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!opened) StartCoroutine(Open());
        if (opened && other.TryGetComponent<Player>(out Player p))
        {
            p.Die();
        }
    }
}
