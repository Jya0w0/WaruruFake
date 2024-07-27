using UnityEngine;

public class UI_Panel_StartPanel : UI_Panel {

    #region Fields

    private UI_Button _btnBackground;
    private UI_Text _txtTitle;
    private UI_Text _txtStart;
    private UI_Button _btnInfo;
    private UI_Button _btnStore;
    private UI_Button _btnADRemove;
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
        _txtStart = this.gameObject.FindChild<UI_Text>("txtStart");
        _btnInfo = this.gameObject.FindChild<UI_Button>("btnInfo");
        _btnStore = this.gameObject.FindChild<UI_Button>("btnStore");
        _btnADRemove = this.gameObject.FindChild<UI_Button>("btnADRemove");
        _btnRanking = this.gameObject.FindChild<UI_Button>("btnRanking");
        _btnAchievement = this.gameObject.FindChild<UI_Button>("btnAchievement");

        _btnBackground.SetEvent(OnBtnAchievement);
        _btnInfo.SetEvent(OnBtnInfo);
        _btnStore.SetEvent(OnBtnStore);
        _btnADRemove.SetEvent(OnBtnADRemove);
        _btnRanking.SetEvent(OnBtnRanking);
        _btnAchievement.SetEvent(OnBtnAchievement);

        return true;
    }

    public void SetInfo() {
        Initialize();

        _txtTitle.FadeIn();
        _txtStart.FadeIn();
    }

    #endregion

    #region Events

    private void OnBtnBackground() {
        if (Main.UI.PanelCount > 1) return;

        Main.Game.Start();
        this.Close();
    }

    private void OnBtnInfo() {
        Main.UI.OpenPanel<UI_Panel_InfoPanel>();
        this.Close();
    }

    private void OnBtnStore() {
        Main.UI.OpenPanel<UI_Panel_StorePanel>().SetInfo();
        this.Close();
    }

    private void OnBtnADRemove() {

    }

    private void OnBtnRanking() {

    }

    private void OnBtnAchievement() {

    }

    #endregion

}