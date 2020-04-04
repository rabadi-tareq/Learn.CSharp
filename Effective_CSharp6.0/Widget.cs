namespace Experiment
{
    internal class Widget
    {
        public Widget(WidgetType type)
        {
            WidgetType = type;
        }
        
        public WidgetType WidgetType { get; set; }     
    }
}