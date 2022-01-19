﻿using Tibia.Constants;

namespace Tibia.Packets.Incoming
{
    public class MagicEffectPacket : IncomingPacket
    {
        public Objects.Location Position { get; set; }
        public byte Effect { get; set; }

        public MagicEffectPacket(Objects.Client c)
            : base(c)
        {
            Type = IncomingPacketType.MagicEffect;
            Destination = PacketDestination.Client;
        }

        public override bool ParseMessage(NetworkMessage msg, PacketDestination destination)
        {
            int position = msg.Position;

            if (msg.GetByte() != (byte)IncomingPacketType.MagicEffect)
                return false;

            Destination = destination;
            Type = IncomingPacketType.MagicEffect;

            Position = msg.GetLocation();
            Effect = msg.GetByte();

            return true;
        }

        public override void ToNetworkMessage(NetworkMessage msg)
        {
            msg.AddByte((byte)Type);
            msg.AddLocation(Position);
            msg.AddByte(Effect);
        }
    }
}