using Godot;

namespace WinterGame.Scripts.Helpers
{
    public class BlockCollision
    {
        private CollisionShape2D _col;
		private Vector2 _originalSize;

		public BlockCollision(CollisionShape2D col)
		{
			_col = col;
			_originalSize = ((RectangleShape2D)_col.Shape).Size;
			_col.Shape = new RectangleShape2D();
			((RectangleShape2D)_col.Shape).Size = _originalSize;
		}

		public void onMoving()
		{
			((RectangleShape2D)_col.Shape).Size = _originalSize - new Vector2(1f, 1f);
		}
		public void onStoped()
		{
			((RectangleShape2D)_col.Shape).Size = _originalSize;
		}
	}
}