using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SimpleMapApp
{
    public partial class MainPage : ContentPage
    {
        CustomMap customMap = new CustomMap
        {
            MapType = MapType.Street,
            WidthRequest = App.ScreenWidth,
            HeightRequest = App.ScreenHeight,
            IsShowingUser = true
        };
        public MainPage()
        {
            InitializeComponent();
            DrawMap();
        }

        private void DrawMap()
        {
            Position onePosition = new Position(9.608292 , 105.976721);
            Position twoPosition = new Position(9.605916, 105.975508);

            
            List<Position> listPoint = new List<Position>();
            listPoint.Add(onePosition);
            listPoint.Add(twoPosition);

            var startPin = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(onePosition.Latitude, onePosition.Longitude),
                    Label = "You start from here",
                    Address = ""
                },
                Id = "Start point",
                Url = "Channel NTL TV"
            };
            customMap.RouteCoordinates.Clear();
            foreach (var item in listPoint)
            {
                //Every Position put a Pin
                customMap.RouteCoordinates.Add(new Position(item.Latitude, item.Longitude));
            }

            //Add Pin to map
            customMap.CustomPins = new List<CustomPin> { startPin };
            Content = customMap;
            
        }
    }
}
