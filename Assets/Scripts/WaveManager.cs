using System;
using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    /// <summary>
    /// Usage:
    /// <code>
    /// void StartWave(int wave, int count) { // Whatever you want to do on activation }
    /// void Awake() { GameObject.Find("GameManager").GetComponent<WaveManager>().startWave += StartWave; }
    /// </code>
    /// </summary>
    public Action<int, int> startWave;
    public Action finishWave;

    public int wave { get; private set; } = 1;

    void Start() => StartCoroutine(StartWaveCoroutine(wave));
    public void FinishWave() => StartCoroutine(FinishWaveCoroutine());

    private IEnumerator StartWaveCoroutine(int wave)
    {
        Debug.Log($"Starting wave {wave}");
        
        startWave?.Invoke(wave, (int) Math.Round(((wave * 1.5) + 2) * 1.75));
        yield return new WaitForSeconds(5);
    }
    private IEnumerator FinishWaveCoroutine()
    {
        finishWave?.Invoke();
        yield return StartCoroutine(StartWaveCoroutine(wave++));
    }

    private IEnumerator EndGame()
    {
        yield return null;
    }
}