using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveTimeline : MonoBehaviour
{
    [SerializeField] private GameObject[] timelineStart;
    [SerializeField] private GameObject[] setObjectAT;
    private void Start()
    {
        TimelineStart();
    }
    private void TimelineStart()
    {
        if (TimelineManager.Instance.isTimelineStart)
        {
            timelineStart[Player.Instance.gender].SetActive(true);
            TimelineManager.Instance.SetActiveTimelineStart(false);
        }
        else
        {
            for(int i = 0; i < setObjectAT.Length; i++)
            {
                setObjectAT[i].SetActive(true);
            }
        }
    }
}
