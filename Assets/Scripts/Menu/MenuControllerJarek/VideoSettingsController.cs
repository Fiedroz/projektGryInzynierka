using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettingsController : MonoBehaviour
{
    [SerializeField] int shadows;
    [SerializeField] int contactShadows;
    [SerializeField] int ambientOcclusion;
    [SerializeField] int tonemapping;
    [SerializeField] int bloom;
    [SerializeField] int exposure;
    [SerializeField] int visualEnvironment;
    [SerializeField] int motionBlur;
    // Start is called before the first frame update
    void Start()
    {
        shadows= 1;
        contactShadows= 1;
        ambientOcclusion= 1;
        tonemapping= 1;
        bloom= 1;
        exposure= 1;
        visualEnvironment= 1;
        motionBlur= 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
