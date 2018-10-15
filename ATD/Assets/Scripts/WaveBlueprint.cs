using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveBlueprint{

    [Header("Enemies")]
    public Transform enemy;
    public Transform enemyTank;
    public Transform enemySpeedster;
    [Header("Number of each enemy")]
    public float numberOfGenerics;
    public float numberOfTanks;
    public float numberOfSpeedsters;

}
