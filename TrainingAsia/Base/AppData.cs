using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAsia.Base
{
    class AppData
    {
        private static TrainingDBEntities context;
        public static TrainingDBEntities GetContext()
        {
            if (context == null)
            {
                context = new TrainingDBEntities();
            }

            return context;
        }
    }
}
