using UnityEngine;
using System;

public class MoveSurfaceWithMaterial : MonoBehaviour
{
    public Material material;  // The material of the surface (e.g., conveyor belt)
    public float speed = 0f;   // Speed of surface movement
    private Vector2 textureOffset;
    public TrashManager trashManager;
    private Vector2 previousOffset = new Vector2(0,0);
    private float previousTime = 0f;

    void Start()
    {
        // Ensure the material is assigned
        if (material == null)
        {
            material = GetComponent<Renderer>().material;
        }

        speed = trashManager.trashSpeed;
    }

    void Update()
    {
        // uniform speed on all conveyors
        speed = trashManager.trashSpeed;

        // Update the texture offset based on the speed
        textureOffset = new Vector2(previousOffset.x + (Time.time - previousTime) * speed  * (0.00670172f * (float)Math.Pow(speed, 3) - 0.0749536f * (float)Math.Pow(speed, 2) + 0.28797f * speed + 0.450272f), 0);

        // Apply the offset to the material's texture
        material.mainTextureOffset = textureOffset;

        previousTime = Time.time;
        previousOffset = material.mainTextureOffset;
    }
}
