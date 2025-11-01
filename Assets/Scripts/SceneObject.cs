using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneObject : MonoBehaviour, ISaveable
{
    bool enable = true;
    [SerializeField] private string id = System.Guid.NewGuid().ToString();
    ObjectData data;
 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enable = false;
            gameObject.SetActive(enable);
            
        }
    }
    public string GetUniqueID() => id;

    public object CaptureData()
    {
        return data = new ObjectData(this);
    }

    public void RestoreData(object data)
    {
        ObjectData d = (ObjectData)data;
        gameObject.SetActive(d.enable);
        transform.position = new Vector3(d.pos[0], d.pos[1], d.pos[2]);
    }

    /*public void LoadObjects()
    {
        ObjectData data = SaveSystemController.LoadObject();
        enable = data.enable;
        gameObject.SetActive(enable);
        Vector3 pos;

        pos.x = data.pos[0];
        pos.y = data.pos[1];
        pos.z = data.pos[2];

        SetTransform(pos);
    }*/

    public bool IsEnable()
    {

        return enable;
    }
    public void SetTransform(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
