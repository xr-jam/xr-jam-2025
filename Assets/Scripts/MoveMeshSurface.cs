using UnityEngine;

public class MoveSurfaceWithMaterial : MonoBehaviour
{
    public Material material;  // The material of the surface (e.g., conveyor belt)
    public float speed = 0f;   // Speed of surface movement
    private Vector2 textureOffset;
    public TrashManager trashManager;

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
        textureOffset = new Vector2(0, Time.time * (speed / 2) * 0.85f);

        // Apply the offset to the material's texture
        material.mainTextureOffset = textureOffset;
    }
}
