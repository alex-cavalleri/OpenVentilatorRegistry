using System.Collections.ObjectModel;
using System.Linq;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class VentilatorStatesList : ReadOnlyCollection<VentilatorState>
    {
        public static string INSERTED_CODE = "INS";
        public static string INUSE_CODE = "USE";
        public static string AVAIABLE_CODE = "AVB";

        public static VentilatorState INSERTED = new VentilatorState(INSERTED_CODE, "VENTILATOR.STATE.INSERTED");
        public static VentilatorState INUSE = new VentilatorState(INUSE_CODE, "VENTILATOR.STATE.INUSE");
        public static VentilatorState AVAIABLE = new VentilatorState(AVAIABLE_CODE, "VENTILATOR.STATE.AVAIABLE");

        public static ReadOnlyCollection<VentilatorState> AllVentilatorStates = new ReadOnlyCollection<VentilatorState>((from members in typeof(VentilatorStatesList).GetFields()
                                                                                                                         where members.FieldType == typeof(VentilatorState)
                                                                                                                         select (VentilatorState)members.GetValue(typeof(VentilatorStatesList).GetField(members.Name))).ToList());

        public VentilatorStatesList() : base(AllVentilatorStates)
        {
        }
    }
}