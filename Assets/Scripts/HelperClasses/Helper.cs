using UnityEngine;

namespace HelperClasses
{
    public static class Helper
    {
        public static GameObject FindChildWithTag(GameObject parent, string tagName)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.CompareTag(tagName))
                {
                    return child.gameObject;
                }
                if (child.childCount > 0)
                {
                    GameObject found = FindChildWithTag(child.gameObject, tagName);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return null;
        }

        public static void SetLayerRecursively(GameObject go, string layer)
        {
            go.layer = LayerMask.NameToLayer(layer);
            foreach (Transform child in go.transform)
            {
                SetLayerRecursively(child.gameObject, layer);
            }
        }
        
        public static void SetLayerRecursively(GameObject go, string layer, string targetLayer)
        {
            if(LayerMask.LayerToName(go.layer).Equals(targetLayer)) go.layer = LayerMask.NameToLayer(layer);
            foreach (Transform child in go.transform)
            {
                SetLayerRecursively(child.gameObject, layer, targetLayer);
            }
        }
    }
}