using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExploder _cubeExploder;

    private float _minRandomValue = 0f;
    private float _maxRandomValue = 100f;

    private void OnMouseUpAsButton()
    {
        float chance = UnityEngine.Random.Range(_minRandomValue, _maxRandomValue);

        if (chance <= _cube.Probability)
        {
            _cubeSpawner.SpawnCubes(this.transform.localScale, _cube.Probability, transform.position);
            _cubeExploder.Explode(_cubeSpawner.TransferExplodableObjects(), transform.position);
        }

        Destroy(gameObject);
    }

    public void InitSpawner(CubeSpawner cubeSpawner)
    {
        _cubeSpawner = cubeSpawner;
    }

    public void InitExploder(CubeExploder cubeExploder)
    {
        _cubeExploder = cubeExploder;
    }
}
