using BiosmartData.Project.Application.Interfaces;
using BiosmartData.Project.Application.Managers;
using BiosmartData.Project.Application.Strategies;
using BiosmartData.Project.Domain.Entities;

IChatEventManager chatEventManager = new ChatEventManager();


TimeSpan CreateTime(int hour, int minute)
{
    return new TimeSpan(hour, minute, 0);
}


chatEventManager.AddEvent(new EnterRoomEvent(CreateTime(17, 0), "Bob"));
chatEventManager.AddEvent(new EnterRoomEvent(CreateTime(17, 5), "Kate"));
chatEventManager.AddEvent(new CommentEvent(CreateTime(17, 15), "Bob", "Hey, Kate - high five?"));
chatEventManager.AddEvent(new HighFiveEvent(CreateTime(17, 17), "Kate", "Bob"));
chatEventManager.AddEvent(new CommentEvent(CreateTime(17, 20), "Kate", "Oh, typical"));
chatEventManager.AddEvent(new LeaveRoomEvent(CreateTime(17, 21), "Kate"));
chatEventManager.AddEvent(new EnterRoomEvent(CreateTime(18, 0), "Alice"));
chatEventManager.AddEvent(new EnterRoomEvent(CreateTime(18, 5), "Charlie"));
chatEventManager.AddEvent(new HighFiveEvent(CreateTime(18, 15), "Alice", "Charlie"));
chatEventManager.AddEvent(new CommentEvent(CreateTime(18, 20), "Charlie", "Nice to see you!"));
chatEventManager.AddEvent(new LeaveRoomEvent(CreateTime(18, 25), "Alice"));


bool exit = false;
while (!exit)
{
    Console.WriteLine("Bienvenido al Historial de Eventos de Chat");
    Console.WriteLine("Por favor selecciona una opción:");
    Console.WriteLine("1. Ver eventos individuales (minuto a minuto)");
    Console.WriteLine("2. Ver resumen de eventos (por hora)");
    Console.WriteLine("3. Salir");

    Console.Write("Opción: ");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            chatEventManager.DisplayAggregatedEvents(new MinuteByMinuteStrategy());
            break;
        case "2":
            chatEventManager.DisplayAggregatedEvents(new HourlyStrategy());
            break;
        case "3":
            exit = true;
            Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, intenta nuevamente.\n");
            break;
    }
}