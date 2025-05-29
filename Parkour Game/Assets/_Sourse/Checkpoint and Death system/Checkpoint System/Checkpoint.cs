using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private ParticleSystem activationParticles;
    [SerializeField] private AudioClip activationSound;
    
    private bool isActive = false;
    private MeshRenderer meshRenderer;
    private Material defaultMaterial;
    [SerializeField] private Material activeMaterial;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            defaultMaterial = meshRenderer.material;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            CheckpointSystem.Instance.SetCheckpoint(this);
        }
    }
    
    public void Activate()
    {
        isActive = true;
        
        // Визуальные эффекты
        if (meshRenderer != null && activeMaterial != null)
        {
            meshRenderer.material = activeMaterial;
        }
        
        if (activationParticles != null)
        {
            activationParticles.Play();
        }
        
        if (activationSound != null)
        {
            AudioSource.PlayClipAtPoint(activationSound, transform.position);
        }
    }
    
    public void Deactivate()
    {
        isActive = false;
        
        if (meshRenderer != null && defaultMaterial != null)
        {
            meshRenderer.material = defaultMaterial;
        }
    }
    
    public Vector3 GetSpawnPosition()
    {
        return spawnPoint != null ? spawnPoint.position : transform.position;
    }
}