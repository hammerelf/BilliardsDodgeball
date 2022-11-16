using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BilliardsDodgeball
{
    public class PlayerBecomeBall : MonoBehaviour
    {
        public List<GameObject> possibleBalls = new List<GameObject>();
        public List<GameObject> playerBalls = new List<GameObject>();
        public Transform playerBallsParentObject;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter: collision tag: " + other.gameObject.tag);
            if (other.gameObject.CompareTag("Player"))
            {
                BecomeBall(other);
                //other.gameObject.transform.SetPositionAndRotation(teleportToSpot.position, teleportToSpot.rotation);
                //if (isEntering)
                //{
                //    BDBManager.BDBM bdbManager.playerCount++;
                //}
                //else
                //{
                //    bdbManager.playerCount--;
                //    bdbManager.CheckForGameOver();
                //}
            }
        }

        public void BecomeBall(Collider other)
        {
            GameObject ballToBe = possibleBalls[Random.Range(0, possibleBalls.Count - 1)];
            GameObject holder = Instantiate(new GameObject(ballToBe.name + "Holder"), playerBallsParentObject);
            possibleBalls.Remove(ballToBe);
            playerBalls.Add(ballToBe);
            other.gameObject.transform.SetPositionAndRotation(ballToBe.transform.position, other.gameObject.transform.rotation);
            ballToBe.transform.parent = holder.transform;
            other.gameObject.transform.parent = holder.transform;
        }
    }
}
