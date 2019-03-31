﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using SimpleMapApp;
using SimpleMapApp.UWP;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace SimpleMapApp.UWP
{
    public class CustomMapRenderer : MapRenderer
    {
        CustomMap formsMap = null;
        MapControl nativeMap;
        List<CustomPin> customPins = new List<CustomPin>();

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                formsMap = (CustomMap)e.NewElement;
                nativeMap = Control as MapControl;
                var coordinates = new List<BasicGeoposition>();

                foreach (var position in formsMap.RouteCoordinates)
                {
                    coordinates.Add(new BasicGeoposition() { Latitude = position.Latitude, Longitude = position.Longitude });
                }
                if (coordinates.Count != 0)
                {
                    var polyline = new MapPolyline();
                    polyline.StrokeColor = Windows.UI.Color.FromArgb(128, 0, 0, 255);
                    polyline.StrokeThickness = 5;
                    polyline.Path = new Geopath(coordinates);
                    nativeMap.MapElements.Add(polyline);
                }

            }
        }
    }
}
