using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AutoSaveController : MonoBehaviour
{
    //lo hacemos singleton para que el autoguardado este siempre presente en escena
    private static AutoSaveController instance;
    
    //En este caso lo guardamos cada 5 segundos 
    public float timeToSave = 10f; //gaurdamos el tiempo en segundo
    private float currentTime = 0f;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        //cuando llega el tiempo a 0 se activa el metodo de autosave
        //y guarda partida de forma automatica
            currentTime += Time.deltaTime;

            if (currentTime >= timeToSave)
            {
                AutoSave();
            currentTime = 0f;
            }
        
    }

    public void AutoSave()
    {
        SaveSystemController.SaveGame();
        Debug.Log("Se ha autoguardado!");
    }

}
