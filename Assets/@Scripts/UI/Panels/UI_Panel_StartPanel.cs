using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Panel_StartPanel : UI_Panel {


    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        Rect safeArea = Screen.safeArea;
        Vector2 min = safeArea.position;
        Vector2 max = safeArea.size;
        _rect.anchorMin = new(min.x / Screen.width, min.y / Screen.height);
        _rect.anchorMax = new(max.x / Screen.width, max.y / Screen.height);

        return true;
    }

    #endregion


}