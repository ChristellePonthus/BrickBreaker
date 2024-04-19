using Microsoft.Xna.Framework.Input;

namespace BrickBreaker
{
    public interface IInputs
    {
        bool IsJustPressed(Keys key);
        bool IsPressed(Keys key);
    }
    public sealed class Inputs : IInputs
    {
        private KeyboardState _oldKeybordState;

        public Inputs()
        {
            ServiceLocator.Register<IInputs>(this);
        }
        public void UpdateKeyboardState()
        {
            _oldKeybordState = Keyboard.GetState();
        }

        public bool IsJustPressed(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && _oldKeybordState.IsKeyUp(key);
        }

        public bool IsPressed(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
