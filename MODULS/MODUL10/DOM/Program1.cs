using MODULS.MODUL08.PRAC;
using MODULS.MODUL10.LAB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL10.DOM
{
    public class TV
    {
        public void TurnOn()
        {
            Console.WriteLine("Телевизор включен.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Телевизор выключен.");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"Телевизор переключен на канал {channel}.");
        }
    }

    public class AudioSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Аудиосистема включена.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Аудиосистема выключена.");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Громкость установлена на уровне {volume}.");
        }
    }

    public class DVDPlayer
    {
        public void Play()
        {
            Console.WriteLine("DVD-проигрыватель воспроизводит диск.");
        }

        public void Pause()
        {
            Console.WriteLine("DVD-проигрыватель на паузе.");
        }

        public void Stop()
        {
            Console.WriteLine("DVD-проигрыватель остановлен.");
        }
    }

    public class GameConsole
    {
        public void TurnOn()
        {
            Console.WriteLine("Игровая консоль включена.");
        }

        public void StartGame(string game)
        {
            Console.WriteLine($"Запущена игра: {game}.");
        }
    }

    public class HomeTheaterFacade
    {
        private TV _tv;
        private AudioSystem _audio;
        private DVDPlayer _dvdPlayer;
        private GameConsole _gameConsole;

        public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvdPlayer, GameConsole gameConsole)
        {
            _tv = tv;
            _audio = audio;
            _dvdPlayer = dvdPlayer;
            _gameConsole = gameConsole;
        }

        public void WatchMovie()
        {
            Console.WriteLine("Подготовка к просмотру фильма...");
            _tv.TurnOn();
            _audio.TurnOn();
            _audio.SetVolume(10);
            _dvdPlayer.Play();
            Console.WriteLine("Фильм начался!");
        }

        public void EndMovie()
        {
            Console.WriteLine("Отключение системы после фильма...");
            _dvdPlayer.Stop();
            _audio.TurnOff();
            _tv.TurnOff();
            Console.WriteLine("Система выключена.");
        }

        public void PlayGame(string game)
        {
            Console.WriteLine("Подготовка к запуску игровой консоли...");
            _tv.TurnOn();
            _audio.TurnOn();
            _audio.SetVolume(15);
            _gameConsole.TurnOn();
            _gameConsole.StartGame(game);
            Console.WriteLine("Приятной игры!");
        }

        public void ListenToMusic()
        {
            Console.WriteLine("Подготовка к прослушиванию музыки...");
            _tv.TurnOn();
            _audio.TurnOn();
            _audio.SetVolume(20);
            Console.WriteLine("Музыка воспроизводится!");
        }

        public void SetVolume(int volume)
        {
            _audio.SetVolume(volume);
            Console.WriteLine($"Громкость установлена на уровне {volume}.");
        }
    }
    internal class Program1
    {
        /*static void Main(string[] args)
        {
            TV tv = new TV();
            AudioSystem audio = new AudioSystem();
            DVDPlayer dvdPlayer = new DVDPlayer();
            GameConsole gameConsole = new GameConsole();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, dvdPlayer, gameConsole);

            homeTheater.WatchMovie();
            homeTheater.SetVolume(12);
            homeTheater.EndMovie();

            Console.WriteLine();

            homeTheater.PlayGame("Cyber Adventure");

            Console.WriteLine();

            homeTheater.ListenToMusic();
            homeTheater.SetVolume(15);
        }*/
    }
}
