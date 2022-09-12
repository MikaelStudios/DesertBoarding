using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] KeyCode _toogleKey;
    [SerializeField] CinemachineVirtualCamera _virtualCamera;

    public float _minimum = 2f;
    public float _maximum;
    static float t = 0f;

    // public static CameraZoom instance;

    // public void Awake()
    // {
    //     instance = this;
    // }

    void Start()
    {
       _minimum = _virtualCamera.m_Lens.OrthographicSize;
       _maximum = _minimum * 2;
    }

    public void Update()
    {
        // if(Input.GetKeyDown(_toogleKey)) {
        //     StopAllCoroutines();
        //     StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _maximum));
        // }
        // if(Input.GetKeyUp(_toogleKey)) {
        //     StopAllCoroutines();
        //     StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _minimum));
        // }

        // if (!LongPressed.instance.brakeButtonDown)
        // {
        //    StopAllCoroutines();
        //    StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _maximum));  
        // }
        // if (!LongPressed.instance.nitroButtonDown)
        // {
        //     StopAllCoroutines();
        //     StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _maximum));
        // }
        
    }

    public void ZoomOut()
    {
         StopAllCoroutines();
         StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _maximum));
    }

    public void ZoomIn()
    {
           StopAllCoroutines();
           StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _minimum));
    }

    IEnumerator Lerp(float start, float end)
    {
        t = 0f;
        while(_virtualCamera.m_Lens.OrthographicSize != end) {
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(start, end, t);
            t += 0.2f * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
