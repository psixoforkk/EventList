using EventList.Models;
using Microsoft.VisualBasic;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace EventList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<CityEvent> cityEvents;
        private List<CityEvent> kids;
        private List<CityEvent> sport;
        private List<CityEvent> culture;
        private List<CityEvent> excursions;
        private List<CityEvent> lifestyle;
        private List<CityEvent> partys;
        private List<CityEvent> study;
        private List<CityEvent> online;
        private List<CityEvent> show;

        public MainWindowViewModel()
        {
            LoadXML();
            kids = new List<CityEvent>();
            sport = new List<CityEvent>();
            culture = new List<CityEvent>();
            excursions = new List<CityEvent>();
            lifestyle = new List<CityEvent>();
            partys = new List<CityEvent>();
            study = new List<CityEvent>();
            online = new List<CityEvent>();
            show = new List<CityEvent>();

            foreach (CityEvent thing in cityEvents)
            {
                if (CheckForMatch(thing.Ccategory, "Для детей"))
                {
                    kids.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Спорт"))
                {
                    sport.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Культура"))
                {
                    culture.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Экскурсии"))
                {
                    excursions.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Образ жизни"))
                {
                    lifestyle.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Вечеринки"))
                {
                    partys.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Образование"))
                {
                    study.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Онлайн"))
                {
                    online.Add(thing);
                }
                if (CheckForMatch(thing.Ccategory, "Шоу"))
                {
                    show.Add(thing);
                }
            }
        }
        private static bool CheckForMatch(string category, string expected)
        {
            var words = new HashSet<String>(category.Split(), StringComparer.InvariantCultureIgnoreCase);
            return expected.Split().Any(words.Contains);
        }
        private void LoadXML()
        {
            int desc_count = 135;
            bool flag = false;
            cityEvents = new List<CityEvent>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..//..//..//Events.xml");
            XmlElement ? xmlRoot = xmlDoc.DocumentElement;
            if (xmlRoot != null)
            {
                foreach (XmlElement xmlnode in xmlRoot)
                {
                    CityEvent cityevent = new CityEvent();
                    XmlNode? attr = xmlnode.Attributes.GetNamedItem("name");
                    cityevent.Title1 = attr?.Value;
                    foreach (XmlNode childnode in xmlnode.ChildNodes)
                    {
                        if (childnode.Name == "Description")
                        {
                            if (childnode.InnerText.Length >= desc_count)
                            {
                                cityevent.Ddescription = childnode.InnerText.Remove(desc_count, childnode.InnerText.Length - desc_count) + "...";
                            }
                            else
                            {
                                cityevent.Ddescription = childnode.InnerText;
                            }
                        }
                        if (childnode.Name == "Date")
                        {
                            cityevent.Ddate = childnode.InnerText;
                        }
                        if (childnode.Name == "CategoryItem")
                        {
                            foreach (XmlNode categorynode in childnode.ChildNodes)
                            {
                                if (categorynode.Name == "Category")
                                {
                                    if (flag)
                                    {
                                        cityevent.Ccategory += " , ";
                                        cityevent.Ccategory += categorynode.InnerText;
                                    }
                                    else
                                    {
                                        cityevent.Ccategory += categorynode.InnerText;
                                        flag = true;
                                    }
                                }
                            }
                        }
                        if (childnode.Name == "Price")
                        {
                            if (childnode.InnerText == string.Empty)
                            {
                                cityevent.Price = "Бесплатно";
                            }
                            else
                            {
                                cityevent.Price = childnode.InnerText;
                            }
                        }
                        if (childnode.Name == "Image")
                        {
                            cityevent.ImagePath = childnode.InnerText;
                        }
                    }
                    flag = false;
                    cityEvents.Add(cityevent);
                }
            }
        }
        public List<CityEvent> CityEvents
        {
            get { return cityEvents; }
            set
            {
                this.RaiseAndSetIfChanged(ref cityEvents, value);
            }
        }
        public List<CityEvent> Kids
        {
            get { return kids; }
            set
            {
                this.RaiseAndSetIfChanged(ref kids, value);
            }
        }
        public List<CityEvent> Sport
        {
            get { return sport; }
            set
            {
                this.RaiseAndSetIfChanged(ref sport, value);
            }
        }
        public List<CityEvent> Culture
        {
            get { return culture; }
            set
            {
                this.RaiseAndSetIfChanged(ref culture, value);
            }
        }
        public List<CityEvent> Excursions
        {
            get { return excursions; }
            set
            {
                this.RaiseAndSetIfChanged(ref excursions, value);
            }
        }
        public List<CityEvent> Lifestyle
        {
            get { return lifestyle; }
            set
            {
                this.RaiseAndSetIfChanged(ref lifestyle, value);
            }
        }
        public List<CityEvent> Partys
        {
            get { return partys; }
            set
            {
                this.RaiseAndSetIfChanged(ref partys, value);
            }
        }
        public List<CityEvent> Study
        {
            get { return study; }
            set
            {
                this.RaiseAndSetIfChanged(ref study, value);
            }
        }
        public List<CityEvent> Online
        {
            get { return online; }
            set
            {
                this.RaiseAndSetIfChanged(ref online, value);
            }
        }
        public List<CityEvent> Show
        {
            get { return show;  }
            set
            {
                this.RaiseAndSetIfChanged(ref show, value);
            }
        }
    }
}
