using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundleLoaderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadAssetBundle();
    }

    AssetBundle myLoadedAssetBundle;
    // Update is called once per frame
    void LoadAssetBundle()
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop); 

         myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(desktopPath, "model.apple"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
    }

    public void CreateObjectFromAssetBundle(string fileName, Transform _parent)
    {
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(fileName);
        GameObject newObject = Instantiate(prefab, _parent);
		newObject.transform.localScale = new Vector3 (0.04f, 0.04f, 0.04f);
    }
}
