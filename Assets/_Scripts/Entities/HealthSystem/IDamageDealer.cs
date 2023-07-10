using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDealer
{
    public float DamageAmount { get; set; }
    public abstract bool TakeDamageCondition(GameObject other);   
}
