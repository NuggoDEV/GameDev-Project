using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject AreYouSurePanel;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject GameOverPanel;
    public int Sun = 0;
    public int Coins = 0;

    public void Play() => SceneManager.LoadScene("GameScene");
    public void Quit() => Application.Quit();
    public void MainMenu() => SceneManager.LoadScene("MainMenu");
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

    /*public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 0f;
            PauseScreen.SetActive(true);
        }
    }*/
}
