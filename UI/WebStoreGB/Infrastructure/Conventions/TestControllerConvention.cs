using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreGB.Infrastructure.Conventions
{
    public class TestControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            //throw new NotImplementedException();
        }
    }
}
