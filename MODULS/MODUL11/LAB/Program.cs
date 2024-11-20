using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL10.LAB
{
    public class AudioSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Аудиосистема включена.");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine($"Громкость звука установлена на {level}.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Аудиосистема выключена.");
        }
    }

    public class VideoProjector
    {
        public void TurnOn()
        {
            Console.WriteLine("Видеопроектор включен.");
        }

        public void SetResolution(string resolution)
        {
            Console.WriteLine($"Разрешение видео установлено на {resolution}.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Видеопроектор выключен.");
        }
    }

    public class LightingSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Свет включен.");
        }

        public void SetBrightness(int level)
        {
            Console.WriteLine($"Яркость подсветки установлена на {level}.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Свет выключен.");
        }
    }

    public class HomeTheaterFacade
    {
        private AudioSystem _audioSystem;
        private VideoProjector _videoProjector;
        private LightingSystem _lightingSystem;

        public HomeTheaterFacade(AudioSystem audioSystem, VideoProjector videoProjector, LightingSystem lightingSystem)
        {
            _audioSystem = audioSystem;
            _videoProjector = videoProjector;
            _lightingSystem = lightingSystem;
        }

        public void StartMovie()
        {
            Console.WriteLine("Подготовка к запуску фильма...");
            _lightingSystem.TurnOn();
            _lightingSystem.SetBrightness(5);
            _audioSystem.TurnOn();
            _audioSystem.SetVolume(8);
            _videoProjector.TurnOn();
            _videoProjector.SetResolution("HD");
            Console.WriteLine("Начался фильм.");
        }

        public void EndMovie()
        {
            Console.WriteLine("Выключение фильма...");
            _videoProjector.TurnOff();
            _audioSystem.TurnOff();
            _lightingSystem.TurnOff();
            Console.WriteLine("Фильм закончился.");
        }
    }

    internal class Program
    {
        /*static void Main(string[] args)
        {
            AudioSystem audio = new AudioSystem();
            VideoProjector video = new VideoProjector();
            LightingSystem lights = new LightingSystem();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(audio, video, lights);

            homeTheater.StartMovie();

            Console.WriteLine();

            homeTheater.EndMovie();
        }*/

    }
}
