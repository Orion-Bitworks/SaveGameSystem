using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public bool enable;
    public float[] pos;

    public ObjectData(SceneObject saveObject)
    {
        enable = saveObject.IsEnable();
        pos = new float[] { saveObject.transform.position.x, saveObject.transform.position.y, saveObject.transform.position.z };
    }
}
