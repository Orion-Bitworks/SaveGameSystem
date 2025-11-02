using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AutoSaveController : MonoBehaviour
{
    //Lo hacemos singleton para que el autoguardado este siempre presente en escena
    public static AutoSaveController instance;
    
    //En este caso lo guardamos cada 5 segundos 
    [SerializeField] float timeToSave = 10f; //Gaurdamos el tiempo en segundos
    private float timer = 0f;

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
            //Cuando llega el tiempo a 0 se activa el metodo de autosave
            //y guarda partida de forma automatica
            timer += Time.deltaTime;

            if (timer >= timeToSave)
            {
                AutoSave();
                RestoreAutoSaveTimer();
            }
    }

    public void AutoSave()
    {
        SaveSystemController.SaveGame();
        Debug.Log("Se ha autoguardado!");
    }

    public void RestoreAutoSaveTimer()
    {
        timer = 0;
    }
}
