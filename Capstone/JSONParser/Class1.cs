﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParser
{
    public class Class1
    {
        Alarm alarmParser = new Alarm();
        DeviceBasic deviceBasicParser = new DeviceBasic();
        Health healthParser = new Health();
        Event eventParser = new Event();

        public Class1()
        {
            //alarm.json
            StreamReader r = new StreamReader("../JSONParser/bin/siteendpointsjson/stat/alarm.json");
            var alarmJson = r.ReadToEnd();
            alarmParser = JsonConvert.DeserializeObject<Alarm>(alarmJson);

            //device-basic.json
            r = new StreamReader("../JSONParser/bin/siteendpointsjson/stat/device-basic.json");
            var deviceBasicjson = r.ReadToEnd();
            deviceBasicParser = JsonConvert.DeserializeObject<DeviceBasic>(deviceBasicjson);

            //health.json
            r = new StreamReader("../JSONParser/bin/siteendpointsjson/stat/health.json");
            var healthjson = r.ReadToEnd();
            healthParser = JsonConvert.DeserializeObject<Health>(healthjson);

            //event.json
            r = new StreamReader("../JSONParser/bin/siteendpointsjson/stat/event.json");
            var eventjson = r.ReadToEnd();
            eventParser = JsonConvert.DeserializeObject<Event>(eventjson);
        }

        public IEnumerable<EventData> EventKeyParser(string key)
        {

            IEnumerable <EventData> myQuery = from ep in eventParser.data
                                                where ep.key == key
                                                select ep;
            return myQuery;
        }

        //Alarm
        public class AlarmData
        {
            public DateTime datetime { get; set; }
            public string key { get; set; }
            public string msg { get; set; }
            public string sw_model { get; set; }
            public string sw_name { get; set; }
            public object time { get; set; }
            public int? port { get; set; }
            public string dm_model { get; set; }
            public string dm_name { get; set; }
            public string iface { get; set; } //eth8 - WAN1 / eth9 - is WAN2
            public string state { get; set; }

        }

        public class Alarm
        {
            public List<AlarmData> data { get; set; }

        }

        //Device Basic 
        public class DeviceBasicData
        {
            public bool adopted { get; set; } // not sure 
            public bool disabled { get; set; } // not sure
            public string mac { get; set; } // MAC ID
            public string model { get; set; }
            public string name { get; set; }
            public int state { get; set; } // state 1 or state 0, not sure what they mean 
            public string type { get; set; }
        }

        public class DeviceBasic
        {
            public List<DeviceBasicData> data { get; set; }
        }

        //Health
        public class GwSystemStats
        {
            public string cpu { get; set; }
            public string mem { get; set; }
            public string uptime { get; set; }
        }

        public class WAN
        {
            public double availability { get; set; }
            public int latency_average { get; set; }
            public int time_period { get; set; }
        }

        public class WAN2
        {
            public int downtime { get; set; }
        }

        public class UptimeStats
        {
            public WAN WAN { get; set; }
            public WAN2 WAN2 { get; set; }
        }

        public class HealthData
        {
            public int num_disconnected { get; set; }
            public int num_user { get; set; }

            public string status { get; set; }
            public string subsystem { get; set; }

            public string gw_name { get; set; }

            public string gw_version { get; set; }
            public string isp_name { get; set; }
            public string isp_organization { get; set; }
            public int? num_gw { get; set; }
            public int? num_sta { get; set; }
            public UptimeStats uptime_stats { get; set; }
            public string wan_ip { get; set; }
            public int? drops { get; set; }
            public int? latency { get; set; }
            public int? speedtest_lastrun { get; set; }
            public int? speedtest_ping { get; set; }
            public string speedtest_status { get; set; }
            public int? uptime { get; set; }
            public int? num_sw { get; set; }
        }

        public class Health
        {
            public List<HealthData> data { get; set; }
        }

        //Event
        public class EventData
        {
            public string _id { get; set; }
            public string ap { get; set; }
            public string ap_displayName { get; set; }
            public string site_id { get; set; }
            public string ap_model { get; set; }
            public string ap_name { get; set; }
            public long bytes { get; set; }
            public DateTime datetime { get; set; }
            public int duration { get; set; }
            public string hostname { get; set; }
            public bool is_negative { get; set; }
            public string key { get; set; }
            public string msg { get; set; }
            public string ssid { get; set; }
            public string subsystem { get; set; }
            public object time { get; set; }
            public string user { get; set; } // mac id of user 
            public string channel { get; set; }
            public string radio { get; set; }
            public string channel_from { get; set; }
            public string channel_to { get; set; }

        }

        public class Event
        {
            public List<EventData> data { get; set; }
        }


    }
}