using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MniMapCamera : MonoBehaviour
{
    [SerializeField]
    private Camera miniMapCamera;
    [SerializeField]
    private float MaxZoom = 30f;
    [SerializeField]
    private float MinZoom = 1f;
    [SerializeField]
    private float OneStepZoom = 1f;


    public void zoomIn()
    {
        miniMapCamera.orthographicSize = Mathf.Max(miniMapCamera.orthographicSize - OneStepZoom, MinZoom);
    }

    public void ZoomOut()
    {
        miniMapCamera.orthographicSize = Mathf.Min(miniMapCamera.orthographicSize + OneStepZoom, MaxZoom);
    }
}
