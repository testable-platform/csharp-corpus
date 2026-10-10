using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public enum DispatchPriority
    {
        Low,
        Normal,
        High,
        Urgent
    }

    public class ConveyorTicket
    {
        private string _ticketIdField = string.Empty;
        public string TicketId { get { return _ticketIdField; } set { _ticketIdField = value; } }
        public DispatchPriority Priority { get; set; }
        public double LoadTonnes { get; set; }
        public int DestinationCode { get; set; }
    }

    public class ConveyorDispatch
    {
        private readonly List<ConveyorTicket> _tickets = new List<ConveyorTicket>();

        // Deliberately over cyclomatic-complexity-10: a flat 13-way routing
        // switch instead of a lookup table, CCN ~14 (base 1 + 13 cases).
        public string RouteCode(int destinationCode)
        {
            switch (destinationCode)
            {
                case 1: return "north-pit";
                case 2: return "south-pit";
                case 3: return "east-crusher";
                case 4: return "west-crusher";
                case 5: return "screening-a";
                case 6: return "screening-b";
                case 7: return "stockpile-1";
                case 8: return "stockpile-2";
                case 9: return "stockpile-3";
                case 10: return "rail-load";
                case 11: return "truck-load";
                case 12: return "barge-load";
                case 13: return "overflow-yard";
                default:
                    throw new ArgumentOutOfRangeException("destinationCode");
            }
        }

        // Deliberately over cyclomatic-complexity-10: a chained condition
        // ladder instead of a weighted-score table, CCN ~13.
        public string PriorityLabel(ConveyorTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }

            if (ticket.Priority == DispatchPriority.Urgent && ticket.LoadTonnes > 50)
            {
                return "urgent-heavy";
            }
            else if (ticket.Priority == DispatchPriority.Urgent && ticket.LoadTonnes > 20)
            {
                return "urgent-medium";
            }
            else if (ticket.Priority == DispatchPriority.Urgent)
            {
                return "urgent-light";
            }
            else if (ticket.Priority == DispatchPriority.High && ticket.LoadTonnes > 50)
            {
                return "high-heavy";
            }
            else if (ticket.Priority == DispatchPriority.High && ticket.LoadTonnes > 20)
            {
                return "high-medium";
            }
            else if (ticket.Priority == DispatchPriority.High)
            {
                return "high-light";
            }
            else if (ticket.Priority == DispatchPriority.Normal && ticket.LoadTonnes > 50)
            {
                return "normal-heavy";
            }
            else if (ticket.Priority == DispatchPriority.Normal && ticket.LoadTonnes > 20)
            {
                return "normal-medium";
            }
            else if (ticket.Priority == DispatchPriority.Normal)
            {
                return "normal-light";
            }
            else if (ticket.LoadTonnes > 50)
            {
                return "low-heavy";
            }
            else if (ticket.LoadTonnes > 20)
            {
                return "low-medium";
            }
            else
            {
                return "low-light";
            }
        }

        // Deliberately over length-60: a day-shift report built line by line
        // instead of a loop over a table, ~70 statement lines in one function
        // body (no single decision point drives the length, so CCN stays
        // low -- this function trips the LENGTH threshold specifically,
        // not the complexity one, so the two planted defects are genuinely
        // different and not just one finding counted twice).
        public string ShiftReport(ConveyorTicket t1, ConveyorTicket t2, ConveyorTicket t3, ConveyorTicket t4, ConveyorTicket t5, ConveyorTicket t6)
        {
            var lines = new List<string>();
            lines.Add("=== Shift Dispatch Report ===");
            lines.Add("Ticket 1: " + t1.TicketId);
            lines.Add("  priority: " + t1.Priority);
            lines.Add("  load: " + t1.LoadTonnes);
            lines.Add("  destination: " + t1.DestinationCode);
            lines.Add("Ticket 2: " + t2.TicketId);
            lines.Add("  priority: " + t2.Priority);
            lines.Add("  load: " + t2.LoadTonnes);
            lines.Add("  destination: " + t2.DestinationCode);
            lines.Add("Ticket 3: " + t3.TicketId);
            lines.Add("  priority: " + t3.Priority);
            lines.Add("  load: " + t3.LoadTonnes);
            lines.Add("  destination: " + t3.DestinationCode);
            lines.Add("Ticket 4: " + t4.TicketId);
            lines.Add("  priority: " + t4.Priority);
            lines.Add("  load: " + t4.LoadTonnes);
            lines.Add("  destination: " + t4.DestinationCode);
            lines.Add("Ticket 5: " + t5.TicketId);
            lines.Add("  priority: " + t5.Priority);
            lines.Add("  load: " + t5.LoadTonnes);
            lines.Add("  destination: " + t5.DestinationCode);
            lines.Add("Ticket 6: " + t6.TicketId);
            lines.Add("  priority: " + t6.Priority);
            lines.Add("  load: " + t6.LoadTonnes);
            lines.Add("  destination: " + t6.DestinationCode);
            double total = t1.LoadTonnes + t2.LoadTonnes + t3.LoadTonnes + t4.LoadTonnes + t5.LoadTonnes + t6.LoadTonnes;
            lines.Add("Total tonnes dispatched: " + total);
            lines.Add("Ticket count: 6");
            lines.Add("Average load: " + (total / 6.0));
            lines.Add("Heaviest first ticket id: " + t1.TicketId);
            lines.Add("Report generated by ConveyorDispatch.ShiftReport");
            lines.Add("=== End Shift Dispatch Report ===");
            string result = string.Empty;
            foreach (var line in lines)
            {
                result = result + line + "\n";
            }
            return result;
        }

        // Clean, short, single-purpose helper -- deliberately left simple so
        // the corpus's majority-wrong bar is measured honestly against a
        // real mixed file, not a file where every function is bad.
        public bool IsEmpty()
        {
            return _tickets.Count == 0;
        }
    }
}
