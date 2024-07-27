using UnityEngine;

public class GameScene : Scene {

    #region Properties

    public UI_Scene_Game SceneUI { get; private set; }

    #endregion

    #region Fields



    #endregion

    #region Initialize

    protected override bool Initialize() {
        if (!base.Initialize()) return false;

        // #1. Controller 생성.
        Main.Game.Controller = Instantiate(Main.Resource.Get<GameObject>("Controller")).GetComponent<Controller>();

        // #2. UI 생성.
        SceneUI = Main.UI.OpenScene<UI_Scene_Game>();
        SceneUI.Initialize();
        Main.UI.OpenPanel<UI_Panel_StartPanel>().SetInfo();

        // #3. 게임 초기화 및 준비.
        Main.Game.Load();

        return true;
    }

    #endregion

}