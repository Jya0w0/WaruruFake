using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene_Game : UI_Scene {

    #region Properties



    #endregion

    #region Fields



    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _rect = this.transform.Find("Scene").GetComponent<RectTransform>();
        Rect safeArea = Screen.safeArea;
        Vector2 min = safeArea.position;
        Vector2 max = safeArea.size;
        _rect.anchorMin = new(min.x / Screen.width, min.y / Screen.height);
        _rect.anchorMax = new(max.x / Screen.width, max.y / Screen.height);

        return true;
    }

    #endregion

    #region OnButtons

    #endregion

}