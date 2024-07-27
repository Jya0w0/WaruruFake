public class UI_Panel_StorePanel : UI_Panel {

    #region Fields

    private UI_Button _btnBack;

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _btnBack = this.gameObject.FindChild<UI_Button>("btnBack");
        _btnBack.SetEvent(OnBtnBack);

        return true;
    }

    #endregion

    #region Events

    private void OnBtnBack() => this.Close();

    #endregion

}