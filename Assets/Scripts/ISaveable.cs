using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    string GetUniqueID();
    object CaptureData();
    void RestoreData(object data);
}
