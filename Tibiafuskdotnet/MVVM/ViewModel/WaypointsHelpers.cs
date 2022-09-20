using System.Collections.ObjectModel;

namespace Tibiafuskdotnet.MVVM.ViewModel
{
    internal static class WaypointsHelpers
    {
        public static ObservableCollection<Waypoints> DataSource { get; set; }

        public static int waypointx { get; set; }
        public static int waypointy { get; set; }

        public static int waypointz { get; set; }
    }
}