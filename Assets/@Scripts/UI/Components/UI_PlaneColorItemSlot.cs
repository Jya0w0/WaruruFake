using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlaneColorItemSlot : UI {

    #region Properties

    public PlaneColorItem Item { get; private set; }

    #endregion

    #region Fields

    private UI_Button _button;
    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _button = this.gameObject.FindChild<UI_Button>();
        _button.SetEvent(OnBtnSlot);

        return true;
    }

    public void SetInfo(PlaneColorItem item) {
        Initialize();

        if (item == null) return;
        this.Item = item;
        _button.SetColor(item.Color);

    }

    #endregion

    #region Events

    private void OnBtnSlot() {
        Main.Game.SelectPlaneColor(Item);
    }

    #endregion

}