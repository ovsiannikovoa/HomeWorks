namespace Task13_02
{
    public delegate void DeviceStateChangedHandler(string deviceType, string newState, DateTime time);

    public class SmartHomeSystem
    {
        private bool _isLightOn;
        private int _currentTemperature;
        private bool _isDoorLocked;

        public event DeviceStateChangedHandler DeviceStateChanged;

        public SmartHomeSystem()
        {
            _isLightOn = false;
            _currentTemperature = 20;
            _isDoorLocked = true;
        }

        public void TurnOnLight()
        {
            if (!_isLightOn)
            {
                _isLightOn = true;
                DeviceStateChanged?.Invoke("Light", "Включен", DateTime.Now);
            }
        }

        public void TurnOffLight()
        {
            if (_isLightOn)
            {
                _isLightOn = false;
                DeviceStateChanged?.Invoke("Light", "Выключен", DateTime.Now);
            }
        }

        public void SetTemperature(int newTemp)
        {
            if (newTemp != _currentTemperature)
            {
                _currentTemperature = newTemp;
                DeviceStateChanged?.Invoke("Thermostat", $"Температура изменена на {newTemp}°C", DateTime.Now);
            }
        }

        public void LockDoor()
        {
            if (!_isDoorLocked)
            {
                _isDoorLocked = true;
                DeviceStateChanged?.Invoke("Door", "Заблокирована", DateTime.Now);
            }
        }

        public void UnlockDoor()
        {
            if (_isDoorLocked)
            {
                _isDoorLocked = false;
                DeviceStateChanged?.Invoke("Door", "Разблокирована", DateTime.Now);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 13. Задание 2.

            // Реализуйте систему управления умным домом на C# с использованием событий.
            // Система должна отслеживать изменения состояния устройств и уведомлять пользователя о важных событиях.
            // 1.Класс SmartHomeSystem
            // Должен содержать:
            //  Список подключенных устройств(например, свет, термостат, дверные датчики)
            //  Методы для управления устройствами:
            //      TurnOnLight() / TurnOffLight()
            //      SetTemperature(int newTemp)
            //      LockDoor() / UnlockDoor()
            //  Событие DeviceStateChanged, срабатывающее при изменении состояния любого устройства.
            // 2.Событие DeviceStateChanged
            // Должно передавать:
            //  Тип устройства("Light", "Thermostat", "Door")
            //  Новое состояние(например, "On", "Off", "Locked", "Temperature set to 25°C")
            //  Время изменения.
            // 3.Подписка на события в Main
            //Пример лога при работе программы:
            //[14:30:00] Light: Включен
            //[14:31:15] Thermostat: Температура изменена на 23°C
            //[14:35:40] Door: Заблокирована

            var smartHome = new SmartHomeSystem();

            smartHome.DeviceStateChanged += (deviceType, newState, time) =>
            {
                Console.WriteLine($"[{time:HH:mm:ss}] {deviceType}: {newState}");
            };

            smartHome.TurnOnLight();
            smartHome.SetTemperature(23);
            smartHome.LockDoor();
            smartHome.UnlockDoor();
            smartHome.TurnOffLight();
            smartHome.SetTemperature(25);

            Console.ReadKey();
        }
    }
}
