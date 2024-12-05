using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Platform : MonoBehaviour
{
    [SerializeField] private float _forceBounce;
    [SerializeField] private float _radiusBonce;

    public void Break()
    {
        PlatformSegment[] platformsSegment = GetComponentsInChildren<PlatformSegment>();
       
        foreach(PlatformSegment segment in platformsSegment) 
        {
            segment.Bounce(_forceBounce, transform.position, _radiusBonce);
        }
    }
}
