using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int generatePlanetPerWave;
    public float waveDuringTime;
    public float waitBetweenWaveTime;
    public float massDecreasePerWave;

    public int increaseGeneratePlanetPerWave;
    public float decreaseWaveDuringTimeValue;
    public float decreaseWaitBetweenWaveTimeValue;
    public float increaseMassDecreasePerWaveValue;

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void UpgradeWave()
    {
        currentWave++;
        waveDuringTime -= decreaseWaveDuringTimeValue * currentWave;
        waitBetweenWaveTime -= decreaseWaitBetweenWaveTimeValue * currentWave;
        massDecreasePerWave += increaseMassDecreasePerWaveValue * currentWave;
        generatePlanetPerWave += increaseGeneratePlanetPerWave * currentWave;
    }

    private IEnumerator StartWave()
    {
        while (!GameManager.IsGameOver)
        {
            UpgradeWave();
            yield return new WaitForSeconds(waveDuringTime);
        }
    }
}