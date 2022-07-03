using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Utils;

namespace Enemy.Collection{
    public class Asteroid : MonoBehaviour
    {
        public PoolAsteroid PoolAsteroid{get; set;}
        private float _speed = 4f;
        public GameObject[] _targets = new GameObject[4];
        public Transform _position;

        private void Awake(){
            gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        void Start(){
            _targets = GameObject.FindGameObjectsWithTag("Colony");
            _position = _targets[Random.Range(0, _targets.Length)].transform;
        }
        
        void Update(){
            transform.position = Vector3.MoveTowards(transform.position, _position.position, _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col){
            if(col.tag == "Colony"){
                PoolAsteroid.Recycle(this);
            }
        }
    }
}

