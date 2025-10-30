using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveableObject : MonoBehaviour
{

    bool enable = true;

    public void SaveObjects()
    {
        SaveSystemController.SaveSaveableObjects(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enable = false;
            gameObject.SetActive(enable);
            
        }
    }
    public void LoadObjects()
    {
        ObjectData data = SaveSystemController.LoadObject();
        enable = data.enable;
        gameObject.SetActive(enable);
        Vector3 pos;

        pos.x = data.pos[0];
        pos.y = data.pos[1];
        pos.z = data.pos[2];

        SetTransform(pos);
    }

    public bool IsEnable()
    {

        return enable;
    }
    public void SetTransform(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
