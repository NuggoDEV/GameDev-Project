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

    private void Start()
    {
        hpSlider.maxValue = playerUnit.maxHP;
        GameObject.Find("GameManager").GetComponent<WaveManager>().startWave += WaveStart;
    }
    void Update()
    {
        hpSlider.value = playerUnit.currentHP;
    }

    private void WaveStart(int wave, int count) => waveText.text = $"Wave: {wave}";
}
