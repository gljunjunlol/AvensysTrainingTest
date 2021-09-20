using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{
    class BenelliBike : Interface1
    {
        public int EngineCapacity()
        {
            return
        }

        public void ShowBikeInformation()
        {
            throw new NotImplementedException();
        }

        public int speed()
        {
            throw new NotImplementedException();
        }

        public int Torque()
        {
            throw new NotImplementedException();
        }
    }

    class RoadsterSeries : BenelliBike, SpecialFeatures
    {

        // increment 20% override here

    }

    sealed class SpecialEditionRoadSter: RoadsterSeries
    {
        // cannot have child
        // increment 5% override here
    }
}
