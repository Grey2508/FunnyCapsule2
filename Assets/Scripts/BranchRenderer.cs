using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BranchRenderer : MonoBehaviour
{
    public RopeRenderer RopeRenderer;
    public Transform A;
    public Transform B;

    void Update()
    {
        RopeRenderer.DrawLine(A.position, B.position);
    }
}
