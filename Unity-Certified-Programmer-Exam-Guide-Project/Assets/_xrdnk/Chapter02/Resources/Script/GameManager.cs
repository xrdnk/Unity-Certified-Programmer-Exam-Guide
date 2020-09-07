using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        CameraSetup();
        LightSetup();
    }

    private void CameraSetup()
    {
        var gameCamera = GameObject.FindGameObjectWithTag(TagName.MainCamera);

        // Camera Transform
        gameCamera.transform.position = new Vector3(0, 0, -360);
        gameCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        // Camera Properties
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        gameCamera.GetComponent<Camera>().backgroundColor = new Color32(0, 0, 0, 255);
    }

    private void LightSetup()
    {
        var dirLight = GameObject.Find(ObjectName.DirectionalLight);
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Light>().color = new Color32(152, 204, 255, 255);
    }
}
