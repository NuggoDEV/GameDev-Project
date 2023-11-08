using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] Unit playerUnit;
    public TextMeshProUGUI SunText;
    public TextMeshProUGUI CoinText;
    GameManager gameManager;

    private void Start()
    {
        hpSlider.maxValue = playerUnit.maxHP;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GetComponent<WaveManager>().startWave += WaveStart;
    }
    void Update()
    {
        hpSlider.value = playerUnit.currentHP;
        SunText.text = gameManager.Sun.ToString();
        CoinText.text = gameManager.Coins.ToString();
    }

    private void WaveStart(int wave, int count) => waveText.text = $"Wave: {wave}";
}
