using System;

namespace Auth.Api.Models.Module
{
    public class ModuleItemModel
    {
        public ModuleItemModel(Guid id, string caption, string shortCaption, string route)
        {
            Id = id;
            Caption = caption;
            ShortCaption = shortCaption;
            Route = route;
        }

        public Guid Id { get; }
        public string Caption { get; }
        public string ShortCaption { get; }
        public string Route { get; }
    }
}
