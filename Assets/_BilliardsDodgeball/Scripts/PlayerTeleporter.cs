using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BilliardsDodgeball
{
    public class PlayerTeleporter : MonoBehaviour
    {
        public Transform teleportToSpot;
        public bool isEntering, isPlayer;

        public List<GameObject> possibleBalls = new List<GameObject>();
        public List<GameObject> playerBalls = new List<GameObject>();
        public GameObject smallBall;

        private void OnTriggerEnter(Collider other)
        {
            //TODO: isPlayer not being set to true on balls to stop linked movement with small ball.
            Debug.Log("OnTriggerEnter: collision tag: " + other.gameObject.tag);
            if (other.gameObject.CompareTag("Player"))
            {
                BDBManager.BDBM.players.Add(other.gameObject);
                BDBManager.BDBM.playerCount++;
                BecomeBall(other.gameObject.transform);


                //if (isEntering)
                //{
                //    BDBManager.BDBM.playerCount++;
                //    isPlayer = true;
                //    BecomeBall(other.gameObject.transform);
                //    other.gameObject.transform.SetPositionAndRotation(teleportToSpot.position, teleportToSpot.rotation);
                //}
                //else
                //{
                //    bdbManager.playerCount--;
                //    isPlayer = false;
                //    bdbManager.CheckForGameOver();
                //}
            }
        }

        public void BecomeBall(Transform playerTrans)
        {
            print("possibleBalls.Count: " + possibleBalls.Count);
            GameObject ballToBe = possibleBalls[Random.Range(0, possibleBalls.Count)];
            BallMover bm = ballToBe.GetComponent<BallMover>();
            bm.followingPlayer = true;
            bm.playerToFollow = playerTrans.gameObject;
            possibleBalls.Remove(ballToBe);
            playerBalls.Add(ballToBe);
            playerTrans.SetPositionAndRotation(ballToBe.transform.position, teleportToSpot.rotation);
            //ballToBe.transform.parent = playerTrans;
            //ballToBe.GetComponent<Rigidbody>().isKinematic = true;
            ballToBe.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
