using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private bool enable;
    private float[] pos;

    public void SetEnabled(bool enable)
    {
        this.enable = enable;
    }

    public void SetPos(Vector3 position)
    {
        pos = new float[] { position.x, position.y, position.z };
    }

    public Vector3 GetPos()
    {
        return new Vector3(pos[0], pos[1], pos[2]);
    }
}
