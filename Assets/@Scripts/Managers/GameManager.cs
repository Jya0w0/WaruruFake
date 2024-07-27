using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ContentManager {

    #region Properties

    public int CurrentScore {
        get => _currentScore;
        set {
            _currentScore = value;
            OnChangedScore?.Invoke(value);
        }
    }
    public int BestScore {
        get => _bestScore;
        set {
            _bestScore = value;
            PlayerPrefs.SetInt("BestScore", value);
            OnChangedBestScore?.Invoke(value);
        }
    }
    public int CurrentMoney {
        get => _currentMoney;
        set {
            _currentMoney = value;
            PlayerPrefs.SetInt("CurrentMoney", value);
            OnChangedMoney?.Invoke(value);
        }
    }
    public StoreItem EquippedItem {
        get => _equippedItem;
        set {
            if (_equippedItem == value) return;
            _equippedItem = value;
            OnChangedEquippedItem?.Invoke(value);
        }
    }
    public PlaneColorItem PlaneColor { get; set; }
    public GameState State {
        get => _state;
        set {
            if (value == _state) return;
            _state = value;
            if (_state == GameState.Ready) {

            }
            else if (_state == GameState.Play) {
                Spawner = new();
                Controller.SetInfo(Spawner);
            }
            OnChangedState?.Invoke(value);
        }
    }
    public Controller Controller { get; set; }
    public DominoSpawner Spawner { get; private set; }

    #endregion

    #region Fields

    private int _currentScore;
    private int _bestScore;
    private int _currentMoney;
    private StoreItem _equippedItem;
    private GameState _state;
    private readonly List<StoreItem> _storeItems = new();
    private readonly List<PlaneColorItem> _planeColorItems = new();

    public event Action<int> OnChangedScore;
    public event Action<int> OnChangedBestScore;
    public event Action<int> OnChangedMoney;
    public event Action<StoreItem> OnChangedEquippedItem;
    public event Action<GameState> OnChangedState;

    #endregion

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        State = GameState.Ready;
        Load();

        return true;
    }

    public void Load() {
        LoadScroe();
        LoadStore();
    }

    public void Start() {
        State = GameState.Play;
        Spawner.NewDomino();
    }

    public void Over() {
        State = GameState.Over;
    }

    public void End() {
        State = GameState.End;
    }

    public void Reset() {
        State = GameState.Ready;
        Main.Scene.Reload();
    }

    #region Score

    public void LoadScroe() {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        CurrentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);
    }
    public void RecordScore() {
        if (CurrentScore > BestScore) {
            BestScore = CurrentScore;
        }
    }

    #endregion

    #region Store

    public void LoadStore() {
        _storeItems.Clear();
        for (int i = 0; i < 9; i++) {
            StoreItem item = new(i);
            _storeItems.Add(item);
            if (item.IsEquipped) EquippedItem = item;
        }
        if (EquippedItem == null) EquipItem(_storeItems[0]);

        _planeColorItems.Clear();
        for (int i = 0; i < 6; i++) {
            PlaneColorItem item = new(i);
            _planeColorItems.Add(item);
        }
        if (PlaneColor == null) SelectPlaneColor(_planeColorItems[0]);
    }

    public StoreItem GetStoreItem(int index) => _storeItems[index];

    public bool IsPurchased(int index) => _storeItems[index].IsPurchased;

    public bool IsEquipped(int index) => _storeItems[index].IsEquipped;

    public bool PurchaseItem(StoreItem item) {
        if (item.IsPurchased) return true;
        if (Main.Game.CurrentMoney < item.ItemPrice) return false;
        Main.Game.CurrentMoney -= item.ItemPrice;
        item.IsPurchased = true;
        return true;
    }

    public void EquipItem(StoreItem item) {
        if (EquippedItem == item || item == null) return;
        if (EquippedItem != null)
            EquippedItem.IsEquipped = false;
        EquippedItem = item;
        EquippedItem.IsEquipped = true;
    }

    public PlaneColorItem GetPlaneColorItem(int index) => _planeColorItems[index];

    public void SelectPlaneColor(PlaneColorItem item) {
        PlaneColor = item;
    }

    #endregion

}

public enum GameState {
    Ready,
    Play,
    Over,
    End,
}