using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour, ISaveable
{
    [SerializeField] int value = 1;
    [SerializeField] float floatDistance = 0.2f;
    [SerializeField] float floatSpeed = 1.5f;
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
        CoinData d = (CoinData) data;
        gameObject.SetActive(d.GetEnabled());
        value = d.GetValue();
        floatDistance = d.GetFloatDistance();
        floatSpeed = d.GetFloatSpeed();
        transform.position = d.GetPos();
        //importante devolver enable a la variable, sino al guardar dos veces se quedara con el enable anterior y puede desaparecer de la nada
        isEnabled = d.GetEnabled();
    }

    private void Start()
    {
        id = System.Guid.NewGuid().ToString();
        posIni = transform.position;
    }

    private void Update()
    {
        float newY = posIni.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
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

    public float GetFloatDistance()
    {
        return floatDistance;
    }

    public void SetFloatDistance(float newFloatDistance)
    {
        floatDistance = newFloatDistance;
    }

    public float GetFloatSpeed()
    {
        return floatSpeed;
    }

    public void SetMovementSpeed(float newFloatSpeed)
    {
        floatSpeed = newFloatSpeed;
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
}
