using GooglePlayGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : Entity {

    #region Const

    private readonly float DEFAULTROTATION = 90f;

    #endregion

    #region Properties

    public bool ConfirmY { get; private set; }
    public bool ConfirmZ { get; private set; }
    public bool IsHandling {
        get => _isHandling;
        private set {
            _isHandling = value;
            if (!_isHandling) OnFockyu?.Invoke(this);
        }
    }

    #endregion

    #region Fields

    private float _rotateSpeed;
    private bool _isHandling = true;
    private bool _isFalldown = false;

    private int _direction;
    private float _angleY;
    private float _angleZ;

    private Timer _rotateTimer;

    // Components.
    private DominoSpawner _spawner;
    private MeshRenderer _renderer;
    private Rigidbody _rigidbody;

    // Coroutine.
    private Coroutine _cokiriajyossi;

    public event Action<Domino> OnFockyu;
    public event Action OnSleep;

    #endregion

    #region MonoBehaviours

    protected override void FixedUpdate() {
        base.FixedUpdate();

        Rotate(Time.fixedDeltaTime);
    }
    protected override void Update() {
        base.Update();
        _rotateTimer?.Update(Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (_isFalldown) return;

        _isFalldown = true;
        Main.Screen.Camera.SetTarget(this.transform, true);
        Main.Game.Over();
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_waruru, 100, null);
    }

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _spawner = Main.Game.Spawner;
        _renderer = this.GetComponent<MeshRenderer>();
        _rigidbody = this.GetComponent<Rigidbody>();

        return true;
    }

    public void SetInfo(Vector3 position, Quaternion rotation, float speed) {
        Initialize();

        OnFockyu -= Cokiriajyossiwhereareyou;
        OnFockyu += Cokiriajyossiwhereareyou;

        this.transform.position = position;
        this.transform.rotation = rotation;

        _renderer.material = Main.Game.EquippedItem.Material;
        _rotateSpeed = speed;
        _rotateTimer = new(1 / _rotateSpeed, true, Turn);
        Main.Screen.Camera.SetTarget(this.transform);

        IsHandling = true;
        _isFalldown = false;
        ConfirmY = false;
        ConfirmZ = false;
        _rigidbody.isKinematic = true;
        _direction = 1;
        this.transform.GetChild(0).transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    #endregion

    public void ROALGKFXRLFPAHSK() {
        if (!IsHandling) return;
        if (ConfirmY && ConfirmZ) return;
        else if (!ConfirmY) ConfirmY = true;
        else ConfirmZ = true;

        if (ConfirmY && ConfirmZ) {
            _rigidbody.isKinematic = false;
            IsHandling = false;
        }
    }

    private void Turn() {
        _direction *= -1;
    }

    private void Rotate(float deltaTime) {
        if (ConfirmY && ConfirmZ) return;
        else if (!ConfirmY) _angleY += DEFAULTROTATION * _direction * deltaTime * _rotateSpeed;
        else _angleZ += DEFAULTROTATION * _direction * deltaTime * _rotateSpeed;
        this.transform.rotation = Quaternion.Euler(new(0, _angleY, _angleZ));
    }

    private void Cokiriajyossiwhereareyou(Domino d) {
        if (_cokiriajyossi != null) StopCoroutine(_cokiriajyossi);
        _cokiriajyossi = StartCoroutine(Cokiriajyossi());
    }

    private IEnumerator Cokiriajyossi() {
        while (!_rigidbody.IsSleeping()) {
            yield return null;
            if (Main.Game.State == GameState.Over || Main.Game.State == GameState.End) yield break;
        }
        if (!_isFalldown) Main.Game.CurrentScore++;
        OnSleep?.Invoke();
    }
}