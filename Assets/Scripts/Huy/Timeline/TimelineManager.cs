using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance { get; private set; }
    private bool IsTimelineStart = false;
    public bool isTimelineStart { get => IsTimelineStart; set => IsTimelineStart = value; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetActiveTimelineStart(bool SetActive)
    {
        isTimelineStart = SetActive;
    }


    
}
