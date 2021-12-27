using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuWindow;

    public MonoBehaviour[] ComponentsToDisable;

    public void OpenMenuWindow()
    {
        MenuButton.SetActive(false);
        MenuWindow.SetActive(true);
        Cursor.visible = true;

        foreach (MonoBehaviour component in ComponentsToDisable)
            component.enabled = false;

        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        MenuButton.SetActive(true);
        MenuWindow.SetActive(false);
        Cursor.visible = false;

        foreach (MonoBehaviour component in ComponentsToDisable)
            component.enabled = true;

        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
