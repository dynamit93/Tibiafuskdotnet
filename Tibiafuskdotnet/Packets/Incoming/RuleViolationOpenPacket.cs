﻿using System;
using Tibia.Constants;

namespace Tibia.Packets.Incoming
{
    public class RuleViolationOpenPacket : IncomingPacket
    {
        public ushort ChannelId { get; set; }

        public RuleViolationOpenPacket(Objects.Client c)
            : base(c)
        {
            Type = IncomingPacketType.RuleViolationOpen;
            Destination = PacketDestination.Client;
        }

        public override bool ParseMessage(NetworkMessage msg, PacketDestination destination)
        {
            int position = msg.Position;

            if (msg.GetByte() != (byte)IncomingPacketType.RuleViolationOpen)
                throw new Exception();

            Destination = destination;
            Type = IncomingPacketType.RuleViolationOpen;

            ChannelId = msg.GetUInt16();

            return true;
        }

        public override void ToNetworkMessage(NetworkMessage msg)
        {
            msg.AddByte((byte)Type);
            msg.AddUInt16(ChannelId);
        }
    }
}