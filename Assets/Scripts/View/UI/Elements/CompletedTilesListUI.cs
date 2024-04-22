using UnityEngine;

namespace View.UI.Elements
{
    public class CompletedTilesListUI : MonoBehaviour
    {
        [SerializeField] private CompletedTileTypeInfoUI prefabCompletedTileTypeInfoUI;
        [SerializeField] private GameObject content;

        private void OnEnable()
        {
            var finishedTiles = SceneContext.I.TileService.FinishedTiles;
            foreach (var pair in finishedTiles)
            {
                var instance = Instantiate(prefabCompletedTileTypeInfoUI, content.transform);
                instance.SetLabel($"{pair.Key.ToString()} - {pair.Value.ToString()}");
            }
        }

        private void OnDisable()
        {
            foreach (Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}