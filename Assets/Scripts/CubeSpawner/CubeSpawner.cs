using Unity.Netcode;
using UnityEngine;

public class CubeSpawner : NetworkBehaviour
{
    [SerializeField] private NetworkObject cubePrefab;
    
    [SerializeField] private float spawnOffset;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!IsServer || !IsHost) return;

        if (!other.CompareTag("Player")) return;
        
        Vector3 spawnPos = transform.position;
        spawnPos.y += spawnOffset;
        
        NetworkManager.Singleton.SpawnManager.InstantiateAndSpawn(cubePrefab, 
            NetworkManager.ServerClientId, 
            false, 
            false, 
            false, 
            spawnPos, 
            Quaternion.identity);
    }
}
