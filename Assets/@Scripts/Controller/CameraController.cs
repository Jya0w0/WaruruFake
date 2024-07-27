using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {

    private CinemachineVirtualCamera _camera;
    private CinemachineTransposer _transposer;
    
    public void SetTarget(Transform target, bool over = false) {
        if (_camera == null) {
            _camera = this.GetComponent<CinemachineVirtualCamera>();
            _transposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
        }
        if (over) _transposer.m_FollowOffset = new(0, 5, 8);
        _camera.Follow = target;
    }

}