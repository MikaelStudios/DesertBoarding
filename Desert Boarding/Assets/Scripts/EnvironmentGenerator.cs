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

    //Sets how intense the ground bumps will get with distance
    public float xDifficulty;
    public float yDifficulty;

    public Vector3 lastPos;

    public float depth;

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

            if (i != 0  && i != cycles - 1)
            {
            spriteShape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteShape.spline.SetLeftTangent(i, Vector3.left * x * curve);
            spriteShape.spline.SetRightTangent(i, Vector3.right * x * curve);
            }

            x += xDifficulty;
            y += yDifficulty;
        }

        spriteShape.spline.InsertPointAt(cycles, new Vector3(lastPos.x, transform.position.y - depth));
        spriteShape.spline.InsertPointAt(cycles + 1, new Vector3(transform.position.x, transform.position.y - depth));
    }
}
