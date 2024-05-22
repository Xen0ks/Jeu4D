using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private MouseLook mouseLook;

    [SerializeField]
    private GameObject menu;

    public bool on;

    private void Start()
    {
        ChangeSensitivity(300);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        if (on)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
        on = menu.activeSelf;
        if(!on) Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeSensitivity(float sens)
    {
        mouseLook.mouseSensitivity = sens;
    }

    public void Xen0ks()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC7C7lBnpJ9vEsukfpVeSqbw");
    }
}
