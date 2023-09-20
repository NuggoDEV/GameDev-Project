using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    /// <summary>
    /// Usage:
    /// <code>
    /// void StartWave(int wave, int count) { // Whatever you want to do on activation }
    /// void Awake() { startWave += StartWave; }
    /// </code>
    /// </summary>
    public static Action<int, int> startWave;
    public Action finishWave;

    void Start() => StartCoroutine(StartWaveCoroutine(1));
    public void FinishWave(bool playerDied) => StartCoroutine(FinishWaveCoroutine(playerDied));

    private IEnumerator StartWaveCoroutine(int wave)
    {
        Debug.Log("Pls");
        yield return new WaitForSeconds(5);
        startWave?.Invoke(wave, 10);

        yield return null;
    }
    private IEnumerator FinishWaveCoroutine(bool playerDied)
    {
        finishWave?.Invoke();

        if (playerDied)
            yield return StartCoroutine(StartWaveCoroutine(1));
        yield return EndGame();
    }

    private IEnumerator EndGame()
    {
        yield return null;
    }
}