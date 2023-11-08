using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject AreYouSurePanel;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject ShopPanel;

    public int Sun = 0;
    public int Coins = 0;
    public bool Weapon_3_Buy = false;
    public bool Weapon_2_Buy = false;


    public void Play() => SceneManager.LoadScene("GameScene");
    public void Quit() => Application.Quit();
    public void MainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
        InventoryPanel.SetActive(false);
    }
    public void AreYouSure()
    {
        PauseScreen.SetActive(false);
        AreYouSurePanel.SetActive(true);
    }
    public void No()
    {
        AreYouSurePanel.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown("escape") && !ShopPanel.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            PauseScreen.SetActive(true);
        }
    }
}
