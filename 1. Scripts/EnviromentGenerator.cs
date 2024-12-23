using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode] // let script be able to execute in editor mod
public class EnviromentGenerator : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;

    [Range(3f, 100f)] public int levelLength = 50;
    [Range(1f, 50f)] public float xMultiplier = 2f;
    [Range(1f, 50f)] public float yMultiplier = 2f;
    [Range(0f, 1f)] public float curveSmoothness = 0.5f;
    public float noiseStep = 0.5f;
    public float bottom = 10f;

    private Vector3 lastPos;

    private void OnValidate() // Event Method in Editor stage
    {
        spriteShapeController.spline.Clear();

        for(int i = 0; i < levelLength; i++)
        {
            lastPos = transform.position + new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
            spriteShapeController.spline.InsertPointAt(i, lastPos);

            if(i != 0 && i != levelLength - 1)
            {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
            }
        }

        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPos.x, transform.position.y - bottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
