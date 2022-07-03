using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Utils{
    public class BulletPool : MonoBehaviour
    {
        public static BulletPool pooler;
        public Transform _initPos;
        [SerializeField] private GameObject _prefab;
        public Queue<GameObject> _available = new Queue<GameObject>();
        public List<GameObject> _instantiate = new List<GameObject>();
        
        void Awake(){
            if(BulletPool.pooler == null){
                pooler = this;
            }
            else{Destroy(gameObject);}
        }

        void Start(){
            for(int i = 0; i < 3; i++){
                GameObject _bullet = Instantiate(_prefab);
                Recycle(_bullet);
            }
        }

        public void Shoot(){
            GameObject _bullet = GetBullet();

            float _posX = _initPos.transform.position.x;
            float _posY = _initPos.transform.position.y;
            float _posZ = _initPos.transform.position.z;  

            _bullet.transform.position = new Vector3(_posX, _posY, _posZ);
            _bullet.gameObject.SetActive(true);

            if(_available.Count < 1){
                CreateNewBullet();
            }
        }

        public void Recycle(GameObject _bullet){
            _bullet.gameObject.SetActive(false);
            _bullet.transform.position = Vector3.zero;
            _bullet.transform.rotation = Quaternion.identity;
            _instantiate.Remove(_bullet);
            _available.Enqueue(_bullet);
        }

        public GameObject GetBullet(){
            GameObject _bullet = _available.Dequeue();
            _instantiate.Add(_bullet);

            return _bullet;
        }

        public GameObject CreateNewBullet(){         
            GameObject _bullet = Instantiate(_prefab);
            Recycle(_bullet);

            return _bullet;
        }
    }    
}
