using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour, ISaveable
{
    [SerializeField] int value = 1;
    private string id = "coin";
    private bool isEnabled = true;
    private CoinData data;

    public string GetUniqueID() => id;

    public object CaptureData()
    {
        return data = new CoinData(this);
    }

    public void RestoreData(object data)
    {
        CoinData dt = (CoinData) data;
        gameObject.SetActive(dt.enable);
        transform.position = new Vector3(dt.pos[0], dt.pos[1], dt.pos[2]);
        //importante devolver enable a la variable, sino al guardar dos veces se quedara con el enable anterior y puede desaparecer de la nada
        isEnabled = dt.enable;
    }

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
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
