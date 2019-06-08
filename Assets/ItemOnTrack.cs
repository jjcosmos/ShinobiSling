using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnTrack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform TrackItem;
    [SerializeField] float trackSpeed = 10;
    [SerializeField] List<Transform> TrackPoints;

    LineRenderer lineRend;

    private int trackIndex = 0;
    void Start()
    {
        TrackItem.position = TrackPoints[0].position;
        trackIndex = 0;
        lineRend = GetComponent<LineRenderer>();
        List<Transform> TempPoints = TrackPoints;
        TempPoints.Add(TrackPoints[0]);
        List<Vector3> TempPositions = new List<Vector3>();
        foreach (Transform tform in TempPoints)
        {
            TempPositions.Add(tform.position);
        }

        lineRend.SetPositions(TempPositions.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        if(TrackItem.position == TrackPoints[trackIndex].position)
        {
            if(trackIndex+1 < TrackPoints.Count)
            {
                trackIndex++;
            }
            else
            {
                trackIndex = 0;
            }

        }

        TrackItem.position = Vector3.MoveTowards(TrackItem.position, TrackPoints[trackIndex].position, trackSpeed * Time.deltaTime);
    }
}
