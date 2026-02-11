namespace MMLAP.Models
{
    public class LevelData
    {
        public string AreaName { get; set; }
        public string RoomName { get; set; }
        public byte AreaCode { get; set; }
        public byte RoomCode { get; set; }
        // Maybe a graph class is in order
        // public List<LevelData> ConnectedLevels { get; set; } = new List<LevelData>();

        public LevelData(
            string areaName,
            string roomName,
            byte areaCode,
            byte roomCode
            // , List<LevelData>? connectedLevels = null
        )
        {
            AreaName = areaName;
            RoomName = roomName;
            AreaCode = areaCode;
            RoomCode = roomCode;
            // ConnectedLevels = connectedLevels;
        }
    }
}
