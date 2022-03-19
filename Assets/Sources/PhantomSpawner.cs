using UnityEngine;

public class PhantomSpawner : MonoBehaviour
{
    [SerializeField] private float _phantomTransparency = .5f;



    public GameObject SpawnPhantom(GameObject model)
    {
        var phantom = Instantiate(model, model.transform.position, Quaternion.identity);
        var material = phantom.GetComponent<Renderer>().material;
        material.SetTransparentMode();
        material.SetTransparency(_phantomTransparency);

        return phantom;
    }
}
