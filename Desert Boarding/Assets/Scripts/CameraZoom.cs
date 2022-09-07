using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] KeyCode _toogleKey;
    [SerializeField] CinemachineVirtualCamera _virtualCamera;

    public float _minimum = 3.5f;
    public float _maximum;
    static float t = 0f;

    void Start()
    {
       _minimum = _virtualCamera.m_Lens.OrthographicSize;
       _maximum = _minimum * 2;
    }

    void Update()
    {
        if(Input.GetKeyDown(_toogleKey)) {
            StopAllCoroutines();
            StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _maximum));
        }
        if(Input.GetKeyUp(_toogleKey)) {
            StopAllCoroutines();
            StartCoroutine(Lerp(_virtualCamera.m_Lens.OrthographicSize, _minimum));
        }

        // ZoomOut();
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
            t += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
