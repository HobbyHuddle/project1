using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    public int powerUpCount;
    public Bounce bounce;
    public List<Bounce> powerUps = new List<Bounce>();


    private void Start()
    {
        powerUps.Add(bounce);
    }


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
        public float MaxChargeTime;

        public Charge()
        {
            Name = "Bounce";
            Active = false;
            MaxChargeTime = 3;
        }
    }
}




