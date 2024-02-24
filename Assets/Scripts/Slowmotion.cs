using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

public class Slowmotion : MonoBehaviour
{
#if ENABLE_INPUT_SYSTEM
    [SerializeField] private StarterAssetsInputs _playerInput;
#endif
    [SerializeField] private float slowTimescale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput != null)
        {
            if (_playerInput.slow)
            {
                Time.timeScale = slowTimescale;
            }
            else if (!_playerInput.slow && Time.timeScale == slowTimescale)
            {
                Time.timeScale = 1f;
            }
        }
    }
}
