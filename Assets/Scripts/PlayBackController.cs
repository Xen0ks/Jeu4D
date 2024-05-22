using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackController : MonoBehaviour
{
    private bool m_isPlaybackBefore = false;
    private int m_playbackFrame = 0;
    private int m_playbackSpeed = 1;
    public TransformRecorder[] m_recorders;

    public int Frame => m_playbackFrame;
    public bool IsPlaybackBefore => m_isPlaybackBefore;

    public void GoAfter()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GoBefore();
        }
    }

    public void GoBefore()
    {
        foreach(var recorder in m_recorders)
        {
            recorder.RestoreFrame(m_playbackFrame);
        }
    }
    private void RestoreFrame()
    {
        if (m_isPlaybackBefore)
        {
            m_playbackFrame = Mathf.Max(0, m_playbackFrame + m_playbackSpeed);
            RestoreFrame();
        }
        else
        {
            m_playbackFrame++;
        }
    }

}
