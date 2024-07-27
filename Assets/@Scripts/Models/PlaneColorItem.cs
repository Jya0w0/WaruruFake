using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorItem {

    #region Properties

    public int Index { get; private set; }
    public Color Color { get; private set; }

    #endregion

    #region Fields



    #endregion

    public PlaneColorItem(int index) {
        this.Index = index;
        this.Color = index switch {
            0 => new Color(224 / 255f, 224 / 255f, 237 / 255f, 1.0f),
            1 => new Color(039 / 255f, 045 / 255f, 052 / 255f, 1.0f),
            2 => new Color(056 / 255f, 195 / 255f, 209 / 255f, 1.0f),
            3 => new Color(255 / 255f, 186 / 255f, 231 / 255f, 1.0f),
            4 => new Color(255 / 255f, 206 / 255f, 131 / 255f, 1.0f),
            5 => new Color(057 / 255f, 159 / 255f, 052 / 255f, 1.0f),
            _ => Color.white,
        };
    }

}