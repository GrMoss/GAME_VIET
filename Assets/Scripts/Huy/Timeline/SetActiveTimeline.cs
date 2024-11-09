using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveTimeline : MonoBehaviour
{
    [SerializeField] private GameObject[] timelineStart;

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
    }
}
