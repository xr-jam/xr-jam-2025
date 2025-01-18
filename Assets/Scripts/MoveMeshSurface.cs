using UnityEngine;

public class MoveSurfaceWithMaterial : MonoBehaviour
{
    public Material material;  // The material of the surface (e.g., conveyor belt)
    public float speed = 1f;   // Speed of surface movement
    private Vector2 textureOffset;

    void Start()
    {
        // Ensure the material is assigned
        if (material == null)
        {
            material = GetComponent<Renderer>().material;
        }
    }

    void Update()
    {
        // Update the texture offset based on the speed
        textureOffset = new Vector2(0, Time.time * speed);

        // Apply the offset to the material's texture
        material.mainTextureOffset = textureOffset;
    }
}
