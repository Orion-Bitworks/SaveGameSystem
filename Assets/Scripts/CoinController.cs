using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour, ISaveable
{
    [SerializeField] int value = 1;
    [SerializeField] float movementQuantity = 0.2f;
    [SerializeField] float movementSpeed = 1.5f;
    [SerializeField] private string id;
    private bool isEnabled = true;
    private CoinData data;
    private Vector3 posIni;

    public string GetUniqueID() => id;

    public object CaptureData()
    {
        return data = new CoinData(this);
    }

    public void RestoreData(object data)
    {
        CoinData dt = (CoinData) data;
        gameObject.SetActive(dt.enable);
        value = dt.value;
        movementQuantity = dt.movementQuantity;
        movementSpeed = dt.movementSpeed;
        transform.position = new Vector3(dt.pos[0], dt.pos[1], dt.pos[2]);
        posIni = new Vector3(dt.posIni[0], dt.posIni[1], dt.posIni[2]);
        //importante devolver enable a la variable, sino al guardar dos veces se quedara con el enable anterior y puede desaparecer de la nada
        isEnabled = dt.enable;
    }

    private void Start()
    {
        id = System.Guid.NewGuid().ToString();
        posIni = transform.position;
    }

    private void Update()
    {
        FloatingMovement();

        float newY = posIni.y + Mathf.Sin(Time.time * movementSpeed) * movementQuantity;
        transform.position = new Vector3(posIni.x, newY, posIni.z);
    }

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public float GetMovementQuantity()
    {
        return movementQuantity;
    }

    public void SetMovementQuantity(float newMovementQuantity)
    {
        movementQuantity = newMovementQuantity;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void SetMovementSpeed(float newMovementSpeed)
    {
        movementSpeed = newMovementSpeed;
    }

    public Vector3 GetPosIni()
    {
        return posIni;
    }

    public void SetPosIni(Vector3 newPosIni)
    {
        posIni = newPosIni;
    }

    public bool IsEnabled()
    {
        return isEnabled;
    }

    public void SetEnabled(bool isActive)
    {
        this.isEnabled = isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    public void PickUp(Collider player)
    {
        GameManager.instance.AddObtainedCoins(value);
        isEnabled = false;
        gameObject.SetActive(isEnabled);
    }

    public void FloatingMovement()
    {
        
    }
}
