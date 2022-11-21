using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cam : MonoBehaviour
{
    public static Cam Instance { get; private set; }
    private CinemachineVirtualCamera cam;
    private float duration;
    private void Awake()
    {
        Instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
        duration = time;
        
    }
    private void Update()
    {
        if (duration>0)
        {
            duration -= Time.deltaTime;
            if (duration<=0)
            {
                CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.m_AmplitudeGain = 0;
            }
        }
    }
    //public IEnumerator Shake(float duration,float magnitude)
    //{
    //    Vector3 originpos = transform.localPosition;
    //    float timer = 0;
    //    while (timer<duration)
    //    {
    //        float x = Random.Range(-1, 1) * magnitude;
    //        float y = Random.Range(-1, 1) * magnitude;
    //        transform.localPosition = new Vector3(x, y, originpos.z);
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.localPosition = originpos;
    //}
}
