using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneObject : MonoBehaviour, ISaveable
{
    private bool isEnabled = true;
    [SerializeField] private string id = System.Guid.NewGuid().ToString();
    ObjectData data;
    Rigidbody rb;

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
        rb.velocity = d.GetMovement();
        transform.rotation = d.GetRotation();
        rb.angularVelocity = d.GetRotationSpeed();
        //importante devolver enable a la variable, sino al guardar dos veces se quedara con el enable anterior y puede desaparecer de la nada
        isEnabled = d.GetEnabled();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool IsEnabled()
    {
        return isEnabled;
    }

    public void SetTransform(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    public void SetMovement(Vector3 movement)
    {
        rb.velocity = movement;
    }

    public Vector3 GetMovement()
    {
        return rb.velocity;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    public void SetRotation(Vector3 rotationSpeed)
    {
        rb.angularVelocity = rotationSpeed;
    }

    public Vector3 GetRotationSpeed()
    {
        return rb.angularVelocity;
    }
}
