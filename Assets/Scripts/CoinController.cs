using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private int value = 1;
    private bool isActive = true;

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public bool GetIsActive()
    {
        return isActive;
    }

    public void SetIsActive(bool isActive)
    {
        this.isActive = isActive;
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
        isActive = false;
        gameObject.SetActive(isActive);
    }
}
