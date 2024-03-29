namespace Tibia.Addresses
{
    /// <summary>
    /// Map memory addresses.
    /// </summary>
    public static class Map
    {
        /// <summary>
        /// Pointer to the start of the map memory addresses.
        /// </summary>
        public static uint MapPointer = 0x676F40; // 8.62

        /// <summary>
        /// Step between tiles on the map.
        /// </summary>
        public static uint StepTile = 168;

        /// <summary>
        /// Step between objects on a tile.
        /// The first object is the gound, subsequent objects are any nonmoveable items (trees),
        /// creatures (players), or items in that tile.
        /// </summary>
        public static uint StepTileObject = 12;

        /// <summary>
        /// Distance from the tile to the number of objects on the square.
        /// </summary>
        public static uint DistanceTileObjectCount = 0;

        /// <summary>
        /// Distance to the first object on a tile.
        /// </summary>
        public static uint DistanceTileObjects = 4;

        /// <summary>
        /// Distance to the id of the object that is on a tile.
        /// </summary>
        public static uint DistanceObjectId = 0;
        /// <summary>
        /// Distance to the data of the object that is on a tile.
        /// </summary>
        public static uint DistanceObjectData = 4;
        /// <summary>
        /// Distance to the ExData (extra data) of the object that is on a tile.
        /// </summary>
        public static uint DistanceObjectDataEx = 8;

        /// <summary>
        /// Maximum number of objects per tile.
        /// </summary>
        public static uint MaxTileObjects = 10;

        /// <summary>
        /// Maximum number of tiles in the X direction
        /// </summary>
        public static uint MaxX = 18;

        /// <summary>
        /// Maximum number of tiles in the Y direction
        /// </summary>
        public static uint MaxY = 14;

        /// <summary>
        /// Maximum number of tiles in the Z direction
        /// </summary>
        public static uint MaxZ = 8;

        /// <summary>
        /// Maximum number of tiles.
        /// </summary>
        public static uint MaxTiles = 2016; // MaxX * MaxY * MaxZ

        /// <summary>
        /// The default (starting) Z axis value
        /// </summary>
        public static uint ZAxisDefault = 7; // default ground level

        /// <summary>
        /// Memory address for player tile
        /// </summary>
        public static uint PlayerTile = 0; // 8.1, Doesn't appear to exist in 8.21

        /// <summary>
        /// Nop Value, to use with namespy and levelspy
        /// </summary>
        public static byte[] Nops = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

        /// <summary>
        /// NameSpy address 1.
        /// </summary>
        public static uint NameSpy1 = 0x4EE519; // 8.62


        /// <summary>
        /// NameSpy address 2.
        /// </summary>
        public static uint NameSpy2 = 0x4EE523;  // 8.62


        /// <summary>
        /// Default value for Namespy1.
        /// </summary>
        public static uint NameSpy1Default = 0x4C75;
        /// <summary>
        /// Default value for Namespy2.
        /// </summary>
        public static uint NameSpy2Default = 0x4275;

        /// <summary>
        /// Level spy address 1.
        /// </summary>
        public static uint LevelSpy1 = 0x4F038A;  // 8.62


        /// <summary>
        /// Level spy address 2.
        /// </summary>
        public static uint LevelSpy2 = 0x4F048F;  // 8.62


        /// <summary>
        /// Level spy address 3.
        /// </summary>
        public static uint LevelSpy3 = 0x4F0510;  // 8.62


        /// <summary>
        /// Level spy pointer.
        /// </summary>
        public static uint LevelSpyPtr = 0x66F080;  // 8.62

        /// <summary>
        /// Defaults for level spy.
        /// </summary>
        public static byte[] LevelSpyDefault = { 0x89, 0x86, 0xC0, 0x5B, 0x00, 0x00 };
        /// <summary>
        /// Level spy add 1.
        /// </summary>
        public static byte LevelSpyAdd1 = 28;
        /// <summary>
        /// Level spy add 2.
        /// </summary>
        public static uint LevelSpyAdd2 = 0x5BC0;

        /// <summary>
        /// Write to this byte to reveal invisible creatures.
        /// Thanks to Stiju @ http://www.tpforums.org/forum/showthread.php?t=1141
        /// </summary>
        public static uint RevealInvisible1 = 0x45F7A3;  // 8.52
        public static byte RevealInvisible1Default = 0x72;
        public static byte RevealInvisible1Edited = 0xEB;

        public static uint RevealInvisible2 = 0x4EC595;  // 8.52
        public static byte RevealInvisible2Default = 0x75;
        public static byte RevealInvisible2Edited = 0xEB;

        /// <summary>
        /// Global light, all floors, used for improving levelspy
        /// </summary>
        public static uint FullLightNop = 0x4E6C29;  // 8.62
        public static byte[] FullLightNopDefault = { 0x7E, 0x05 };
        public static byte[] FullLightNopEdited = { 0x90, 0x90 };

        public static uint FullLightAdr = 0x4E6C2C;  // 8.62
        public static byte FullLightAdrDefault = 0x80;
        public static byte FullLightAdrEdited = 0xFF;
    }
}
