using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BilliardsDodgeball
{
    public class BallMover : MonoBehaviour
    {
        public GameObject smallBall;
        // [HideInInspector] 
        public GameObject playerToFollow;

        public bool followingPlayer;
        public bool isBigBall;

        private void Update()
        {
            if (followingPlayer)
            {
                if (playerToFollow != null)
                {
                    transform.SetPositionAndRotation(playerToFollow.transform.position, playerToFollow.transform.rotation);
                    smallBall.transform.SetPositionAndRotation(new Vector3((BDBManager.BDBM.parentScaleReverse * playerToFollow.transform.position.x) + BDBManager.BDBM.xOffset, BDBManager.BDBM.smallCueBall.transform.position.y, (BDBManager.BDBM.parentScaleReverse * playerToFollow.transform.position.z) + BDBManager.BDBM.zOffset), transform.rotation);
                }
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3((BDBManager.BDBM.parentScale * smallBall.transform.position.x) + BDBManager.BDBM.xOffset, BDBManager.BDBM.bigCueBall.transform.position.y, (BDBManager.BDBM.parentScale * smallBall.transform.position.z) + BDBManager.BDBM.zOffset), smallBall.transform.rotation);

                if (playerToFollow != null)
                {
                    playerToFollow.transform.SetPositionAndRotation(transform.position, playerToFollow.transform.rotation);
                }
            }
        }
    }
}
