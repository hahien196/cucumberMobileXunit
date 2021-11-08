using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTV.Application.SpecFlowAppiumTests.Pages
{
    public interface IPageManager
    {
        bool ValidateElements(string elementName);
    }
}
