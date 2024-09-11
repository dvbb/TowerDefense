using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;
    public Turret Turret { get; private set; }

    public void SetTurret(Turret turret)
    {
        Turret = turret;
    }

    public void SelectTurret()
    {
        OnNodeSelected?.Invoke(this);
    }

    public bool IsEmpty() => Turret == null;
}
