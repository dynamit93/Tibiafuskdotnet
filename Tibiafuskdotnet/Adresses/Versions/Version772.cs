﻿using System;
using System.Diagnostics;
using Tibiafuskdotnet;
using Tibiafuskdotnet.BL;
using Tibia.Addresses;

namespace Tibia
{
    public partial class Version
    {
        public static void SetVersion772()
        {
            BattleList.Start = 0X5C68B4;
            BattleList.StepCreatures = 0xA8;
            BattleList.MaxCreatures = 147;
            BattleList.End = BattleList.Start + (BattleList.StepCreatures * BattleList.MaxCreatures);




            Client.StartTime = 0x7E0790;
            Client.XTeaKey = 0x7998BC;
            Client.SocketStruct = 0x799890;
            Client.RecvPointer = 0x5B85E4;
            Client.SendPointer = 0x5B8610;
            Client.FrameRatePointer = 0x79DA74;
            Client.FrameRateCurrentOffset = 0x60;
            Client.FrameRateLimitOffset = 0x58;
            Client.MultiClient = 0x50BCA4;
            Client.Status = 0x71C588; //klar för 7.72
            Client.SafeMode = 0x719E84; // klar 7.72
            Client.FollowMode = Client.SafeMode + 4;
            Client.AttackMode = Client.FollowMode + 4;
            Client.ActionState = 0x71C300; //klar för 7.72
            Client.ActionStateFreezer = 0x71C5E8; //crpsshair? klar för 7.72
            Client.LastMSGText = 0x71DE30; //klar för 7.72
            Client.LastMSGAuthor = Client.LastMSGText - 0x28;
            Client.StatusbarText = 0x7E0A00;//klar för 7.72
            Client.StatusbarTime = Client.StatusbarText - 4;
            Client.ClickId = 0x31C63C;//klar för 7.72
            Client.ClickCount = Client.ClickId + 4;
            Client.ClickZ = Client.ClickId - 0x68;
            Client.SeeId = Client.ClickId + 12;
            Client.SeeCount = Client.SeeId + 4;
            Client.SeeZ = Client.SeeId - 0x68;
            Client.ClickContextMenuItemId = 0x79CFD4;
            Client.ClickContextMenuCreatureId = 0x79CFD8;
            Client.LoginServerStart = 0x7947F8;
            Client.StepLoginServer = 112;
            Client.DistancePort = 100;
            Client.MaxLoginServers = 10;
            Client.RSA = 0x5B8980;
            Client.LoginCharList = 0x79CEDC;
            Client.LoginCharListLength = 0x79CEE0;
            Client.LoginSelectedChar = 0x79CED8;
            Client.GameWindowRectPointer = 0x64C25C;
            Client.GameWindowBar = 0x7E07A4;
            Client.DatPointer = 0x7998DC;
            Client.EventTriggerPointer = 0x51F650;
            Client.DialogPointer = 0x64F5C4;
            Client.DialogLeft = 0x14;
            Client.DialogTop = 0x18;
            Client.DialogWidth = 0x1C;
            Client.DialogHeight = 0x20;
            Client.DialogCaption = 0x50;
            Client.LastRcvPacket = 0x795070;
            Client.DecryptCall = 0x45C3A5;
            Client.LoginAccountNum = 0;
            Client.LoginPassword = 0x79CEE4;
            Client.LoginAccount = Client.LoginPassword + 32;
            Client.LoginPatch = 0;
            Client.LoginPatch2 = 0;
            Client.LoginPatchOrig = new byte[] { 0xE8, 0x0D, 0x1D, 0x09, 0x00 };
            Client.LoginPatchOrig2 = new byte[] { 0xE8, 0xC8, 0x15, 0x09, 0x00 };
            Client.ParserFunc = 0x45C370;
            Client.GetNextPacketCall = 0x45C3A5;
            Client.RecvStream = 0x7998AC;

            Container.Start = 0x5CEE14;
            Container.StepContainer = 492;
            Container.StepSlot = 12;
            Container.MaxContainers = 16;
            Container.MaxStack = 100;
            Container.DistanceIsOpen = 0;
            Container.DistanceId = 4;
            Container.DistanceName = 16;
            Container.DistanceVolume = 48;
            Container.DistanceAmount = 56;
            Container.DistanceItemId = 60;
            Container.DistanceItemCount = 64;
            Container.End = Container.Start + (Container.MaxContainers * Container.StepContainer);

            ContextMenus.AddContextMenuPtr = 0x452320;
            ContextMenus.OnClickContextMenuPtr = 0x44E960;
            ContextMenus.OnClickContextMenuVf = 0x5BD9C0;
            ContextMenus.AddSetOutfitContextMenu = 0x453283;
            ContextMenus.AddPartyActionContextMenu = 0x4536AC;
            ContextMenus.AddCopyNameContextMenu = 0x453790;
            ContextMenus.AddTradeWithContextMenu = 0x452EC9;
            ContextMenus.AddLookContextMenu = 0x452D7F;


            Creature.DistanceId = 0;
            Creature.DistanceType = 3;
            Creature.DistanceName = 4;
            Creature.DistanceX = 36;
            Creature.DistanceY = 40;
            Creature.DistanceZ = 44;
            Creature.DistanceScreenOffsetHoriz = 48;
            Creature.DistanceScreenOffsetVert = 52;
            Creature.DistanceIsWalking = 76;
            Creature.DistanceWalkSpeed = 140;
            Creature.DistanceDirection = 80;

            Creature.DistanceIsVisible = 144;

            Creature.DistanceBlackSquare = 132;
            Creature.DistanceLight = 120;
            Creature.DistanceLightColor = 124;
            Creature.DistanceHPBar = 136;
            Creature.DistanceSkull = 148;
            Creature.DistanceParty = 152;
            Creature.DistanceWarIcon = 160;
            Creature.DistanceIsBlocking = 164;
            Creature.DistanceOutfit = 96;
            Creature.DistanceColorHead = 100;
            Creature.DistanceColorBody = 104;
            Creature.DistanceColorLegs = 108;
            Creature.DistanceColorFeet = 112;
            Creature.DistanceAddon = 116;

            DatItem.StepItems = 0x4C;
            DatItem.Width = 0;
            DatItem.Height = 4;
            DatItem.MaxSizeInPixels = 8;
            DatItem.Layers = 12;
            DatItem.PatternX = 16;
            DatItem.PatternY = 20;
            DatItem.PatternDepth = 24;
            DatItem.Phase = 28;
            DatItem.Sprite = 32;
            DatItem.Flags = 36;
            DatItem.CanLookAt = 0;
            DatItem.WalkSpeed = 40;
            DatItem.TextLimit = 44;
            DatItem.LightRadius = 48;
            DatItem.LightColor = 52;
            DatItem.ShiftX = 56;
            DatItem.ShiftY = 60;
            DatItem.WalkHeight = 64;
            DatItem.Automap = 68;
            DatItem.LensHelp = 72;

            DrawItem.DrawItemFunc = 0x4B5990;
            DrawSkin.DrawSkinFunc = 0x4B96E0;

            Hotkey.SendAutomaticallyStart = 0x799EE0;
            Hotkey.SendAutomaticallyStep = 0x01;
            Hotkey.TextStart = 0x799F08;
            Hotkey.TextStep = 0x100;
            Hotkey.ObjectStart = 0x799E50;
            Hotkey.ObjectStep = 0x04;
            Hotkey.ObjectUseTypeStart = 0x799D30;
            Hotkey.ObjectUseTypeStep = 0x04;
            Hotkey.MaxHotkeys = 36;



            Map.MapPointer = 0x654118;
            Map.StepTile = 168;
            Map.StepTileObject = 12;
            Map.DistanceTileObjectCount = 0;
            Map.DistanceTileObjects = 4;
            Map.DistanceObjectId = 0;
            Map.DistanceObjectData = 4;
            Map.DistanceObjectDataEx = 8;
            Map.MaxTileObjects = 10;
            Map.MaxX = 18;
            Map.MaxY = 14;
            Map.MaxZ = 8;
            Map.MaxTiles = 2016;
            Map.ZAxisDefault = 7;
            Map.NameSpy1 = 0x4F2809;
            Map.NameSpy2 = 0x4F2813;
            Map.NameSpy1Default = 19061;
            Map.NameSpy2Default = 16501;
            Map.LevelSpy1 = 0x4F46BA;
            Map.LevelSpy2 = 0x4F47BF;
            Map.LevelSpy3 = 0x4F4840;
            Map.LevelSpyPtr = 0x64C25C;
            Map.LevelSpyAdd1 = 28;
            Map.LevelSpyAdd2 = 0x2A88;
            Map.LevelSpyDefault = new byte[] { 0x89, 0x86, 0x88, 0x2A, 0x00, 0x00 };
            Map.FullLightNop = 0x4EAFA9;
            Map.FullLightAdr = 0x4EAFAC;
            Map.FullLightNopDefault = new byte[] { 0x7E, 0x05 };
            Map.FullLightNopEdited = new byte[] { 0x90, 0x90 };
            Map.FullLightAdrDefault = 0x80;
            Map.FullLightAdrEdited = 0xFF;


            Player.Experience = 0x5C6840; // exp är klar för 7.4
            Player.Flags = Player.Experience - 108;
            Player.Id = Player.Experience + 12;
            Player.Health = Player.Experience + 8;
            Player.HealthMax = Player.Experience + 4;
            Player.Level = Player.Experience - 4;
            Player.MagicLevel = Player.Experience - 8;
            Player.LevelPercent = Player.Experience - 12;
            Player.MagicLevelPercent = Player.Experience - 16;
            Player.Mana = Player.Experience - 20;
            Player.ManaMax = Player.Experience - 24;
            Player.Soul = Player.Experience - 28;
            Player.Stamina = Player.Experience - 32;
            Player.Capacity = Player.Experience - 36;
            Player.FistPercent = 0x5C67DC; //FistProcent är klar för 7.72
            Player.ClubPercent = Player.FistPercent + 4;
            Player.SwordPercent = Player.FistPercent + 8;
            Player.AxePercent = Player.FistPercent + 12;
            Player.DistancePercent = Player.FistPercent + 16;
            Player.ShieldingPercent = Player.FistPercent + 20;
            Player.FishingPercent = Player.FistPercent + 24;
            Player.Fist = Player.FistPercent + 28;
            Player.Club = Player.FistPercent + 32;
            Player.Sword = Player.FistPercent + 36;
            Player.Axe = Player.FistPercent + 40;
            Player.Distance = Player.FistPercent + 44;
            Player.Shielding = Player.FistPercent + 48;
            Player.Fishing = Player.FistPercent + 52;
            Player.SlotHead = 0x05CED60; /// head är klar för 7.4
            Player.SlotNeck = Player.SlotHead + 12;
            Player.SlotBackpack = Player.SlotHead + 24;
            Player.SlotArmor = Player.SlotHead + 36;
            Player.SlotRight = Player.SlotHead + 48;
            Player.SlotLeft = Player.SlotHead + 60;
            Player.SlotLegs = Player.SlotHead + 72;
            Player.SlotFeet = Player.SlotHead + 84;
            Player.SlotRing = Player.SlotHead + 96;
            Player.SlotAmmo = Player.SlotHead + 108;
            Player.MaxSlots = 10;
            Player.DistanceSlotCount = 4;
            Player.CurrentTileToGo = 0x63FEA0;
            Player.TilesToGo = 0x63FEA4;
            Player.GoToX = Player.Experience + 80;
            Player.GoToY = Player.GoToX - 4;
            Player.GoToZ = Player.GoToX - 8;
            Player.RedSquare = 0X5C681C; // klar för 7.72
            Player.GreenSquare = Player.RedSquare - 4;
            Player.WhiteSquare = Player.GreenSquare - 8;
            Player.AccessN = 0;
            Player.AccessS = 0;
            Player.TargetId = Player.RedSquare;
            Player.TargetBattlelistId = Player.TargetId - 8;
            Player.TargetBattlelistType = Player.TargetId - 5;
            Player.TargetType = Player.TargetId + 3;
            Player.X = Player.Z + 8;
            Player.Y = Player.Z + 4;
            Player.Z = 0x5776E0;
            Player.AttackCount = 0X5C67DC; //ökar med 5.5
            Player.FollowCount = Player.AttackCount + 0x20;

            TextDisplay.PrintName = 0x4F5823;
            TextDisplay.PrintFPS = 0x45A258;
            TextDisplay.ShowFPS = 0x63DB3C;
            TextDisplay.PrintTextFunc = 0x4B4DD0;
            TextDisplay.NopFPS = 0x45A194;

            Vip.Start = 0x63DBB8;
            Vip.StepPlayers = 0x2C;
            Vip.MaxPlayers = 200;
            Vip.DistanceId = 0;
            Vip.DistanceName = 4;
            Vip.DistanceStatus = 34;
            Vip.DistanceIcon = 40;
            Vip.End = Vip.Start + (Vip.StepPlayers * Vip.MaxPlayers);

        }
    }
}
