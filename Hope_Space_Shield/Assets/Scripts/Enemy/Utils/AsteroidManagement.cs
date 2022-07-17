using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Collection;

namespace Enemy.Utils{
    public class AsteroidManagement : MonoBehaviour
    {
        public static AsteroidManagement Instance{get; private set;}
        public string[] _types => System.Enum.GetNames(typeof(AsteroidAttributes.AsteroidTypes));

        void Awake(){
            Instance = this;
        }

        public AsteroidAttributes.AsteroidTypes GetRandomAttribute(){
            return(AsteroidAttributes.AsteroidTypes)Random.Range(0, System.Enum.GetNames(typeof(AsteroidAttributes.AsteroidTypes)).Length);
        }
    } 
}
