namespace Payments;

public class Events
{

    public static void Main2(string[] args)
    {
        var room = new Room(3);
        room.RoomSoldOutEvent += OnRoomSoldOut;
        room.ReserveSeats();
        room.ReserveSeats();
        room.ReserveSeats();
        room.ReserveSeats();
    }

    static void OnRoomSoldOut(object sender, EventArgs e)
    {
        Console.WriteLine("Sala lotada.");
    }
}

public class Room
{
    public int Seats { get; set; }
    private int seatsInUse = 0;

    public Room(int seats)
    {
        Seats = seats;
        seatsInUse = 0;
    }

    public void ReserveSeats()
    {
        if (seatsInUse >= Seats)
        {
            OnRoomSoldOut(EventArgs.Empty);
        }
        else
        {
            seatsInUse++;
            Console.WriteLine("Assento reservado.");
        }
    }

    public event EventHandler RoomSoldOutEvent;

    protected virtual void OnRoomSoldOut(EventArgs e)
    {
        EventHandler handler = RoomSoldOutEvent;
        handler?.Invoke(this, e);
    }
}