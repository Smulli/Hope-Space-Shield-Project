using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Utils;

namespace Player.Collection{
    public class BulletController : MonoBehaviour
    {
       private float _speed = 1f;

        // Update is called once per frame
        void Update()
        {
            Rigidbody2D _rb = gameObject.GetComponent<Rigidbody2D>();
            _rb.AddForce(BulletPool.pooler._initPos.up * _speed, ForceMode2D.Impulse);
        }

        void FixedUpdate(){
            GameObject _bullet = this.gameObject;

            if(transform.position.y > 10f){
                BulletPool.pooler.Recycle(_bullet);
            }
        }
    }
}
