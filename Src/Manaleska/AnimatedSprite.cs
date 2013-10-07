#region

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace Manaleska
{
    public class AnimatedSprite
    {
        private readonly int _totalFrames;
        private int _currentFrame;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            _currentFrame = 0;
            _totalFrames = Rows*Columns;
        }

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public void Update()
        {
            _currentFrame++;
            if (_currentFrame == _totalFrames)
                _currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            var width = Texture.Width/Columns;
            var height = Texture.Height/Rows;
            var row = (int) (_currentFrame/(float) Columns);
            var column = _currentFrame%Columns;

            var sourceRectangle = new Rectangle(width*column, height*row, width, height);
            var destinationRectangle = new Rectangle((int) location.X, (int) location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}