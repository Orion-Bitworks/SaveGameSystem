using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneObject : SaveableObject
{
    private Rigidbody rb;

    //Guardamos las variables de SceneObject, en este caso la posicion o si esta enable
    public override object CaptureData()
    {
        return data = new ObjectData(this);
    }
    //Le devolmemos los datos anteriormente guardados
    public override void RestoreData(object data)
    {
        ObjectData d = (ObjectData)data;
        gameObject.SetActive(d.GetEnabled());
        transform.position = d.GetPos();
        rb.velocity = d.GetMovement();
        transform.rotation = d.GetRotation();
        rb.angularVelocity = d.GetRotationSpeed();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
