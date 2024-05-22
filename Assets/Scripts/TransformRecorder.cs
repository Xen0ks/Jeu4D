using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRecorder : MonoBehaviour
{
    private List<Vector3> m_recordedPositions = new List<Vector3>();
    private List<Quaternion> m_recordedRotations = new List<Quaternion>();
    void Start()
    {
        
    }

    void Update()
    {
        Record();
    }

    void Record()
    {
        m_recordedPositions.Add(transform.position);
        m_recordedRotations.Add(transform.rotation);
    }

    public void RestoreFrame(int frame)
    {
        Debug.Assert(m_recordedPositions.Count > frame);
        transform.position = m_recordedPositions[frame];
        transform.rotation = m_recordedRotations[frame];
    }
}
