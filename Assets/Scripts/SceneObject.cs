using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneObject : MonoBehaviour, ISaveable
{
    //!!! hay que añadir una variable para ver si se esta moviendo o no a la hora de guardar!!!!
    bool isEnabled = true;
    [SerializeField] private string id = System.Guid.NewGuid().ToString();
    ObjectData data;

    //le damos una id unica para que cada objeto sea diferente   
    public string GetUniqueID() => id;
    //guardamos las variables de SceneObject, en este caso la posicion o si esta enable
    public object CaptureData()
    {
        return data = new ObjectData(this);
    }
    //le devolmemos los datos anteriormente guardados
    public void RestoreData(object data)
    {
        ObjectData d = (ObjectData)data;
        gameObject.SetActive(d.GetEnabled());
        transform.position = d.GetPos();
        //importante devolver enable a la variable, sino al guardar dos veces se quedara con el enable anterior y puede desaparecer de la nada
        isEnabled = d.GetEnabled();
    }

    public bool IsEnabled()
    {

        return isEnabled;
    }
    public void SetTransform(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
