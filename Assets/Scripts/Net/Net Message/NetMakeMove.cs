
using Unity.Networking.Transport;

public class NetMakeMove : NetMessage
{

    public int initialX;
    public int initialY;
    public int destinationX;
    public int destinationY;
    public int turnPlayer;

    public NetMakeMove()
    {
        Code = OpCode.MAKE_MOVE;
    }

    public NetMakeMove(DataStreamReader reader)
    {
        Code = OpCode.MAKE_MOVE;
        Deserialize(reader);
    }

    public override void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteByte((byte)Code);
        writer.WriteInt(initialX);
        writer.WriteInt(initialY);
        writer.WriteInt(destinationX);
        writer.WriteInt(destinationY);
        writer.WriteInt(turnPlayer);
    }

    public override void Deserialize(DataStreamReader reader)
    {
        initialX = reader.ReadInt();
        initialY = reader.ReadInt();
        destinationX = reader.ReadInt();
        destinationY = reader.ReadInt();
        turnPlayer = reader.ReadInt();
    }

    public override void ReceivedOnClient()
    {
        NetUtility.C_MAKE_MOVE?.Invoke(this);
    }

    public override void ReceivedOnServer(NetworkConnection cnn)
    {
        NetUtility.S_MAKE_MOVE?.Invoke(this, cnn);
    }
}
