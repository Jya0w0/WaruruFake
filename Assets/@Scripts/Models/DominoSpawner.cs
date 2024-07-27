using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoSpawner {

    #region Properties

    public float Speed { get; private set; }

    #endregion

    #region Fields



    #endregion

    #region Constructor / Initialize

    public DominoSpawner() {
        this.Speed = 0.95f;
    }

    #endregion

    public void MoreFaster() {
        Speed += (Speed <= 2.95f ? 0.05f : Random.Range(1.0f, 3.1f));
    }

}