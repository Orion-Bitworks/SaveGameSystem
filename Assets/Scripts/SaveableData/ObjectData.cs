using UnityEngine;

//guardamos todas las variables que nos interesan gaurdar de SceneObject en este caso
[System.Serializable]
public class ObjectData : SaveData
{
    private float[] movement;
    private float[] rotation;
    private float[] rotationSpeed;

    public ObjectData(SceneObject saveObject)
    {
        SetEnabled(saveObject.IsEnabled());
        SetPos(saveObject.transform.position);
        SetMovement(saveObject.GetMovement());
        SetRotationSpeed(saveObject.GetRotationSpeed());
        SetRotation(saveObject.GetRotation());
    }

    public void SetMovement(Vector3 movement)
    {
        this.movement = new float[] { movement.x, movement.y, movement.z };
    }

    public Vector3 GetMovement()
    {
        return new Vector3( movement[0], movement[1], movement[2] );
    }

    public void SetRotationSpeed(Vector3 rotationSpeed)
    {
        this.rotationSpeed = new float[] { rotationSpeed.x, rotationSpeed.y, rotationSpeed.z};
    }

    public Vector3 GetRotationSpeed()
    {
        return new Vector3(rotationSpeed[0], rotationSpeed[1], rotationSpeed[2]);
    }

    public void SetRotation(Quaternion rotation)
    {
        this.rotation = new float[] { rotation.x, rotation.y, rotation.z, rotation.w };
    }

    public Quaternion GetRotation()
    {
        return new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]);
    }
}
