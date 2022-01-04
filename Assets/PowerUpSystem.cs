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

        public PowerUp()
        {
            Name = "None";
            Active = false;
        }
    }

    [System.Serializable]
    public class Bounce : PowerUp
    {
        public int BounceCount;
        public Bounce()
        {
            Name = "Bounce";
            Active = false;
            BounceCount = 1;
        }
    }

    [System.Serializable]
    public class Charge : PowerUp
    {
        public float ChargeRatePerSecond;
        public Vector2 MaxChargeSize;

        public Charge()
        {
            Name = "Charge";
            Active = false;
            ChargeRatePerSecond = 1f;
            MaxChargeSize = new Vector2(3f, 3f);
        }
    }
}




