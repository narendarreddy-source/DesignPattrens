using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Iterator
    {
        public void Run()
        {
            List<string> songs = new List<string>
            {
                "Song 1",
                "Song 2",
                "Song 3"
            };
            SongPlayList playList = new SongPlayList(songs);
            IIterator<string> iterator = playList.CreateIterator();
            Console.WriteLine("Songs in the playlist:");
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
    public interface IPalylist<T>
    {
        IIterator<T> CreateIterator();
    }
    public class SongPlayList : IPalylist<string>
    {
        private readonly List<string> _songs;
        public SongPlayList(List<string> songs)
        {
            _songs = songs;
        }
        public IIterator<string> CreateIterator()
        {
            return new SongIterator(_songs);
        }
    }
    
    public class SongIterator : IIterator<string>
    {
        private readonly List<string> _songs;
        private int _currentIndex = 0;
        public SongIterator(List<string> songs)
        {
            _songs = songs;
        }
        public bool HasNext()
        {
            return _currentIndex < _songs.Count;
        }
        public string Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more songs in the playlist.");
            return _songs[_currentIndex++];
        }
    }
}
