using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    public Bounce bounce;
    public Charge charge;

    [System.Serializable]
    public class PowerUp
    {
        public string Name;
        public bool Active;
    }

    [System.Serializable]
    public class Bounce : PowerUp
    {
        public int BounceCount;
    }

    [System.Serializable]
    public class Charge : PowerUp
    {
        public float ChargeRatePerSecond;
        public Vector2 MaxChargeSize;
    }
}




