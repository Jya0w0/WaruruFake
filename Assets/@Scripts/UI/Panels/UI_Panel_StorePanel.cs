using System.Collections.Generic;
using UnityEngine;

public class UI_Panel_StorePanel : UI_Panel {

    #region Fields

    private Transform _planes;
    private Transform _items;
    private UI_Button _btnBack;

    private readonly List<UI_PlaneColorItemSlot> _planeColorItemSlots = new();
    private readonly List<UI_StoreItemSlot> _storeItemSlots = new();

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _planes = this.gameObject.FindChild<Transform>("Planes");
        _items = this.gameObject.FindChild<Transform>("Items");
        _btnBack = this.gameObject.FindChild<UI_Button>("btnBack");
        _btnBack.SetEvent(OnBtnBack);

        return true;
    }

    public void SetInfo() {
        Initialize();

        _planeColorItemSlots.Clear();
        for (int i = _planes.childCount - 1; i >= 0; i--)
            Destroy(_planes.GetChild(i).gameObject);
        for (int i = 0; i < 6; i++) {
            UI_PlaneColorItemSlot slot = Main.UI.CreateComponent<UI_PlaneColorItemSlot>(_planes);
            _planeColorItemSlots.Add(slot);
            slot.SetInfo(Main.Game.GetPlaneColorItem(i));
        }

        _storeItemSlots.Clear();
        for (int i = _items.childCount - 1; i >= 0; i--)
            Destroy(_items.GetChild(i).gameObject);
        for (int i = 0; i < 9; i++) {
            UI_StoreItemSlot slot = Main.UI.CreateComponent<UI_StoreItemSlot>(_items);
            _storeItemSlots.Add(slot);
            slot.SetInfo(Main.Game.GetStoreItem(i));
        }
    }

    #endregion

    #region Events

    private void OnBtnBack() {
        if (Main.Game.State == GameState.Ready)
            Main.UI.OpenPanel<UI_Panel_StartPanel>().SetInfo();
        this.Close();
    }

    #endregion

}