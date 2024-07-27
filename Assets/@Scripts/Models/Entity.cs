using UnityEngine;

public class Entity : MonoBehaviour {

    #region Fields

    private bool _isInitialized;

    #endregion

    #region MonoBehaviours

    protected virtual void Awake() { }
    protected virtual void Start() {
        Initialize();
    }
    protected virtual void Update() { }
    protected virtual void FixedUpdate() { }
    protected virtual void OnEnable() { }
    protected virtual void OnDisable() { }

    #endregion

    #region Initialize

    public virtual bool Initialize() {
        if (_isInitialized) return false;

        _isInitialized = true;
        return true;
    }

    #endregion

}