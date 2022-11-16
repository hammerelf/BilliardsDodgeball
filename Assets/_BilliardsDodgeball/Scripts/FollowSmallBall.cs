using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSmallBall : MonoBehaviour
{
    public GameObject SmallBall, SmallTable, BigTable;
    float xTableDiff, yTableDiff, zTableDiff = 0;

    // Start is called before the first frame update
    void Start()
    {
        xTableDiff = SmallTable.transform.position.x - BigTable.transform.position.x;
        yTableDiff = SmallTable.transform.position.y - BigTable.transform.position.y;
        zTableDiff = SmallTable.transform.position.z - BigTable.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((SmallBall.transform.position.x * 10 - xTableDiff), (SmallBall.transform.position.y * 10 - yTableDiff), (SmallBall.transform.position.z * 10 - zTableDiff));
    }
}
