using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//creamos una interface
public interface ISaveable
{
    string GetUniqueID();
    object CaptureData();
    void RestoreData(object data);
}
