using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BilliardsDodgeball
{
    public class BDBManager : MonoBehaviour
    {
        public int playerCount;
        public bool gameOver;
        public static BDBManager BDBM;
        public List<GameObject> smallBalls, bigBalls;
        [HideInInspector] public float parentScale, parentScaleReverse;
        public Transform regularParent, scaledParent;
        public float xOffset, zOffset;

        //New logic vars
        public List<GameObject> players = new List<GameObject>();
        public GameObject bigCueBall, smallCueBall;
        public bool isItRunTime;

        public BoolSwitchCuzStupid bscs;

        // Start is called before the first frame update
        void Start()
        {
            if (BDBM != null && BDBM != this)
            {
                Destroy(this);
            }
            else
            {
                BDBM = this;
            }

            //Set scale for tables based on x value
            parentScale = scaledParent.localScale.x / regularParent.localScale.x;
            parentScaleReverse = regularParent.localScale.x / scaledParent.localScale.x;

            isItRunTime = bscs.runDummy;
        }

        // Update is called once per frame
        void Update()
        {
            bigCueBall.transform.SetPositionAndRotation(new Vector3((parentScale * smallCueBall.transform.position.x) + xOffset, bigCueBall.transform.position.y, (parentScale * smallCueBall.transform.position.z) + zOffset), smallCueBall.transform.rotation);

            //BallMover bm;
            //foreach (GameObject ball in bigBalls)
            //{
            //    bm = ball.GetComponent<BallMover>();
            //    if (!bm.followingPlayer)
            //    {
            //        ball.transform.SetPositionAndRotation(new Vector3((parentScale * bm.smallBall.transform.position.x) + xOffset, ball.transform.position.y, (parentScale * bm.smallBall.transform.position.z) + zOffset), bm.smallBall.transform.rotation);
            //    }
            //}
        }

        public void CheckForGameOver()
        {
            if (playerCount <= 0)
            {
                gameOver = true;
            }
        }

        public void runTimeToggle()
        {
            isItRunTime = !isItRunTime;
            if(isItRunTime)
            {
                print("Green light!!!");
            }
            else
            {
                print("Red Light!!!");
            }
        }
    }
}
