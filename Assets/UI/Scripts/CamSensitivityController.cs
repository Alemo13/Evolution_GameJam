using Cinemachine;
using UnityEngine;

public class CamSensitivityController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;

    public void SetSensitivityX(float xAxis)
    {
        freeLookCamera.m_XAxis.m_MaxSpeed = xAxis;
    }

    public void SetSensitivityY(float yAxis)
    {
        freeLookCamera.m_YAxis.m_MaxSpeed = yAxis;
    }
}
