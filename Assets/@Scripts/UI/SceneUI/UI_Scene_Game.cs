using UnityEngine;

public class UI_Scene_Game : UI_Scene {

    #region Properties



    #endregion

    #region Fields

    private UI_Text _txtScore;
    private UI_Text _txtMoney;

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

        _txtMoney = this.gameObject.FindChild<UI_Text>("txtMoney");
        Main.Game.OnChangedMoney -= OnChangedMoney;
        Main.Game.OnChangedMoney += OnChangedMoney;
        _txtScore = this.gameObject.FindChild<UI_Text>("txtScore");
        Main.Game.OnChangedScore -= OnChangedScore;
        Main.Game.OnChangedScore += OnChangedScore;

        return true;
    }

    public void SetInfo() {
        Initialize();
    }

    #endregion

    #region Events

    private void OnChangedScore(int score) {
        _txtScore.Text = $"{score}";
    }
    private void OnChangedMoney(int money) {
        _txtMoney.Text = $"{money}";
    }

    #endregion

}