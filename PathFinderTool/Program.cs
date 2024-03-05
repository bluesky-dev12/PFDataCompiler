using System;
using System.Diagnostics;

namespace PathFinderTool
{
    internal class Program
    {
        struct PATHFINDHEADER
        {
            public int id;
            public byte majorRev;
            public byte minorRev;
            public byte release;
            public byte prerelease;
            public ushort saveIncrement;
            public ushort generateID;
            public byte projectID;
            public byte numtracks;
            public byte numsections;
            public byte numevents;
            public byte numrouters;
            public byte numnamedvars;
            public ushort numnodes;
            public uint nodeoffsets;
            public uint nodedata;
            public uint eventoffsets;
            public uint eventdata;
            public uint namedvars;
            public uint noderouters;
            public uint trackoffsets;
            public uint trackinfos;
            public uint sampleoffsets;
            public uint mapfilelen;
            public uint[] v40reserve;
        }

        struct PATHNODEBEATS
        {
            public bool forcesynch; // Represents 1 bit for forcesynch
            public bool playbeats;  // Represents 1 bit for playbeats
        }

        struct PATHNODEEVENT
        {
            public int eventID;     // Represents 24 bits for eventID
        }

        struct PATHNODECHANNEL
        {
            public int eventID;     // Represents 24 bits for eventID
            public int channelset;  // Represents 4 bits for channelset
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string filePath = args[0]; // Replace this with your file path

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    PATHFINDHEADER header = new PATHFINDHEADER();

                    // Read the structure fields sequentially
                    header.id = reader.ReadInt32();
                    header.majorRev = reader.ReadByte();
                    header.minorRev = reader.ReadByte();
                    header.release = reader.ReadByte();
                    header.prerelease = reader.ReadByte();
                    header.saveIncrement = reader.ReadUInt16();
                    header.generateID = reader.ReadUInt16();
                    header.projectID = reader.ReadByte();
                    header.numtracks = reader.ReadByte();
                    header.numsections = reader.ReadByte();
                    header.numevents = reader.ReadByte();
                    header.numrouters = reader.ReadByte();
                    header.numnamedvars = reader.ReadByte();
                    header.numnodes = reader.ReadUInt16();
                    header.nodeoffsets = reader.ReadUInt32();
                    header.nodedata = reader.ReadUInt32();
                    header.eventoffsets = reader.ReadUInt32();
                    header.eventdata = reader.ReadUInt32();
                    header.namedvars = reader.ReadUInt32();
                    header.noderouters = reader.ReadUInt32();
                    header.trackoffsets = reader.ReadUInt32();
                    header.trackinfos = reader.ReadUInt32();
                    header.sampleoffsets = reader.ReadUInt32();
                    header.mapfilelen = reader.ReadUInt32();

                    Console.WriteLine("#------------------------------------------------------------------------");
                    Console.WriteLine("# Version info");
                    Console.WriteLine("#------------------------------------------------------------------------");

                    Console.WriteLine("id: " + header.id);
                    Console.WriteLine("majorRev: " + header.majorRev);
                    Console.WriteLine("minorRev: " + header.minorRev);
                    Console.WriteLine("release: " + header.release);
                    Console.WriteLine("prerelease: " + header.prerelease);
                    Console.WriteLine("saveIncrement: " + header.saveIncrement);
                    Console.WriteLine("generateID: " + header.generateID);
                    Console.WriteLine("projectID: " + header.projectID);
                    Console.WriteLine("numtracks: " + header.numtracks);
                    Console.WriteLine("numsections: " + header.numsections);
                    Console.WriteLine("numevents: " + header.numevents);
                    Console.WriteLine("numrouters: " + header.numrouters);
                    Console.WriteLine("numnamedvars: " + header.numnamedvars);
                    Console.WriteLine("numnodes: " + header.numnodes);
                    Console.WriteLine("nodeoffsets: " + header.nodeoffsets);
                    Console.WriteLine("nodedata: " + header.nodedata);
                    Console.WriteLine("eventoffsets: " + header.eventoffsets);
                    Console.WriteLine("eventdata: " + header.eventdata);
                    Console.WriteLine("namedvars: " + header.namedvars);
                    Console.WriteLine("noderouters: " + header.noderouters);
                    Console.WriteLine("trackoffsets: " + header.trackoffsets);
                    Console.WriteLine("trackinfos: " + header.trackinfos);
                    Console.WriteLine("sampleoffsets: " + header.sampleoffsets);
                    Console.WriteLine("mapfilelen: " + header.mapfilelen);

                    header.v40reserve = new uint[3];
                    for (int i = 0; i < 3; i++)
                    {
                        header.v40reserve[i] = reader.ReadUInt32();
                    }

                    // Use the data from the structure as needed
                    Console.WriteLine("ID: " + header.id);
                    Console.WriteLine("Num Tracks: " + header.numtracks);
                    // Print other fields as needed
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}