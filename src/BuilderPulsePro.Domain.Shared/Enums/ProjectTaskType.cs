using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Enums
{
    [Flags]
    public enum ProjectTaskType
    {
        Excavation = 1 << 0,
        Septic = 1 << 1,
        Well = 1 << 2,
        Foundation = 1 << 3,
        Joists = 1 << 4,
        Framing = 1 << 5,
        Trusses = 1 << 6,
        Roof = 1 << 7,
        Siding = 1 << 8,
        Windows = 1 << 9,
        Electrical = 1 << 10,
        Hvac = 1 << 11,
        Plumbing = 1 << 12,
        Floors = 1 << 13,
        Tile = 1 << 14,
        Cabinets = 1 << 15,
        Paint = 1 << 16,
        Doors = 1 << 17,
        Trim = 1 << 18,
        Glass = 1 << 19,
        Fence = 1 << 20,
        Deck = 1 << 21,
        Landscaping = 1 << 22,
        LandscapeDesign = 1 << 23,
    }
}
