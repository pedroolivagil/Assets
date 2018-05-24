using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Game{
    public class EnemySpawner : MonoBehaviour{
        public float TimeToRespawn = 30f;
        [Tooltip("Number of enemies per spawn point")] public int EnemyQuantity = 3;

        [Tooltip("Maximum level that will have the enemies that will go through the spawn points")]
        public int MaxEnemyLevel = 3;

        private List<GameObject> _spawners;

        // Use this for initialization
        void Start(){
            _spawners = new List<GameObject>();
            var all = GetComponentsInChildren<GameObject>();
            foreach (var gObject in all){
                if (gObject.CompareTag(Tag.Enemy.ToString())){
                    _spawners.Add(gObject);
                }
            }
            StartCoroutine(Respawn());
        }

        private IEnumerator Respawn(){
            yield return new WaitForSeconds(TimeToRespawn);
            foreach (var gob in _spawners){
                for (int x = 0; x < EnemyQuantity; x++){
                    var prefab = RandomEnemy();
                    if (prefab != null){
                        GameManager.InstantiatePhoton(prefab, gob.transform, gob.transform.parent.gameObject);
                        yield return new WaitForSeconds(1f / 100f);
                    }
                }
            }
        }

        private string RandomEnemy(){
            if (MaxEnemyLevel > 4){
                return null;
            }
            string url = "Actors/Enemies/Type";
            url += GameManager.RandomBetween(1, MaxEnemyLevel);
            url += "/Enemy" + GameManager.RandomBetween(1, 4);
            return url;
        }
    }
}