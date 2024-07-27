using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StoreItemSlot : UI {

    #region Properties

    public StoreItem Item { get; private set; }

    #endregion

    #region Fields

    private UI_Button _btnSlot;
    private UI_Text _txtName;
    private UI_Image _imgUseMark;
    private UI_Image _imgLock;

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _btnSlot = this.gameObject.FindChild<UI_Button>("btnSlot");
        _txtName = this.gameObject.FindChild<UI_Text>("txtName");
        _imgUseMark = this.gameObject.FindChild<UI_Image>("imgUseMark");
        _imgLock = this.gameObject.FindChild<UI_Image>("imgLock");
        _btnSlot.SetEvent(OnBtnSlot);

        return true;
    }

    public void SetInfo(StoreItem item) {
        Initialize();

        if (item == null) return;
        this.Item = item;
        _btnSlot.SetImage(item.Icon);
        _txtName.Text = $"½ºÅ² {item.Index + 1}";

        item.OnChangedPurchased -= OnChangedPurchased;
        item.OnChangedPurchased += OnChangedPurchased;
        OnChangedPurchased(item.IsPurchased);
        item.OnChangedEquipped -= OnChangedEquipped;
        item.OnChangedEquipped += OnChangedEquipped;
        OnChangedEquipped(item.IsEquipped);
    }

    #endregion

    #region Events

    private void OnBtnSlot() {
        if (!Item.IsPurchased) {
            Main.Game.PurchaseItem(Item);
        }
        else if (!Item.IsEquipped) {
            Main.Game.EquipItem(Item);
        }
    }

    private void OnChangedPurchased(bool purchased) {
        if (purchased) {
            _btnSlot.SetColor(Color.white);
            _imgLock.gameObject.SetActive(false);
        }
        else {
            _btnSlot.SetColor(Styles.BUTTONCOLOR_DISABLE);
            _imgLock.gameObject.SetActive(true);
        }
    }

    private void OnChangedEquipped(bool equipped) {
        _imgUseMark.gameObject.SetActive(equipped);
    }

    #endregion

}