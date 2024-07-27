using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UI_Panel : UI {

    #region Properties

    public virtual bool AllowDuplicate => true;

    #endregion

    #region Fields

    protected Canvas _canvas;
    protected CanvasScaler _scaler;

    public event Action OnClosed;

    #endregion

    #region MonoBehaviours

    protected override void OnEnable() {
        base.OnEnable();

        Sequence sequense = DOTween.Sequence();
        sequense.Append(_rect.transform.DOScale(1.3f, 0.2f));
        sequense.Append(_rect.transform.DOScale(1.0f, 0.2f));
    }

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _rect = this.transform.Find("Panel").GetComponent<RectTransform>();
        _canvas = this.gameObject.GetOrAddComponent<Canvas>();
        _scaler = this.gameObject.GetOrAddComponent<CanvasScaler>();
        SetCanvas();

        return true;
    }

    protected virtual void SetCanvas() {
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.overrideSorting = true;

        _scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _scaler.referenceResolution = Main.Screen.Resolution;
    }

    protected virtual void SetOrder() => _canvas.sortingOrder = Main.UI.OrderUpPanel();
    public void SetOrder(int order) => _canvas.sortingOrder = order;

    #endregion

    #region Panel

    public virtual void SetPosition(Vector2 position) {
        // #1. Pivot 설정.
        Vector2 pivot = new((position.x >= Screen.width / 2f) ? 1 : 0, (position.y >= Screen.height / 2f) ? 1 : 0);

        // #2. Panel이 화면 밖으로 벗어나지 않도록 위치 조정.
        Vector2 size = _rect.sizeDelta;
        if (pivot.x < 0.5f && position.x + size.x >= Screen.width)
            position.x = Screen.width - size.x;
        else if (pivot.x >= 0.5f && position.x - size.x <= 0)
            position.x = size.x;
        if (pivot.y < 0.5f && position.y + size.y >= Screen.height)
            position.y = Screen.height - size.y;
        else if (pivot.y >= 0.5f && position.y - size.y <= 0)
            position.y = size.y;

        // #3. 적용.
        _rect.pivot = pivot;
        _rect.position = position;
    }

    public virtual void Close() {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rect.transform.DOScale(1.0f, 0.1f));
        sequence.Append(_rect.transform.DOScale(0.3f, 0.1f));
        sequence.OnComplete(() => {
            _rect.transform.localScale = Vector3.one;
            Main.UI.ClosePanel(this);
            OnClosed?.Invoke();
        });
    }

    #endregion

}