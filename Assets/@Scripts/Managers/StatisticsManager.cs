using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : ContentManager {

    #region Properties

    public int BestScore { get; private set; }
    public int CurrentMoney { get; private set; }

    #endregion

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        return true;
    }
    
    public void Load() {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        CurrentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);
    }

}