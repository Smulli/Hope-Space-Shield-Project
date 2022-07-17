using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Utils;

namespace Enemy.Collection{
    public class AsteroidAttributes : MonoBehaviour
    {
        public PoolAsteroid PoolAsteroid{get; set;}
        public string _name; 
        public int _hit;

        public enum AsteroidTypes{
            classC,
            classB,
            gold
        }

        public AsteroidTypes _type{get; set;}

        public void SetAttributes(AsteroidTypes type){
            _type = type;
            

            switch(type){
                case
                AsteroidTypes.classC:{
                    _name = "classC";
                    _hit = 1;
                    transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                break;
                case
                AsteroidTypes.classB:{
                    _name = "classB";
                    _hit = 2;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                break;
                case
                AsteroidTypes.gold:{
                    _name = "gold";
                    _hit = 1;
                    transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                break;  
            }
        }
    }
}
