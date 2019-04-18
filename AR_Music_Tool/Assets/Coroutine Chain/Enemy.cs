using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoroutineChain {
    public class Enemy : MonoBehaviour {

        public EnemyManager enemyManager;

        public float movementSpeed;
        public float howLong;
        bool finishedLoop = true;
        Vector3 direction;

        void Start() {
            enemyManager = FindObjectOfType<EnemyManager>();
        }

        void Update() {
            if (!finishedLoop) {
                transform.Translate(direction * movementSpeed);
            }
        }

        public IEnumerator StartLoop() {
            finishedLoop = false;
            yield return StartCoroutine(MoveRight());
            yield return StartCoroutine(MoveUp());
            yield return StartCoroutine(MoveLeft());
            yield return StartCoroutine(MoveDown());
            finishedLoop = true;

        }

        IEnumerator MoveRight() {
            direction = Vector3.right;
            yield return new WaitForSeconds(howLong);
        }

        IEnumerator MoveUp() {
            direction = Vector3.up;
            yield return new WaitForSeconds(howLong);
        }

        IEnumerator MoveLeft() {
            direction = Vector3.left;
            yield return new WaitForSeconds(howLong);
        }

        IEnumerator MoveDown() {
            direction = Vector3.down;
            yield return new WaitForSeconds(howLong);
        }

    }
}
