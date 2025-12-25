using Godot;
using WinterGame.Scripts.Models.Blocks;

namespace WinterGame.Scripts.Helpers
{
    public class BlockRestarter
    {
        private Block _block;
		private Vector2 _initialPosition;

		public BlockRestarter(Block block)
		{
			_block = block;
			_initialPosition = _block.Position;
		}

		public void Restart()
		{
			_block.Speed = Vector2.Zero;
			_block.Position = _initialPosition;
		}
	}
}