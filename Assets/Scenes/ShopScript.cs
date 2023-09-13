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

    public void On_Item_Number_1_Button() 
    {
        if(PlayerUnit.Amount_of_Sun >= 25)
        {
            PlayerUnit.Amount_of_Sun = PlayerUnit.Amount_of_Sun - 25;
            PlayerUnit.Item_Number_1 = PlayerUnit.Item_Number_1 + 1;
            Crazy_Dave_Talking.text = "Thank you for shopping at Crazy Daves";
        }
        else 
        {
            Crazy_Dave_Talking.text = "You cant afford that";
        }

    }
    public void On_Item_Number_2_Button() 
    {
        if (PlayerUnit.Amount_of_Money >= 25)
        {
            PlayerUnit.Amount_of_Money = PlayerUnit.Amount_of_Money - 25;
            PlayerUnit.Item_Number_1 = PlayerUnit.Item_Number_2 + 1;
            Crazy_Dave_Talking.text = "Thank you for shopping at Crazy Daves";
        }
        else
        {
            Crazy_Dave_Talking.text = "You cant afford that";
        }
    }
    public void OnReturnButton() 
    {
        StartCoroutine(OnReturnButtonCoroutine());

    }
    IEnumerator OnReturnButtonCoroutine() 
    {
        Crazy_Dave_Talking.text = "bye bye, see you later";
        yield return new WaitForSeconds(2f);
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
            Debug.Log("Shop Working");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

}
