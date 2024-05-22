using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public Vector3 respawnPoint;

    public Text timeText;

    [SerializeField]
    PauseMenu pauseMenu;

    public void Die()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = respawnPoint;
    }

    private void Update()
    {
        if (pauseMenu.on) return;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.5f;
        }else if (Input.GetKey(KeyCode.LeftControl))
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        timeText.text = "Time : " + Time.timeScale;
    }
}
