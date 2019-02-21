using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Player : MonoBehaviour
    {
        public string PlayerName;
        public int Health = 100;
        public GameObject Cube;
        public GameObject Particle;
        public bool IsAlive = true;
        public string x;
        public string y;
        public bool collision;


    }


}
