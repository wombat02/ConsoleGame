using System;
namespace ConsoleSurfer
{
    public class Renderable
    {
        public int renderLayer;
        public Vector2 position;
        public string[] model;

        public bool centerPosition;

        public Renderable(Vector2 pos, string[] _model, bool _centerPosition = true)
        {
            position = pos;
            model = _model;
            centerPosition = _centerPosition;
        }
    }
}
