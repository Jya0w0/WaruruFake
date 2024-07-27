using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UI_Panel_EndPanel : UI_Panel {

    #region Fields

    private UI_Button _btnBackground;
    private UI_Text _txtTitle;
    private UI_Text _txtRestart;
    private UI_Text _txtBestScore;
    private UI_Text _txtCurrentScore;
    private UI_Button _btnShare;
    private UI_Button _btnRanking;
    private UI_Button _btnAchievement;

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        Rect safeArea = Screen.safeArea;
        Vector2 min = safeArea.position;
        Vector2 max = safeArea.size;
        _rect.anchorMin = new(min.x / Screen.width, min.y / Screen.height);
        _rect.anchorMax = new(max.x / Screen.width, max.y / Screen.height);

        _btnBackground = this.gameObject.FindChild<UI_Button>("Background");
        _txtTitle = this.gameObject.FindChild<UI_Text>("txtTitle");
        _txtRestart = this.gameObject.FindChild<UI_Text>("txtRestart");
        _txtBestScore = this.gameObject.FindChild<UI_Text>("txtBestScore");
        _txtCurrentScore = this.gameObject.FindChild<UI_Text>("txtCurrentScore");
        _btnShare = this.gameObject.FindChild<UI_Button>("btnShare");
        _btnRanking = this.gameObject.FindChild<UI_Button>("btnRanking");
        _btnAchievement = this.gameObject.FindChild<UI_Button>("btnAchievement");

        _btnBackground.SetEvent(OnBtnBackground);
        Main.Game.OnChangedBestScore -= OnChangedBestScore;
        Main.Game.OnChangedBestScore += OnChangedBestScore;
        Main.Game.OnChangedScore -= OnChangedScore;
        Main.Game.OnChangedScore += OnChangedScore;
        _btnShare.SetEvent(OnBtnShare);
        _btnRanking.SetEvent(OnBtnRanking);
        _btnAchievement.SetEvent(OnBtnAchievement);

        return true;
    }

    public void SetInfo() {
        Initialize();

        _txtTitle.FadeIn();
        _txtRestart.FadeIn();

        Main.Game.RecordScore();
    }

    #endregion

    #region Events

    private void OnChangedBestScore(int bestScore) {
        _txtBestScore.Text = $"Best : {bestScore}";
    }

    private void OnChangedScore(int score) {
        _txtBestScore.Text = $"Score : {score}";
    }

    private void OnBtnBackground() {
        if (Main.UI.PanelCount > 1) return;

        Main.Game.Reset();
        this.Close();
    }

    private void OnBtnShare() {

    }

    private void OnBtnRanking() {

    }

    private void OnBtnAchievement() {

    }

    #endregion

}