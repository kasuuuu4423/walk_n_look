using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

public class CameraDistControl : MonoBehaviour
{
#if ENABLE_INPUT_SYSTEM
    [SerializeField] private StarterAssetsInputs _playerInput;
#endif
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float _distancePerTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInput != null)
        {
            if (_playerInput.cameraDistanceCloser)
            {
                Debug.Log(1);
                CinemachineComponentBase cinemachineComponentBase = _virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
                if(cinemachineComponentBase is CinemachineTransposer)
                {
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= _distancePerTime * Time.deltaTime;
                }
            }
            else if (_playerInput.cameraDistanceFurther)
            {
                CinemachineComponentBase cinemachineComponentBase = _virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
                if (cinemachineComponentBase is CinemachineTransposer)
                {
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance += _distancePerTime * Time.deltaTime;
                }
            }
        }
    }
}
