using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ScreenManager : CoreManager {

    #region Properties

    public CameraController Camera { get; private set; }
    public Vector2 Resolution { get; private set; }

    #endregion

    #region Initialize

    public override bool Initialize() {
        if (!base.Initialize()) return false;

#if UNITY_IOS || UNITY_ANDROID
        Application.targetFrameRate = 60;
#endif

        Reset();

        return true;
    }

    #endregion

    public void Reset() {
        this.Camera = GameObject.FindObjectOfType<CameraController>();
        this.Resolution = new(1080f, 1920f);
    }

}