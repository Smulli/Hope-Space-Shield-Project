using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Utils{
    public class PoolAsteroid : MonoBehaviour
    {
        public static PoolAsteroid pooler;
        public Queue<Enemy.Collection.Asteroid> _available = new Queue<Enemy.Collection.Asteroid>();
        public List<Enemy.Collection.Asteroid> _instantiate = new List<Enemy.Collection.Asteroid>();
        [SerializeField] private Enemy.Collection.Asteroid _prefab;

        void Awake(){
            if(PoolAsteroid.pooler == null){
                pooler = this;
            }
            else{Destroy(gameObject);}
        }

        void Start(){
            for (int i = 0; i < 15; i++)
            {
                Enemy.Collection.Asteroid _asteroid = Instantiate(_prefab);
                _asteroid.PoolAsteroid = this;

                Recycle(_asteroid);
            }


            InvokeRepeating(nameof(Spawn), 0f, 1f);
        }

        private void Spawn(){
            Enemy.Collection.Asteroid _asteroid = GetAsteroid();
            /*Para despues
            _asteroid.SetColor()*/

            float xPos = Random.Range(-6f, 6f);

            _asteroid.transform.position = new Vector3(xPos, 10f, -8f);
            _asteroid.gameObject.SetActive(true);
        }

        public void Recycle(Enemy.Collection.Asteroid _asteroid){
            _asteroid.gameObject.SetActive(false);
            _asteroid.transform.position = Vector3.zero;
            _asteroid.transform.rotation = Quaternion.identity;
            _instantiate.Remove(_asteroid);
            _available.Enqueue(_asteroid);
        }

        public Enemy.Collection.Asteroid GetAsteroid(){
            Enemy.Collection.Asteroid _asteroid = _available.Dequeue();
            _instantiate.Add(_asteroid);

            return _asteroid;
        }

        public void RecycleAll(){
            //Mientras el numero de elementos en la lista sea mayor a 0 se reciclaran los elementos de la lista
            while(_instantiate.Count > 0){
                Recycle(_instantiate[0]);
            }
        }
    }

}

