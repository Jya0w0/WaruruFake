using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoSpawner {

    #region Properties

    public Domino Current { get; private set; }
    public float Speed { get; private set; }
    public Vector3 SpawnPosition { get; private set; }
    public Quaternion SpawnRotation { get; private set; }

    #endregion

    #region Fields

    private GroundSpawner _groundSpawner;

    #endregion

    #region Constructor / Initialize

    public DominoSpawner() {
        this.Speed = 0.95f;
        this.SpawnPosition = new(0, 5, 0);
        this._groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        this._groundSpawner.SetInfo();
    }

    #endregion

    public void NewDomino() {
        if (Speed <= 2.95) {
            Speed += 0.05f;
        }
        else {
            Speed += Random.Range(1.0f, 3.1f);
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_ffffffffffffffffast, 100, null);
        }

        Current = Main.Object.NewDomino();
        Current.SetInfo(SpawnPosition, SpawnRotation, Speed);
        Current.OnFockyu -= OnFockyu;
        Current.OnFockyu += OnFockyu;
        Current.OnSleep -= NewDomino;
        Current.OnSleep += NewDomino;
        _groundSpawner.RNLCKSGEK();
    }

    private void OnFockyu(Domino domino) {
        SpawnPosition = domino.transform.position + domino.transform.forward;
        SpawnRotation = domino.transform.rotation;
        Main.Screen.Camera.SetTarget(null);
        _groundSpawner.RNLCKSGEK();
    }

}