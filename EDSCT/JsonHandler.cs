﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace EDSCT
{

    

    public partial class JsonHandler
    {
        static string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
        public static string DataFolder = AppFolder + "Data\\";

        //Core ship info
        public List<ship> Ship { get; set; }
        
        public class ship
        {
            public bool Horizons { get; set; }
            public string ShipName { get; set; }
            public string Manufacturer { get; set; }
            public double[] Dimensions { get; set; }
            public string LandingPadSize { get; set; }
            public string Type { get; set; }
            public int Cost { get; set; }
            public int Insurance { get; set; }
            public int TopSpeed { get; set; }
            public int MaxSpeed { get; set; }
            public int BoostSpeed { get; set; }
            public int MaxBoostSpeed { get; set; }
            public int Agility { get; set; }
            public int Shields { get; set; }
            public int Armor { get; set; }
            public int HullMass { get; set; }
            public int CargoCapacity { get; set; }
            public int MaxCargo { get; set; }
            public int FuelCapacity { get; set; }
            public double UnladenJump { get; set; }
            public double MaxJump { get; set; }
            public int MassLockFactor { get; set; }
            public int Seats { get; set; }
            public bool FighterBay { get; set; }
            public int FighterCount { get; set; }
        }

        //Hardpoints
        public List<hardpoints> Hardpoints { get; set; }

        public class hardpoints
        {
            public int Utility { get; set; }
            public int Small { get; set; }
            public int Medium { get; set; }
            public int Large { get; set; }
            public int Huge { get; set; }
        }


        //Internal Sizes
        public List<internals> Internals { get; set; }
        public class internals
        {
            public int Size1 { get; set; }
            public int Size2 { get; set; }
            public int Size3 { get; set; }
            public int Size4 { get; set; }
            public int Size5 { get; set; }
            public int Size6 { get; set; }
            public int Size7 { get; set; }
            public int Size8 { get; set; }

        }



        public static void createExampleJson()
        {

            List<ship> _jsonShip = new List<ship>();
            List<hardpoints> _jsonHardpoints = new List<hardpoints>();
            List<internals> _jsonInternals = new List<internals>();

            _jsonShip.Add(new ship()
            {
                Horizons = false,
                ShipName = "Sidewinder",
                Manufacturer = "Faulcon DeLacy",
                Dimensions = new double[] { 14.9, 21.3, 5.4 },
                LandingPadSize = "Small",
                Type = "Light Multipurpose",
                Cost = 48000,
                Insurance = 1600,
                TopSpeed = 220,
                MaxSpeed = 255,
                BoostSpeed = 320,
                MaxBoostSpeed = 371,
                Agility = 168,
                Shields = 40,
                Armor = 108,
                HullMass = 25,
                Seats = 1,
                FighterBay = false,
                FighterCount = 0,
                CargoCapacity = 4,
                MaxCargo = 12,
                FuelCapacity = 2,
                UnladenJump = 7.56,
                MaxJump = 24.43,
                MassLockFactor = 6
            });

            _jsonHardpoints.Add(new hardpoints()
            {
                Utility = 2,
                Small = 2,
                Medium = 0,
                Large = 0,
                Huge = 0
            });

            _jsonInternals.Add(new internals()
            {
                Size1 = 2,
                Size2 = 2,
                Size3 = 0,
                Size4 = 0,
                Size5 = 0,
                Size6 = 0,
                Size7 = 0,
                Size8 = 0
            });

       

            string json = JsonConvert.SerializeObject(_jsonShip, Formatting.Indented) + JsonConvert.SerializeObject(_jsonHardpoints, Formatting.Indented) + JsonConvert.SerializeObject(_jsonInternals, Formatting.Indented);

            File.WriteAllText(DataFolder + "Sidewinder.json", json);
        }

        public static void loadJson()
        {
            foreach (string file in Directory.EnumerateFiles(DataFolder, "*.json")) {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    List<ship> itemsShip = JsonConvert.DeserializeObject<List<ship>>(json);
                    List<hardpoints> itemsHardpoints = JsonConvert.DeserializeObject<List<hardpoints>>(json);
                    List<internals> itemsInternals = JsonConvert.DeserializeObject<List<internals>>(json);
                }
            }
        }

    }
}
