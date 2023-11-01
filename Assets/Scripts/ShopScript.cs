using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ShopScript : MonoBehaviour
{
    public Unit PlayerUnit;
    public GameObject Crazy_Dave_Shop_Panel;
    public TMP_Text Crazy_Dave_Talking;
    public Button button1, button2;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button1.onClick.AddListener(() => On_Item_Number_1_Button());
        button2.onClick.AddListener(() => On_Item_Number_2_Button());
    }

    public void On_Item_Number_1_Button()
    {
        if (gameManager.Coins >= 20 && gameManager.Sun >= 5)
        {
            gameManager.Sun -= 5;
            gameManager.Coins -= 20;
            gameManager.Weapon_2_Buy = true;
            Crazy_Dave_Talking.text = "Thank you for shopping at Crazy Daves";
        }
        else
        {
            Crazy_Dave_Talking.text = "You cant afford that";
        }

    }
    public void On_Item_Number_2_Button()
    {
        if (gameManager.Coins >= 10 && gameManager.Sun >= 30)
        {
            gameManager.Sun -= 30;
            gameManager.Coins -= 10;
            gameManager.Weapon_3_Buy = true;
            Crazy_Dave_Talking.text = "Thank you for shopping at Crazy Daves";
        }
        else
        {
            Crazy_Dave_Talking.text = "You cant afford that";
        }
    }
    public void OnReturnButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Crazy_Dave_Shop_Panel.SetActive(false);
        Time.timeScale = 1f;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Crazy_Dave_Shop_Panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

        }
    }

}