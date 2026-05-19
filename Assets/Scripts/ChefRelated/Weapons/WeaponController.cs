using UnityEngine;

public class WeaponController: MonoBehaviour
{
    private GameObject spawnPoint;
    [SerializeField] private float weaponOffSetX;
    [SerializeField] private float weaponOffSetY;

    private Vector3 newVector;
    private void Start()
    {
        spawnPoint = GameObject.Find("SpawnWeaponPoint");
    }
    private void Update()
    {
        float direccionX = Mathf.Sign(spawnPoint.transform.localScale.x);

        newVector = new Vector3((spawnPoint.transform.position.x + weaponOffSetX) * direccionX, spawnPoint.transform.position.y + weaponOffSetY, spawnPoint.transform.position.z);
        gameObject.transform.position = newVector;
    }
}
