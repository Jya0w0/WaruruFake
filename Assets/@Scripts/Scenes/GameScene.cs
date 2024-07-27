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

        // #1. Controller ����.
        Main.Game.Controller = Instantiate(Main.Resource.Get<GameObject>("Controller")).GetComponent<Controller>();

        // #2. UI ����.
        SceneUI = Main.UI.OpenScene<UI_Scene_Game>();
        SceneUI.Initialize();
        Main.UI.OpenPanel<UI_Panel_StartPanel>().SetInfo();

        // #3. ���� �ʱ�ȭ �� �غ�.
        Main.Game.Load();

        return true;
    }

    #endregion

}