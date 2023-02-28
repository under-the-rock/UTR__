using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ItemEffect/black/stone")]
public class InstalllEffect : ItemEffect
{ 
    public override bool ExecuteRole()
    {
        Debug.Log("install");
        return true;
    }
}
