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



    #endregion

    #region Constructor / Initialize

    public DominoSpawner() {
        this.Speed = 0.95f;
    }

    #endregion

    public void NewDomino() {
        Speed += (Speed <= 2.95f ? 0.05f : Random.Range(1.0f, 3.1f));

        Current = Main.Object.NewDomino();
        Current.SetInfo(SpawnPosition, SpawnRotation, Speed);
        Current.OnFockyu -= OnFockyu;
        Current.OnFockyu += OnFockyu;
        Current.OnSleep -= NewDomino;
        Current.OnSleep += NewDomino;
    }

    private void OnFockyu(Domino domino) {
        SpawnPosition = domino.transform.position + domino.transform.forward;
        SpawnRotation = domino.transform.rotation;
        Main.Screen.Camera.SetTarget(null);
    }

}