using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Utils;

namespace Player.Collection{ 
    public class PlayerController : MonoBehaviour {
        
        public static PlayerController player;
        public float _angle;
        public float _speed;
        public float rotMin = -40f;
        public float rotMax = 40f;
        private float _fireRate = 0.5f;
        private float _lastShot;

        void FixedUpdate(){
            if(Input.GetButton("Fire1")){
                _angle += Input.GetAxis("MouseX") * _speed * -Time.deltaTime;
                _angle = Mathf.Clamp(_angle, rotMin, rotMax); 

                transform.rotation = Quaternion.Euler(0f, 0f, _angle);

                if(Time.time > _fireRate + _lastShot){
                    BulletPool.pooler.Shoot();
                    _lastShot = Time.time;
                }
            }
        }
    }
}


