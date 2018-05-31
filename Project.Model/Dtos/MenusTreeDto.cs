using Project.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Dtos
{
    public class MenusTreeDto : Menus
    {
        public List<MenusTreeDto> Children { get; set; }

        public string BlankName
        {
            get
            {
                if (!Enum.IsDefined(typeof(OpenType), Blank))
                {
                    return "";
                }
                return Generator.GetDescription(typeof(OpenType), Blank.ToString());

            }
        }
    }
}
