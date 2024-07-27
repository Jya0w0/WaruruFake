public class UI_Panel_InfoPanel : UI_Panel {

    #region Fields

    private UI_Button _btnBackground;
    private UI_Button _btnBack;

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _btnBackground = this.gameObject.FindChild<UI_Button>("Background");
        _btnBack = this.gameObject.FindChild<UI_Button>("btnBack");
        _btnBackground.SetEvent(OnBtnBack);
        _btnBack.SetEvent(OnBtnBack);

        return true;
    }

    #endregion

    #region Events

    private void OnBtnBack() => this.Close();

    #endregion

}