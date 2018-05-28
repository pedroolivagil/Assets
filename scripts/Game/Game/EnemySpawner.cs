using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Game{
    public class EnemySpawner : MonoBehaviour{
        public float TimeToRespawn = 30f;
        [Tooltip("Number of enemies per spawn point to appears in game")]
        public int EnemyQuantity = 3;
        [Tooltip("Maximum level that will have the enemies that will go through the spawn points")]
        public int MaxEnemyLevel = 3;

        private List<Transform> _spawners;

        // Use this for initialization
        void Start(){
            _spawners = new List<Transform>();
            var all = gameObject.GetComponentsInChildren<Transform>();
            foreach (var gObject in all){
                if (gObject.CompareTag(Tag.EnemySpawner.ToString())){
                    _spawners.Add(gObject);
                }
            }
            StartCoroutine(Respawn());
        }

        private IEnumerator Respawn(){
            yield return new WaitForSeconds(TimeToRespawn);
            Debug.Log("EnemySpawner.Respawn() is IN.");
            foreach (var gob in _spawners){
                for (int x = 0; x < EnemyQuantity; x++){
                    Debug.Log("Spawning enemy...");
                    if (FindObjectsOfType<Player>().Length > 0){
                        Debug.Log("Enemy spawned");
                        GameManager.InstantiatePhoton(RandomEnemy(), gob, gob.parent.gameObject);
                    }
                    yield return new WaitForSeconds(1f / 100f);
                }
            }
            yield return Respawn();
        }

        private string RandomEnemy(){
            if (MaxEnemyLevel > 4){
                MaxEnemyLevel = 4;
            }
            string url = "Actors/Enemies/Enemy";
            url += GameManager.RandomBetween(1, 4 * MaxEnemyLevel);
            Debug.Log("EnemySpawned: " + url);
            return url;
        }
    }
}