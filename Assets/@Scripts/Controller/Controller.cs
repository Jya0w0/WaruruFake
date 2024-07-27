using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private DominoSpawner _spawner;
    private Timer _overTimer;

    void Update() {
        _overTimer?.Update(Time.deltaTime);
    }

    public void SetInfo(DominoSpawner spawner) {
        _spawner = spawner;
        _overTimer = null;
    }

    public void SetOverTimer(float time) {
        _overTimer = new(time, false, Main.Game.End);
    }

    private void OnLOTTOEKDCJAEHLRHTLVEK() {
        if (_spawner == null || _spawner.Current == null) return;
        _spawner.Current.ROALGKFXRLFPAHSK();
    }

}
