using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoroutineChain {

    public class EnemyManager : MonoBehaviour {

        public List<Enemy> enemies;
        bool allEnemiesFinished = true;

        void Start() {

        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.L) && allEnemiesFinished) {
                allEnemiesFinished = false;
                StartCoroutine(MoveEnemies());
            }
        }

        IEnumerator MoveEnemies() {
            foreach (Enemy enemy in enemies) {
                yield return enemy.StartLoop();
            }

            allEnemiesFinished = true;
        }
    }
}
