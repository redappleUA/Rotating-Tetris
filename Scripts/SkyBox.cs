using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    [SerializeField] List<Material> materials = new();
    void Start() => RenderSettings.skybox = materials[Random.Range(0, materials.Count)];
}
