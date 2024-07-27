using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    #region Fields

    private float _xDistance;
    private float _zDistance;
    private float _cubeScale;
    private Vector3 _xPosition;
    private Vector3 _zPosition;

    private Transform _gaemi;

    private bool _isInitialized = false;

    #endregion

    #region Initialize / Set

    public virtual bool Initialize() {
        if (!_isInitialized) return false;
        _isInitialized = true;

        return true;
    }

    public void SetInfo() {
        Initialize();

        _gaemi = Main.Screen.Camera.transform;
        _cubeScale = this.transform.localScale.x;
    }

    #endregion

    public void RNLCKSGEK() {
        bool createX = false;
        bool createZ = false;
        _xDistance = _gaemi.position.x - this.transform.position.x;
        _zDistance = _gaemi.position.z - this.transform.position.z;

        if (Mathf.Abs(_xDistance) > _cubeScale / 4) {
            Vector3 xDir = new Vector3(_xDistance, 0, 0).normalized;
            _xPosition = xDir * _cubeScale;
            createX = true;
            CreateMap(this.transform.position + _xPosition);
        }

        if (Mathf.Abs(_zDistance) > _cubeScale / 4) {
            Vector3 zDir = new Vector3(0, 0, _zDistance).normalized;
            _zPosition = zDir * _cubeScale;
            createZ = true;
            CreateMap(this.transform.position + _zPosition);
        }

        if (createX && createZ) CreateMap(this.transform.position + _xPosition + _zPosition);

        if (Mathf.Abs(_xDistance) > _cubeScale / 2 + 1) this.transform.position += _xPosition;
        if (Mathf.Abs(_zDistance) > _cubeScale / 2 + 1) this.transform.position += _zPosition;
    }

    private void CreateMap(Vector3 position) {
        Vector3 groundPosition = position - Vector3.up * 5;
        if (!Physics.Raycast(groundPosition, Vector3.up, _cubeScale))
            Main.Object.NewGround().SetInfo(position, Quaternion.identity);
    }

}