using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : Scene {

    #region Properties

    public UI_Scene_Game SceneUI { get; private set; }

    #endregion

    #region Fields


    #endregion

    #region Initialize

    protected override bool Initialize() {
        if (!base.Initialize()) return false;

        // #1. 

        // #2. UI »ý¼º.
        SceneUI = Main.UI.OpenScene<UI_Scene_Game>();

        return true;
    }

    #endregion

}