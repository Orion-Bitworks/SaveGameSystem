using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//guardamos todas las variables que nos interesan gaurdar de SceneObject en este caso
//!!!!!!! hay que añadir una variable para guardar si se esta moviendo o no a la hora de guardar!!!!!!!!!!!
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
