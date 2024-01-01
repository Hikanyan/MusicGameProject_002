namespace RhythmGameProject.Scripts.UI.LoadingScene
{
    public interface ILoadSceneView
    {
        void ShowLoading(bool show);
        void UpdateProgress(float progress);
    }
}