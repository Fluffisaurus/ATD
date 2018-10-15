using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUI : MonoBehaviour {

    public Text level;
    public Text wave;

    private int difficulty = 0;
    private int currLevel = 1;

    private void Update() {
        if (Difficulty.difficulty[0] == true) level.text = "Level: " + currLevel + " (EASY)";
        else if (Difficulty.difficulty[1] == true) level.text = "Level: " + currLevel + " (MEDIUM)";
        else if (Difficulty.difficulty[2] == true) level.text = "Level: " + currLevel + " (HARD)";
        else level.text = "Level: " + currLevel + " (EASY)";

        currLevel = Menu.currentLevel;
        level.text = "Level: " + currLevel;
        wave.text = "Wave:" + Spawner.waveIndex + "/10";
        for (int i = 0; i < Difficulty.difficulty.Length; i++) Difficulty.difficulty[i] = false;

    }



}
