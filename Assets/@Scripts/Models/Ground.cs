using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Entity {

    public void SetInfo(Vector3 position, Quaternion rotation) {
        Initialize();

        this.transform.position = position;
        this.transform.localRotation = rotation;
    }

}