using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace Experiment
{
    internal class WidgetBuilder
    {
        private const int MinimumBasicWidgetCount = 3;

        public WidgetBuilder(List<Widget> widgets)
        {
            Widgets = widgets;
        }

        public List<Widget> Widgets { get;}
        
        public void BuildFoundation()
        {
            BuildFoundationInternal();
        }

        public bool TryBuildFoundation()
        {
            if (!AreAllBasicWidgetsAvailable())
            {
                return false;
            }
            BuildFoundationInternal();
            return true;
        }

        private void BuildFoundationInternal()
        {
            if(!AreAllBasicWidgetsAvailable())
                throw new WorkerException($"Only {Widgets.Count} is supplied, the minimum is {MinimumBasicWidgetCount}");
            $"Foundation with {Widgets.Count} has been built".LogToConsole();
        }

        private bool AreAllBasicWidgetsAvailable()
        {
            return Widgets.Count(w => w.WidgetType == WidgetType.Basic) > MinimumBasicWidgetCount;
        }
    }
}