using System.Collections.ObjectModel;
using System.Linq;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class VentilatorStatesTransactionsList : ReadOnlyCollection<VentilatorStatesTransaction>
    {

        public static ReadOnlyCollection<VentilatorStatesTransaction> AllVentilatorStates = new ReadOnlyCollection<VentilatorStatesTransaction>((from members in typeof(VentilatorStatesTransactionsList).GetFields()
                                                                                                                                                 where members.FieldType == typeof(VentilatorStatesTransaction)
                                                                                                                                                 select (VentilatorStatesTransaction)members.GetValue(typeof(VentilatorStatesTransactionsList).GetField(members.Name))).ToList());

        public VentilatorStatesTransactionsList() : base(AllVentilatorStates)
        {
        }
    }
}