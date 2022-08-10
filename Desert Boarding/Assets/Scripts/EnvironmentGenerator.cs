using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]

public class EnvironmentGenerator : MonoBehaviour
{
    public int cycles;
    public float noiseStep;
    public float xMultiplier;
    public float yMultiplier;
    public float curve;

    public Vector3 lastPos;

    private void OnValidate()
    {
        SpriteShapeController spriteShape = GetComponent<SpriteShapeController>();
        spriteShape.spline.Clear();

        float x = xMultiplier;
        float y = yMultiplier;

        for(int i = 0; i < cycles; i++)
        {
            lastPos = transform.position + new Vector3(i * x, Mathf.PerlinNoise(0, i * noiseStep) * y);

            spriteShape.spline.InsertPointAt(i, lastPos);

            spriteShape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteShape.spline.SetLeftTangent(i, Vector3.left * x * curve);
            spriteShape.spline.SetRightTangent(i, Vector3.right * x * curve);
        }
    }
}
