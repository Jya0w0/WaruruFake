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

    #endregion

    #region Fields

    private float _rotateSpeed;

    private int _direction;
    private float _angleY;
    private float _angleZ;

    private Timer _rotateTimer;

    // Components.
    private DominoSpawner _spawner;
    private MeshRenderer _renderer;

    #endregion

    #region MonoBehaviours

    protected override void FixedUpdate() {
        base.FixedUpdate();

        Rotate(Time.fixedDeltaTime);
        _rotateTimer?.Update(Time.fixedDeltaTime);
    }

    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (!base.Initialize()) return false;

        _spawner = Main.Game.Spawner;

        return true;
    }

    public void SetInfo() {
        Initialize();

        _renderer.material = Main.Game.EquippedItem.Material;
        _rotateSpeed = _spawner.Speed;

        _rotateTimer = new(1 / _rotateSpeed, true, Turn);
    }

    #endregion

    private void Turn() {
        _direction *= -1;
    }

    private void Rotate(float deltaTime) {
        if (ConfirmY && ConfirmZ) return;
        else if (!ConfirmY) _angleY += DEFAULTROTATION * _direction * deltaTime * _rotateSpeed;
        else _angleZ += DEFAULTROTATION * _direction * deltaTime * _rotateSpeed;
        this.transform.rotation = Quaternion.Euler(new(0, _angleY, _angleZ));
    }

}