using System;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PathFinderTool
{
    internal class Program
    {
        struct PATHFINDHEADER
        {
            public byte[] id;
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
            Console.Title = "PathFinderTool";

            string filePath = args[0];

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    PATHFINDHEADER header = new PATHFINDHEADER();

                    // Read the structure fields sequentially -> size 0x48
                    header.id = reader.ReadBytes(4);
                    string stringValue = Encoding.ASCII.GetString(header.id);
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

                    // Create a FileStream to write the binary data
                    using (FileStream fileStream = new FileStream("output.bin", FileMode.Create))
                    {
                        BinaryWriter writer = new BinaryWriter(fileStream);

                        // Write header fields to the file
                        writer.Write((byte[])header.id);
                        writer.Write((byte)header.majorRev);
                        writer.Write((byte)header.minorRev);
                        writer.Write((byte)header.release);
                        writer.Write((byte)header.prerelease);
                        writer.Write((ushort)header.saveIncrement);
                        writer.Write((ushort)header.generateID);
                        writer.Write((byte)header.projectID);
                        writer.Write((byte)header.numtracks);
                        writer.Write((byte)header.numsections);
                        writer.Write((byte)header.numevents);
                        writer.Write((byte)header.numrouters);
                        writer.Write((byte)header.numnamedvars);
                        writer.Write((ushort)header.numnodes);
                        writer.Write((uint)header.nodeoffsets);
                        writer.Write((uint)header.nodedata);
                        writer.Write((uint)header.eventoffsets);
                        writer.Write((uint)header.eventdata);
                        writer.Write((uint)header.namedvars);
                        writer.Write((uint)header.noderouters);
                        writer.Write((uint)header.trackoffsets);
                        writer.Write((uint)header.trackinfos);
                        writer.Write((uint)header.sampleoffsets);
                        writer.Write((uint)header.mapfilelen);
                    }

                    Console.WriteLine("#------------------------------------------------------------------------");
                    Console.WriteLine("# Version info");
                    Console.WriteLine("#------------------------------------------------------------------------");

                    Console.WriteLine("MPFID: " + stringValue);
                    Console.WriteLine("MajorRev: " + header.majorRev);
                    Console.WriteLine("MinorRev: " + header.minorRev);
                    Console.WriteLine("Release: " + header.release);
                    Console.WriteLine("Prerelease: " + header.prerelease);
                    Console.WriteLine("SaveIncrement: " + header.saveIncrement);
                    Console.WriteLine("GenerateID: " + header.generateID);
                    Console.WriteLine("ProjectID: " + header.projectID);
                    Console.WriteLine("Numtracks: " + header.numtracks);
                    Console.WriteLine("NumSections: " + header.numsections);
                    Console.WriteLine("NumEvents: " + header.numevents);
                    Console.WriteLine("NumRouters: " + header.numrouters);
                    Console.WriteLine("NumNamedvars: " + header.numnamedvars);
                    Console.WriteLine("NumNodes: " + header.numnodes);
                    Console.WriteLine("NodeOffsets: " + header.nodeoffsets);
                    Console.WriteLine("NodeData: " + header.nodedata);
                    Console.WriteLine("EventOffsets: " + header.eventoffsets);
                    Console.WriteLine("EventData: " + header.eventdata);
                    Console.WriteLine("NamedVars: " + header.namedvars);
                    Console.WriteLine("NodeRouters: " + header.noderouters);
                    Console.WriteLine("TrackOffsets: " + header.trackoffsets);
                    Console.WriteLine("TrackInfos: " + header.trackinfos);
                    Console.WriteLine("SampleOffsets: " + header.sampleoffsets);
                    Console.WriteLine("Mapfilelen: " + header.mapfilelen);

                    header.v40reserve = new uint[3];
                    for (int i = 0; i < 3; i++)
                    {
                        header.v40reserve[i] = reader.ReadUInt32();
                    }
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