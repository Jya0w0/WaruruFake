using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : Entity {

    #region Fields

    private MeshRenderer _renderer;

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        return true;
    }

    public void SetInfo() {
        Initialize();

        _renderer.material = Main.Game.EquippedItem.Material;
    }

    #endregion

}