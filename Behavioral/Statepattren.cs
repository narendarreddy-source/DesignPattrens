using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Statepattren
    {
        public void run() {
            var player = new Player(new PausedState());
                player.Play(); // Output: Resuming the player.
                player.Play(); // Output: Already playing.
                player.Pause(); // Output: Pausing the player.
                player.Pause(); // Output: Already paused.
        }
    }
    public class Player
    {
        private IPlayerState _state;
        public Player(IPlayerState state)
        {
            _state = state;
        }
        public void SetState(IPlayerState state)
        {
            _state = state;
        }
        public void Play()
        {
            _state.Play(this);
        }
        public void Pause()
        {
            _state.Pause(this);
        }
    }

    public interface IPlayerState
    {
        void Play(Player player);
        void Pause(Player player);
    }

    public class PlayingState : IPlayerState
    {
        public void Play(Player player)
        {
            Console.WriteLine("Already playing.");
        }
        public void Pause(Player player)
        {
            Console.WriteLine("Pausing the player.");
            player.SetState(new PausedState());
        }
    }

    public class PausedState : IPlayerState
    {
        public void Play(Player player)
        {
            Console.WriteLine("Resuming the player.");
            player.SetState(new PlayingState());
        }
        public void Pause(Player player)
        {
            Console.WriteLine("Already paused.");
        }
    }
}
