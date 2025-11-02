using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : SaveableObject
{
    [SerializeField] int value = 1;
    [SerializeField] float floatDistance = 0.2f;
    [SerializeField] float floatSpeed = 1.5f;
    private Vector3 posIni;

    public override object CaptureData()
    {
        return data = new CoinData(this);
    }

    public override void RestoreData(object data)
    {
        CoinData d = (CoinData) data;
        gameObject.SetActive(d.GetEnabled());
        value = d.GetValue();
        floatDistance = d.GetFloatDistance();
        floatSpeed = d.GetFloatSpeed();
        transform.position = d.GetPos();
    }

    private void Start()
    {
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
        gameObject.SetActive(false);
    }
}
